using ProjetoFinalSO.Properties;
using SocketListener;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoFinalSO
{
    public partial class Form : System.Windows.Forms.Form
    {
        private readonly Settings settings = new Settings();
        private readonly AsynchronousSocketListener listener;
        private readonly SynchronousSenderClient sender;

        public Form()
        {
            InitializeComponent();
            listener = new AsynchronousSocketListener(IPAddress.Parse(settings.IPSource), settings.PortSource);
            sender = new SynchronousSenderClient(IPAddress.Parse(settings.IPDestination), settings.PortDestination);
            this.Load += (s, e) => StartListener();
            btnSend.Enabled = false;
        }

        private void StartListener()
        {
            if (listener != null)
            {
                listener.ShutdownListener();
            }
            listener.StartListening();
            listener.DataReceived += OnDataReceive;
        }

        private void StartSender()
        {
            if (sender != null)
            {
                sender.ShutdownClient();
            }
            sender.ConnectClient();
            sender.Response += OnSocketResponse;
        }

        private void OnSocketResponse(object sender, string e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                txtReponse.Text = e;
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing)
            {
                sender.ShutdownClient();
                listener.ShutdownListener(); 
            }
            base.Dispose(disposing);
        }


        private void OnDataReceive(object sender, SocketData e)
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                txtTemp.Text = e.Data;
            });

        }

        private void btnRestartServer_Click(object sender, EventArgs e)
        {
            StartListener();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.sender.SendMessage(txtSend.Text);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            StartSender();
            btnSend.Enabled = true;
        }
    }
}
