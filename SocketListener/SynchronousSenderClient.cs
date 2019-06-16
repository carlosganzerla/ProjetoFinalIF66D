using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketListener
{
    public class SynchronousSenderClient
    {
        private readonly IPAddress address;
        private readonly int port;
        private Socket sender;
        public event EventHandler<string> Response;

        public SynchronousSenderClient(IPAddress address, int port)
        {
            this.address = address;
            this.port = port;
        }

        public void ConnectClient()
        {
            try
            {
                this.sender.Close();
            }
            catch (Exception)
            {
            }
            try
            {
                IPEndPoint remoteEP = new IPEndPoint(address, port);
                sender = new Socket(address.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);
                sender.Connect(remoteEP);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void SendMessage(string message)
        {
            try
            {
                byte[] bytes = new byte[1024];
                // Encode the data string into a byte array.  
                byte[] msg = Encoding.ASCII.GetBytes(message);

                // Send the data through the socket.  
                int bytesSent = sender.Send(msg);

                // Receive the response from the remote device.  
                int bytesRec = sender.Receive(bytes);
                Console.WriteLine("Echoed test = {0}",
                    Encoding.ASCII.GetString(bytes, 0, bytesRec));
                Response?.Invoke(this, Encoding.ASCII.GetString(bytes, 0, bytesRec));

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

        public void ShutdownClient()
        {
            try
            {
                Response = null;
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
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
