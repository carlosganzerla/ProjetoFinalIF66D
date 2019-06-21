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
            this.btnConnect = new System.Windows.Forms.Button();
            this.grpClient = new System.Windows.Forms.GroupBox();
            this.lblMin = new System.Windows.Forms.Label();
            this.trbTemp = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.txtReponse = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTemp = new System.Windows.Forms.Label();
            this.btnRestartServer = new System.Windows.Forms.Button();
            this.txtTemp = new System.Windows.Forms.TextBox();
            this.grpClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbTemp)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 292);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Conectar";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grpClient
            // 
            this.grpClient.Controls.Add(this.lblMin);
            this.grpClient.Controls.Add(this.trbTemp);
            this.grpClient.Controls.Add(this.label2);
            this.grpClient.Controls.Add(this.lblMax);
            this.grpClient.Controls.Add(this.txtReponse);
            this.grpClient.Controls.Add(this.btnConnect);
            this.grpClient.Location = new System.Drawing.Point(12, 12);
            this.grpClient.Name = "grpClient";
            this.grpClient.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpClient.Size = new System.Drawing.Size(247, 321);
            this.grpClient.TabIndex = 2;
            this.grpClient.TabStop = false;
            this.grpClient.Text = "Controle de Temperatura";
            // 
            // lblMin
            // 
            this.lblMin.AutoSize = true;
            this.lblMin.Location = new System.Drawing.Point(160, 189);
            this.lblMin.Name = "lblMin";
            this.lblMin.Size = new System.Drawing.Size(27, 13);
            this.lblMin.TabIndex = 12;
            this.lblMin.Text = "MIN";
            // 
            // trbTemp
            // 
            this.trbTemp.Location = new System.Drawing.Point(196, 19);
            this.trbTemp.Name = "trbTemp";
            this.trbTemp.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trbTemp.Size = new System.Drawing.Size(45, 183);
            this.trbTemp.TabIndex = 9;
            this.trbTemp.MouseCaptureChanged += new System.EventHandler(this.trbTemp_MouseCaptureChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Resposta";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(160, 19);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(30, 13);
            this.lblMax.TabIndex = 9;
            this.lblMax.Text = "MAX";
            // 
            // txtReponse
            // 
            this.txtReponse.Location = new System.Drawing.Point(6, 222);
            this.txtReponse.Multiline = true;
            this.txtReponse.Name = "txtReponse";
            this.txtReponse.ReadOnly = true;
            this.txtReponse.Size = new System.Drawing.Size(235, 64);
            this.txtReponse.TabIndex = 10;
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
            this.groupBox2.Text = "Dados de temperatura";
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
            this.ClientSize = new System.Drawing.Size(539, 345);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpClient);
            this.Name = "Form";
            this.Text = "Form1";
            this.grpClient.ResumeLayout(false);
            this.grpClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbTemp)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grpClient;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTemp;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Button btnRestartServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.TextBox txtReponse;
        private System.Windows.Forms.TrackBar trbTemp;
        private System.Windows.Forms.Label lblMin;
    }
}

