 #include "mbed.h"
#include "EthernetInterface.h"
#include "TCPServer.h"
#include "TCPSocket.h"
#define TARGET_ADDRESS "10.3.20.141"
#define TARGET_PORT 10999
#define INITIAL_INPUT 5
#define ALERT_RANGE 2
#define LED_ON 0
#define LED_OFF 1
//STRUCTS
typedef struct {
    float temperature;
} message_t;

//CONSTANTE DE ESCALA PARA O LM35
const float K=330; 
//PELTIER E SENSOR LM 35
DigitalOut peltier(PTB10);
AnalogIn temp(PTB2);
//LED
DigitalOut green(LED2);
DigitalOut red(LED1);
//FILAS, MEMORY POOLS E MUTEXES
MemoryPool<message_t, 16> send_mpool, user_mpool, control_mpool;
Queue<message_t, 16> send_queue, user_queue, control_queue;
//THREADS
Thread listener;
Thread sender;
Thread reader;
Thread controller;
Thread alerter;
//INTERFACE ETHERNET
EthernetInterface eth;
//CORPO DAS THREADS
void listener_body();
void sender_body();
void reader_body();
void controller_body();
void alerter_body();
//HELPERS
int send_pkt(TCPSocket& socket, char* data, char* response);
//VARI�VEIS GLOBAIS
float input = INITIAL_INPUT;
float current_temp = 0;
//MAIN
int main()
{
	//DESLIGA OS LEDS
    red = LED_OFF;
    green = LED_OFF;
	//INICIALIZA INTERFACE ETHERNET DA PLACA
    eth.connect();
	//INICIA AS THREADS
    listener.start(listener_body);
    sender.start(sender_body);
    reader.start(reader_body);
    controller.start(controller_body);
    alerter.start(alerter_body);
    while (true) {
        
    }
}

//THREAD DE CLIENTE TCP
void sender_body() {
    TCPSocket socket;
    socket.open(&eth);
	//ABRE O SOCKET NA PORTA DESEJADA
    socket.connect(TARGET_ADDRESS,TARGET_PORT);
    while(true) {
		//ESPERA MENSAGEM
        osEvent evt = send_queue.get();
        if (evt.status == osEventMessage) {
            //RECEBIMENTO DE DADOS DA FILA E PREPARO DE ENVIO
            message_t *message = (message_t*)evt.value.p;
            char data[256];
            memset(data, 0, sizeof(data));
            printf("Temperature acquired: %.2f\n", message->temperature);
            snprintf(data,sizeof(data),"%.2f", message->temperature);
            send_mpool.free(message);
            printf("Sending data to destination: %s\n",data);  
            //PREPARO PARA RESPOSTA DO SOCKET DO OUTRO LADO
            char response[256];
            memset(response, 0, sizeof(response));
			//ENVIA PACOTE AO SERVIDOR NO PC
            int bytesRec = send_pkt(socket,data,response);   
            if(bytesRec > 0) {
				//SERVIDOR RESPONDEU
                printf("Received from destination: %s\n",response);  
            }
        }
    }
}

//FUN��PO AUXILIAR QUE ENVIA PACOTES AT� O SOCKET DE DESTINO
int send_pkt(TCPSocket& socket, char* data, char* response) {
    printf("Send socket open.\n");
    socket.send(data, 256);
    printf("Data sent: %s\n",data);
    return socket.recv(response,sizeof(response));
}


//SERVIDOR TCP
void listener_body() {  
    printf("Listener thread has started!\n");
    printf("The target IP address is '%s'\n", eth.get_ip_address());
    TCPServer srv;
	//INICIALIZA O TCP SERVER NA INTERFACE ETHERNET ATUAL
    srv.open(&eth);
    printf("Socket Open\n");
	//FAZ O BIND DO SOCKET NA PORTA SELECIONADA
    srv.bind(eth.get_ip_address(), 11000);
    printf("Socket Bound\n");
    
	//SUPORTA AT� 5 CONEX�ES SIMULT�NEAS
    srv.listen(5);
    printf("Listening...\n");

    while(true) {
        char buffer[256];
        memset(buffer, 0, sizeof(buffer));
        TCPSocket clt_sock;
        SocketAddress clt_addr;
        srv.accept(&clt_sock, &clt_addr);
        printf("Accepted %s:%d\n", clt_addr.get_ip_address(), clt_addr.get_port());
        int n = clt_sock.recv(buffer, sizeof(buffer));
        do {
            float f = atof(buffer);
            input = f;
            printf("Input set to: %.2f\n", f);
            printf("Received %s\n", buffer);
            snprintf(buffer, sizeof(buffer), "Input set to: %.2f\n", f);
            clt_sock.send(buffer, strlen(buffer));
            memset(buffer, 0, sizeof(buffer));
            n = clt_sock.recv(buffer, sizeof(buffer));
        } while(n > 0);
    }
}

void reader_body ()
{
	//L� TEMPERATURA E ALOCA MENSAGENS NAS FILAS DE CONTROLE E DE ENVIO DE DADOS AO PC
    while (true) {
        current_temp = (temp/2.)*K;
        message_t *message_to_sender = send_mpool.alloc();
        message_to_sender->temperature = current_temp;
		//POE MENSAGENS NA FILA DO CLIENTE TCP
        send_queue.put(message_to_sender);
        message_t *message_to_controller = control_mpool.alloc();
        message_to_controller->temperature = current_temp;
		//POE MENSAGENS NA FILA DO CONTROLADOR
        control_queue.put(message_to_controller);
		//ESPERA 2s
        wait(2);
    }
}

void controller_body(){
    while (true) {
		//RECEBE EVENTO DE MENSAGEM NA FILA DE CONTROLE
        osEvent control_evt = control_queue.get();
		//EXISTE UMA MENSAGEM, LER A MENSAGEM
        if (control_evt.status == osEventMessage) {
            message_t *message = (message_t*)control_evt.value.p;
            printf("Controller received %.2f\n", message->temperature);
			//SE A TEMPERATURA EST� FORA DO INPUT DESEJADO O PELTIER � LIGADO
            if(message->temperature > input) {
                peltier = 1;
            }
			//CASO CONTR�RIO, DESLIGA-SE O PELTIER
            else{
                peltier = 0;
            }
            control_mpool.free(message);
        }
    }
}

void alerter_body(){
	//THREAD QUE CONTROLA LED RGB. SE O INPUT EST� FORA DE UM RANGE ACEIT�VEL ACENDE-SE O LED VERMELHO PISCANDO
	//CASO CONTR�RIO, O LED VERDE PERMANECE ACESO
    while(true) {
        if(current_temp >= input + ALERT_RANGE || current_temp <= input - ALERT_RANGE) {
            red = !red;
            green = LED_OFF;

        }
        else{
            red = LED_OFF;
            green = LED_ON;
        }
        wait(0.2);
    }
}