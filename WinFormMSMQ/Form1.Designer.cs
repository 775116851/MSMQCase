namespace WinFormMSMQ
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAllSend = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtYJZW = new System.Windows.Forms.TextBox();
            this.txtYJZT = new System.Windows.Forms.TextBox();
            this.txtSJRDZ = new System.Windows.Forms.TextBox();
            this.txtFJRMM = new System.Windows.Forms.TextBox();
            this.txtFJRDZ = new System.Windows.Forms.TextBox();
            this.txtSMTP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSWSend = new System.Windows.Forms.Button();
            this.btnSWAllSend = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAllSend
            // 
            this.btnAllSend.Location = new System.Drawing.Point(14, 244);
            this.btnAllSend.Name = "btnAllSend";
            this.btnAllSend.Size = new System.Drawing.Size(270, 23);
            this.btnAllSend.TabIndex = 27;
            this.btnAllSend.Text = "从消息队列中发送邮件";
            this.btnAllSend.UseVisualStyleBackColor = true;
            this.btnAllSend.Click += new System.EventHandler(this.btnAllSend_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(14, 183);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(69, 51);
            this.btnSend.TabIndex = 26;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtYJZW
            // 
            this.txtYJZW.Location = new System.Drawing.Point(90, 154);
            this.txtYJZW.Multiline = true;
            this.txtYJZW.Name = "txtYJZW";
            this.txtYJZW.Size = new System.Drawing.Size(194, 80);
            this.txtYJZW.TabIndex = 25;
            this.txtYJZW.Text = "这是测试正文";
            // 
            // txtYJZT
            // 
            this.txtYJZT.Location = new System.Drawing.Point(90, 125);
            this.txtYJZT.Name = "txtYJZT";
            this.txtYJZT.Size = new System.Drawing.Size(194, 21);
            this.txtYJZT.TabIndex = 24;
            this.txtYJZT.Text = "测试的";
            // 
            // txtSJRDZ
            // 
            this.txtSJRDZ.Location = new System.Drawing.Point(90, 96);
            this.txtSJRDZ.Name = "txtSJRDZ";
            this.txtSJRDZ.Size = new System.Drawing.Size(194, 21);
            this.txtSJRDZ.TabIndex = 23;
            this.txtSJRDZ.Text = "540936548@qq.com";
            // 
            // txtFJRMM
            // 
            this.txtFJRMM.Location = new System.Drawing.Point(90, 67);
            this.txtFJRMM.Name = "txtFJRMM";
            this.txtFJRMM.PasswordChar = '*';
            this.txtFJRMM.Size = new System.Drawing.Size(194, 21);
            this.txtFJRMM.TabIndex = 22;
            this.txtFJRMM.Text = "lxf599";
            // 
            // txtFJRDZ
            // 
            this.txtFJRDZ.Location = new System.Drawing.Point(90, 38);
            this.txtFJRDZ.Name = "txtFJRDZ";
            this.txtFJRDZ.Size = new System.Drawing.Size(194, 21);
            this.txtFJRDZ.TabIndex = 21;
            this.txtFJRDZ.Text = "1779059767@qq.com";
            // 
            // txtSMTP
            // 
            this.txtSMTP.Location = new System.Drawing.Point(90, 9);
            this.txtSMTP.Name = "txtSMTP";
            this.txtSMTP.Size = new System.Drawing.Size(194, 21);
            this.txtSMTP.TabIndex = 20;
            this.txtSMTP.Text = "smtp.qq.com";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "邮件正文:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "邮件主题:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "收件人地址:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "发件人密码:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "发件人地址:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "SMTP主机:";
            // 
            // btnSWSend
            // 
            this.btnSWSend.Location = new System.Drawing.Point(12, 309);
            this.btnSWSend.Name = "btnSWSend";
            this.btnSWSend.Size = new System.Drawing.Size(113, 23);
            this.btnSWSend.TabIndex = 28;
            this.btnSWSend.Text = "发送(事务型队列)";
            this.btnSWSend.UseVisualStyleBackColor = true;
            this.btnSWSend.Click += new System.EventHandler(this.btnSWSend_Click);
            // 
            // btnSWAllSend
            // 
            this.btnSWAllSend.Location = new System.Drawing.Point(131, 309);
            this.btnSWAllSend.Name = "btnSWAllSend";
            this.btnSWAllSend.Size = new System.Drawing.Size(153, 23);
            this.btnSWAllSend.TabIndex = 29;
            this.btnSWAllSend.Text = "从消息队列中发送邮件";
            this.btnSWAllSend.UseVisualStyleBackColor = true;
            this.btnSWAllSend.Click += new System.EventHandler(this.btnSWAllSend_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 30;
            this.button1.Text = "异步接收";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 417);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSWAllSend);
            this.Controls.Add(this.btnSWSend);
            this.Controls.Add(this.btnAllSend);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtYJZW);
            this.Controls.Add(this.txtYJZT);
            this.Controls.Add(this.txtSJRDZ);
            this.Controls.Add(this.txtFJRMM);
            this.Controls.Add(this.txtFJRDZ);
            this.Controls.Add(this.txtSMTP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "本地发送接收消息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAllSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtYJZW;
        private System.Windows.Forms.TextBox txtYJZT;
        private System.Windows.Forms.TextBox txtSJRDZ;
        private System.Windows.Forms.TextBox txtFJRMM;
        private System.Windows.Forms.TextBox txtFJRDZ;
        private System.Windows.Forms.TextBox txtSMTP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSWSend;
        private System.Windows.Forms.Button btnSWAllSend;
        private System.Windows.Forms.Button button1;
    }
}

