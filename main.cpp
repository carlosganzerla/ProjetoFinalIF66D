 #include "mbed.h"
#include "EthernetInterface.h"
#include "TCPServer.h"
#include "TCPSocket.h"
#define TARGET_ADDRESS "192.168.0.10"
#define TARGET_PORT 11001

Thread listener;
Thread sender;
Timer t;
EthernetInterface eth;


void listener_body();
void sender_body();
int send_pkt(TCPSocket& socket, char* data, char* response);

int main()
{
    eth.connect();
    listener.start(listener_body);
    sender.start(sender_body);
    while (true) {
        
    }
}


void sender_body() {
    TCPSocket socket;
    socket.open(&eth);
    socket.connect(TARGET_ADDRESS,TARGET_PORT);
    int n = 0;
    t.start(); 
    while(true ){
        if (t.read() > 5) {
            char response[256];
            char data[256];
            snprintf(data, sizeof(data), "%d", ++n);
            printf("Sending data to destination: %s\n",data);  
            int bytesRec = send_pkt(socket,data,response);   

            if(bytesRec > 0) {
                printf("Received from destination: %s\n",response);  
            }
            t.reset();
        }
    }
}

int send_pkt(TCPSocket& socket, char* data, char* response) {
    printf("Send socket open.\n");
    socket.send(data, sizeof(data));
    printf("Data sent.\n");
    return socket.recv(response,sizeof(response));
}


void listener_body() {  
    printf("Listener thread has started!\n");
    printf("The target IP address is '%s'\n", eth.get_ip_address());
    TCPServer srv;
    /* Open the server on ethernet stack */
    srv.open(&eth);
    printf("Socket Open\n");

    srv.bind(eth.get_ip_address(), 11000);
    printf("Socket Bound\n");
    
    /* Can handle 5 simultaneous connections */
    srv.listen(5);
    printf("Listening...\n");

    while(true) {
        char buffer[256];
        TCPSocket clt_sock;
        SocketAddress clt_addr;
        srv.accept(&clt_sock, &clt_addr);
        printf("Accepted %s:%d\n", clt_addr.get_ip_address(), clt_addr.get_port());
        int n = clt_sock.recv(buffer, sizeof(buffer));
        do {
            printf("Received %s\n", buffer);
            snprintf(buffer, sizeof(buffer), "Confirmed for %d bytes", n);
            clt_sock.send(buffer, strlen(buffer));
            n = clt_sock.recv(buffer, sizeof(buffer));
        } while(n > 0);
    }
}