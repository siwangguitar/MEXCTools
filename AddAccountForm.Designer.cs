namespace MEXCTools
{
    partial class AddAccountForm
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
            label1 = new Label();
            txtApiKey = new TextBox();
            panel1 = new Panel();
            btnClose = new Button();
            btnOK = new Button();
            txtApiSecret = new TextBox();
            label2 = new Label();
            txtEmail = new TextBox();
            label3 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 59);
            label1.Name = "label1";
            label1.Size = new Size(51, 17);
            label1.TabIndex = 0;
            label1.Text = "ApiKey:";
            // 
            // txtApiKey
            // 
            txtApiKey.Location = new Point(97, 56);
            txtApiKey.Name = "txtApiKey";
            txtApiKey.Size = new Size(281, 23);
            txtApiKey.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(btnOK);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 120);
            panel1.Name = "panel1";
            panel1.Size = new Size(454, 62);
            panel1.TabIndex = 3;
            // 
            // btnClose
            // 
            btnClose.Location = new Point(327, 25);
            btnClose.Margin = new Padding(2, 3, 2, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(73, 25);
            btnClose.TabIndex = 5;
            btnClose.Text = "取消(&C)";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(249, 25);
            btnOK.Margin = new Padding(2, 3, 2, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(73, 25);
            btnOK.TabIndex = 4;
            btnOK.Text = "确定(&O)";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // txtApiSecret
            // 
            txtApiSecret.Location = new Point(97, 82);
            txtApiSecret.Name = "txtApiSecret";
            txtApiSecret.PasswordChar = '*';
            txtApiSecret.Size = new Size(281, 23);
            txtApiSecret.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 85);
            label2.Name = "label2";
            label2.Size = new Size(66, 17);
            label2.TabIndex = 4;
            label2.Text = "ApiSecret:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(97, 30);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(281, 23);
            txtEmail.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 33);
            label3.Name = "label3";
            label3.Size = new Size(42, 17);
            label3.TabIndex = 6;
            label3.Text = "Email:";
            // 
            // AddAccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(454, 182);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(txtApiSecret);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(txtApiKey);
            Controls.Add(label1);
            Name = "AddAccountForm";
            Text = "AddAccountForm";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtApiKey;
        private Panel panel1;
        private Button btnClose;
        private Button btnOK;
        private TextBox txtApiSecret;
        private Label label2;
        private TextBox txtEmail;
        private Label label3;
    }
}