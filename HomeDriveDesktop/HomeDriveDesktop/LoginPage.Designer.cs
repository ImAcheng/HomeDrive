namespace HomeDriveDesktop {
    partial class LoginPage {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            btnLogin = new AntdUI.Button();
            tbPassword = new AntdUI.Input();
            tbUsername = new AntdUI.Input();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(tbPassword);
            panel1.Controls.Add(tbUsername);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(271, 168);
            panel1.Name = "panel1";
            panel1.Size = new Size(458, 279);
            panel1.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(72, 173);
            label4.Name = "label4";
            label4.Size = new Size(80, 20);
            label4.TabIndex = 6;
            label4.Text = "Password";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 118);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 5;
            label3.Text = "Username";
            // 
            // btnLogin
            // 
            btnLogin.DefaultBack = Color.RoyalBlue;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(72, 227);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(313, 44);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.Click += btnLogin_Click;
            // 
            // tbPassword
            // 
            tbPassword.Location = new Point(153, 158);
            tbPassword.Name = "tbPassword";
            tbPassword.PrefixText = "";
            tbPassword.Size = new Size(232, 50);
            tbPassword.SuffixText = "";
            tbPassword.TabIndex = 3;
            // 
            // tbUsername
            // 
            tbUsername.Location = new Point(153, 102);
            tbUsername.Name = "tbUsername";
            tbUsername.PrefixText = "";
            tbUsername.Size = new Size(232, 50);
            tbUsername.SuffixText = "";
            tbUsername.TabIndex = 2;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Microsoft JhengHei UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label2.ForeColor = SystemColors.GrayText;
            label2.Location = new Point(0, 42);
            label2.Name = "label2";
            label2.Size = new Size(458, 37);
            label2.TabIndex = 1;
            label2.Text = "Login to your account in this server.\r\n";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Microsoft JhengHei UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 136);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(458, 42);
            label1.TabIndex = 0;
            label1.Text = "HomeDrive";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "LoginPage";
            Size = new Size(1000, 615);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label4;
        private Label label3;
        private AntdUI.Button btnLogin;
        private AntdUI.Input tbPassword;
        private AntdUI.Input tbUsername;
        private Label label2;
        private Label label1;
    }
}
