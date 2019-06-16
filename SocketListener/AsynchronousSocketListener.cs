using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketListener
{
    public class AsynchronousSocketListener
    {
        // Thread signal.  
        private readonly IPAddress address;
        private readonly int port;
        private Socket listener;
        public event EventHandler<SocketData> ConnectionAccepted;
        public event EventHandler<SocketData> ConnectionClosed;
        public event EventHandler<SocketData> DataReceived;


        public AsynchronousSocketListener(IPAddress address, int port)
        {
            this.address = address;
            this.port = port;
        }

        public void StartListening()
        {
            try
            {
                listener.Close();
            }
            catch (Exception)
            {
            }
            IPEndPoint localEndPoint = new IPEndPoint(address, port);
            listener = new Socket(address.AddressFamily,
                 SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                // Set the event to nonsignaled state.  

                // Start an asynchronous socket to listen for connections.  
                Console.WriteLine("Waiting for a connection...");
                listener.BeginAccept(
                    new AsyncCallback(AcceptCallback),
                    listener);

                // Wait until a connection is made before continuing.  

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        private void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.  
            // Get the socket that handles the client request.  
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            Console.WriteLine("Accepted connection!");
            ConnectionAccepted?.Invoke(this, new SocketData { Data = "Conexão OK" });
            // Create the state object.  
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
        }

        private void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket.   
            int bytesRead = handler.EndReceive(ar);
            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.  
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));

                // Check for end-of-file tag. If it is not there, read   
                // more data.  
                content = state.sb.ToString();
                // All the data has been read from the   
                // client. Display it on the console.  
                Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                    content.Length, content);
                DataReceived?.Invoke(this, new SocketData { Data = content });
                // Echo the data back to the client.  
                Send(handler, "OK");
            }
        }

        private void Send(Socket handler, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        private void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);
                StateObject state = new StateObject();
                state.workSocket = handler;

                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                     new AsyncCallback(ReadCallback), state);
                //handler.Shutdown(SocketShutdown.Both);
                //handler.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void ShutdownListener()
        {
            try
            {
                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
                ConnectionClosed?.Invoke(this, new SocketData { Data = "conexão fechada!" });
                ConnectionClosed = null;
                ConnectionAccepted = null;
                DataReceived = null;
            }
            catch (ObjectDisposedException)
            {
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
        }

    }
}
