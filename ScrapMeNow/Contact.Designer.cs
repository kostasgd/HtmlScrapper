namespace ScrapMeNow
{
    partial class Contact
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contact));
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtSender = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtSenderPasswd = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.txtSmtpServer = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.txtPortNum = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.txtRecipient = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtSubject = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.btnBrowse = new MaterialSkin.Controls.MaterialRaisedButton();
            this.txtBody = new System.Windows.Forms.RichTextBox();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.btnCancel = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnSendMail = new MaterialSkin.Controls.MaterialRaisedButton();
            this.cbSSL = new MaterialSkin.Controls.MaterialCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(169, 524);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(109, 19);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Sender E-mail :";
            this.materialLabel1.Visible = false;
            // 
            // txtSender
            // 
            this.txtSender.Depth = 0;
            this.txtSender.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtSender.Hint = "";
            this.txtSender.Location = new System.Drawing.Point(293, 524);
            this.txtSender.MaxLength = 32767;
            this.txtSender.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSender.Name = "txtSender";
            this.txtSender.PasswordChar = '\0';
            this.txtSender.SelectedText = "";
            this.txtSender.SelectionLength = 0;
            this.txtSender.SelectionStart = 0;
            this.txtSender.Size = new System.Drawing.Size(247, 23);
            this.txtSender.TabIndex = 1;
            this.txtSender.TabStop = false;
            this.txtSender.Text = "scrapmenowtest@gmail.com";
            this.txtSender.UseSystemPasswordChar = false;
            this.txtSender.Validated += new System.EventHandler(this.txtSender_Validated);
            // 
            // txtSenderPasswd
            // 
            this.txtSenderPasswd.Depth = 0;
            this.txtSenderPasswd.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtSenderPasswd.Hint = "";
            this.txtSenderPasswd.Location = new System.Drawing.Point(293, 551);
            this.txtSenderPasswd.MaxLength = 32767;
            this.txtSenderPasswd.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSenderPasswd.Name = "txtSenderPasswd";
            this.txtSenderPasswd.PasswordChar = '*';
            this.txtSenderPasswd.SelectedText = "";
            this.txtSenderPasswd.SelectionLength = 0;
            this.txtSenderPasswd.SelectionStart = 0;
            this.txtSenderPasswd.Size = new System.Drawing.Size(247, 23);
            this.txtSenderPasswd.TabIndex = 3;
            this.txtSenderPasswd.TabStop = false;
            this.txtSenderPasswd.Text = "testinggmailsender";
            this.txtSenderPasswd.UseSystemPasswordChar = false;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(139, 551);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(133, 19);
            this.materialLabel2.TabIndex = 2;
            this.materialLabel2.Text = "Sender Password :";
            this.materialLabel2.Visible = false;
            // 
            // txtSmtpServer
            // 
            this.txtSmtpServer.Depth = 0;
            this.txtSmtpServer.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtSmtpServer.Hint = "";
            this.txtSmtpServer.Location = new System.Drawing.Point(293, 590);
            this.txtSmtpServer.MaxLength = 32767;
            this.txtSmtpServer.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSmtpServer.Name = "txtSmtpServer";
            this.txtSmtpServer.PasswordChar = '\0';
            this.txtSmtpServer.SelectedText = "";
            this.txtSmtpServer.SelectionLength = 0;
            this.txtSmtpServer.SelectionStart = 0;
            this.txtSmtpServer.Size = new System.Drawing.Size(219, 23);
            this.txtSmtpServer.TabIndex = 5;
            this.txtSmtpServer.TabStop = false;
            this.txtSmtpServer.UseSystemPasswordChar = false;
            this.txtSmtpServer.Visible = false;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(173, 590);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(98, 19);
            this.materialLabel3.TabIndex = 4;
            this.materialLabel3.Text = "Smtp Server :";
            this.materialLabel3.Visible = false;
            // 
            // txtPortNum
            // 
            this.txtPortNum.Depth = 0;
            this.txtPortNum.Hint = "";
            this.txtPortNum.Location = new System.Drawing.Point(293, 632);
            this.txtPortNum.MaxLength = 32767;
            this.txtPortNum.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPortNum.Name = "txtPortNum";
            this.txtPortNum.PasswordChar = '\0';
            this.txtPortNum.SelectedText = "";
            this.txtPortNum.SelectionLength = 0;
            this.txtPortNum.SelectionStart = 0;
            this.txtPortNum.Size = new System.Drawing.Size(54, 23);
            this.txtPortNum.TabIndex = 7;
            this.txtPortNum.TabStop = false;
            this.txtPortNum.UseSystemPasswordChar = false;
            this.txtPortNum.Visible = false;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(169, 632);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(102, 19);
            this.materialLabel4.TabIndex = 6;
            this.materialLabel4.Text = "Port Number :";
            this.materialLabel4.Visible = false;
            // 
            // txtRecipient
            // 
            this.txtRecipient.Depth = 0;
            this.txtRecipient.Hint = "";
            this.txtRecipient.Location = new System.Drawing.Point(293, 590);
            this.txtRecipient.MaxLength = 32767;
            this.txtRecipient.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.PasswordChar = '\0';
            this.txtRecipient.SelectedText = "";
            this.txtRecipient.SelectionLength = 0;
            this.txtRecipient.SelectionStart = 0;
            this.txtRecipient.Size = new System.Drawing.Size(305, 23);
            this.txtRecipient.TabIndex = 9;
            this.txtRecipient.TabStop = false;
            this.txtRecipient.Text = "konstantinos.georgiadis@windowslive.com";
            this.txtRecipient.UseSystemPasswordChar = false;
            this.txtRecipient.Visible = false;
            // 
            // txtSubject
            // 
            this.txtSubject.Depth = 0;
            this.txtSubject.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtSubject.Hint = "";
            this.txtSubject.Location = new System.Drawing.Point(143, 110);
            this.txtSubject.MaxLength = 32767;
            this.txtSubject.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.PasswordChar = '\0';
            this.txtSubject.SelectedText = "";
            this.txtSubject.SelectionLength = 0;
            this.txtSubject.SelectionStart = 0;
            this.txtSubject.Size = new System.Drawing.Size(247, 23);
            this.txtSubject.TabIndex = 11;
            this.txtSubject.TabStop = false;
            this.txtSubject.UseSystemPasswordChar = false;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(67, 110);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(67, 19);
            this.materialLabel6.TabIndex = 10;
            this.materialLabel6.Text = "Subject :";
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(420, 114);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(123, 19);
            this.materialLabel7.TabIndex = 12;
            this.materialLabel7.Text = "File Attachment :";
            // 
            // btnBrowse
            // 
            this.btnBrowse.AutoSize = true;
            this.btnBrowse.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBrowse.Depth = 0;
            this.btnBrowse.Icon = null;
            this.btnBrowse.Image = ((System.Drawing.Image)(resources.GetObject("btnBrowse.Image")));
            this.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowse.Location = new System.Drawing.Point(549, 106);
            this.btnBrowse.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Primary = true;
            this.btnBrowse.Size = new System.Drawing.Size(76, 36);
            this.btnBrowse.TabIndex = 13;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtBody
            // 
            this.txtBody.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtBody.Location = new System.Drawing.Point(143, 152);
            this.txtBody.MaxLength = 800;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(482, 307);
            this.txtBody.TabIndex = 14;
            this.txtBody.Text = "";
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(25, 152);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(107, 19);
            this.materialLabel8.TabIndex = 15;
            this.materialLabel8.Text = "The message :";
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCancel.Depth = 0;
            this.btnCancel.Icon = null;
            this.btnCancel.Location = new System.Drawing.Point(59, 423);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Primary = true;
            this.btnCancel.Size = new System.Drawing.Size(73, 36);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSendMail
            // 
            this.btnSendMail.AutoSize = true;
            this.btnSendMail.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSendMail.Depth = 0;
            this.btnSendMail.Icon = null;
            this.btnSendMail.Location = new System.Drawing.Point(643, 423);
            this.btnSendMail.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.Primary = true;
            this.btnSendMail.Size = new System.Drawing.Size(92, 36);
            this.btnSendMail.TabIndex = 17;
            this.btnSendMail.Text = "Send Mail";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // cbSSL
            // 
            this.cbSSL.AutoSize = true;
            this.cbSSL.Checked = true;
            this.cbSSL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSSL.Depth = 0;
            this.cbSSL.Font = new System.Drawing.Font("Roboto", 10F);
            this.cbSSL.Location = new System.Drawing.Point(293, 652);
            this.cbSSL.Margin = new System.Windows.Forms.Padding(0);
            this.cbSSL.MouseLocation = new System.Drawing.Point(-1, -1);
            this.cbSSL.MouseState = MaterialSkin.MouseState.HOVER;
            this.cbSSL.Name = "cbSSL";
            this.cbSSL.Ripple = true;
            this.cbSSL.Size = new System.Drawing.Size(54, 30);
            this.cbSSL.TabIndex = 18;
            this.cbSSL.Text = "SSL";
            this.cbSSL.UseVisualStyleBackColor = true;
            this.cbSSL.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(251, 490);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 17);
            this.label1.TabIndex = 19;
            this.label1.Text = "You can type your email on the body to get an answer.";
            // 
            // txtEmail
            // 
            this.txtEmail.Depth = 0;
            this.txtEmail.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.txtEmail.Hint = "";
            this.txtEmail.Location = new System.Drawing.Point(143, 72);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.Size = new System.Drawing.Size(247, 23);
            this.txtEmail.TabIndex = 21;
            this.txtEmail.TabStop = false;
            this.txtEmail.UseSystemPasswordChar = false;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(44, 72);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(90, 19);
            this.materialLabel5.TabIndex = 20;
            this.materialLabel5.Text = "Your Email :";
            // 
            // Contact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 472);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSSL);
            this.Controls.Add(this.btnSendMail);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.materialLabel8);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.txtRecipient);
            this.Controls.Add(this.txtPortNum);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.txtSmtpServer);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.txtSenderPasswd);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.txtSender);
            this.Controls.Add(this.materialLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Contact";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contact";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSender;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSenderPasswd;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSmtpServer;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPortNum;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtRecipient;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtSubject;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialRaisedButton btnBrowse;
        private System.Windows.Forms.RichTextBox txtBody;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private MaterialSkin.Controls.MaterialRaisedButton btnCancel;
        private MaterialSkin.Controls.MaterialRaisedButton btnSendMail;
        private MaterialSkin.Controls.MaterialCheckBox cbSSL;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtEmail;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
    }
}