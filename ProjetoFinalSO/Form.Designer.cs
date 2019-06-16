namespace ProjetoFinalSO
{
    partial class Form
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSend = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grpClient = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtReponse = new System.Windows.Forms.TextBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTemp = new System.Windows.Forms.Label();
            this.btnRestartServer = new System.Windows.Forms.Button();
            this.txtTemp = new System.Windows.Forms.TextBox();
            this.grpClient.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(166, 292);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Enviar";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 292);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Iniciar";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grpClient
            // 
            this.grpClient.Controls.Add(this.label2);
            this.grpClient.Controls.Add(this.label1);
            this.grpClient.Controls.Add(this.txtReponse);
            this.grpClient.Controls.Add(this.txtSend);
            this.grpClient.Controls.Add(this.btnSend);
            this.grpClient.Controls.Add(this.btnConnect);
            this.grpClient.Location = new System.Drawing.Point(12, 12);
            this.grpClient.Name = "grpClient";
            this.grpClient.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpClient.Size = new System.Drawing.Size(247, 321);
            this.grpClient.TabIndex = 2;
            this.grpClient.TabStop = false;
            this.grpClient.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Resposta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Digite um texto";
            // 
            // txtReponse
            // 
            this.txtReponse.Location = new System.Drawing.Point(6, 188);
            this.txtReponse.Multiline = true;
            this.txtReponse.Name = "txtReponse";
            this.txtReponse.ReadOnly = true;
            this.txtReponse.Size = new System.Drawing.Size(235, 98);
            this.txtReponse.TabIndex = 10;
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(6, 52);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(235, 98);
            this.txtSend.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTemp);
            this.groupBox2.Controls.Add(this.btnRestartServer);
            this.groupBox2.Controls.Add(this.txtTemp);
            this.groupBox2.Location = new System.Drawing.Point(268, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 321);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Servidor";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Location = new System.Drawing.Point(6, 36);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(67, 13);
            this.lblTemp.TabIndex = 8;
            this.lblTemp.Text = "Temperatura";
            // 
            // btnRestartServer
            // 
            this.btnRestartServer.Location = new System.Drawing.Point(6, 292);
            this.btnRestartServer.Name = "btnRestartServer";
            this.btnRestartServer.Size = new System.Drawing.Size(75, 23);
            this.btnRestartServer.TabIndex = 6;
            this.btnRestartServer.Text = "Reiniciar";
            this.btnRestartServer.UseVisualStyleBackColor = true;
            this.btnRestartServer.Click += new System.EventHandler(this.btnRestartServer_Click);
            // 
            // txtTemp
            // 
            this.txtTemp.Location = new System.Drawing.Point(6, 52);
            this.txtTemp.Name = "txtTemp";
            this.txtTemp.Size = new System.Drawing.Size(245, 20);
            this.txtTemp.TabIndex = 7;
            this.txtTemp.Text = "TEMPERATURA";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 345);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpClient);
            this.Name = "Form";
            this.Text = "Form1";
            this.grpClient.ResumeLayout(false);
            this.grpClient.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grpClient;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTemp;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Button btnRestartServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReponse;
        private System.Windows.Forms.TextBox txtSend;
    }
}

