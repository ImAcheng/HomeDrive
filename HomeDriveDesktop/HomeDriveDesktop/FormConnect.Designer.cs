namespace HomeDriveDesktop {
    partial class FormConnect {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            pageHeader1 = new AntdUI.PageHeader();
            tbIpPort = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnConnect = new AntdUI.Button();
            lsHistory = new ListBox();
            SuspendLayout();
            // 
            // pageHeader1
            // 
            pageHeader1.Dock = DockStyle.Top;
            pageHeader1.Location = new Point(0, 0);
            pageHeader1.MaximizeBox = false;
            pageHeader1.MinimizeBox = false;
            pageHeader1.Name = "pageHeader1";
            pageHeader1.ShowButton = true;
            pageHeader1.Size = new Size(300, 35);
            pageHeader1.TabIndex = 0;
            pageHeader1.Text = " ";
            // 
            // tbIpPort
            // 
            tbIpPort.BorderStyle = BorderStyle.FixedSingle;
            tbIpPort.Location = new Point(12, 312);
            tbIpPort.Name = "tbIpPort";
            tbIpPort.Size = new Size(276, 28);
            tbIpPort.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 289);
            label1.Name = "label1";
            label1.Size = new Size(169, 20);
            label1.TabIndex = 3;
            label1.Text = "Server IP && Port (API)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 58);
            label2.Name = "label2";
            label2.Size = new Size(158, 20);
            label2.TabIndex = 5;
            label2.Text = "Connection History:";
            // 
            // btnConnect
            // 
            btnConnect.DefaultBack = Color.RoyalBlue;
            btnConnect.ForeColor = Color.White;
            btnConnect.Location = new Point(12, 377);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(276, 45);
            btnConnect.TabIndex = 6;
            btnConnect.Text = "Connect";
            btnConnect.Click += btnConnect_Click;
            // 
            // lsHistory
            // 
            lsHistory.FormattingEnabled = true;
            lsHistory.ItemHeight = 20;
            lsHistory.Location = new Point(12, 81);
            lsHistory.Name = "lsHistory";
            lsHistory.Size = new Size(276, 204);
            lsHistory.TabIndex = 7;
            lsHistory.SelectedIndexChanged += lsHistory_SelectedIndexChanged;
            // 
            // FormConnect
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 450);
            Controls.Add(lsHistory);
            Controls.Add(btnConnect);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbIpPort);
            Controls.Add(pageHeader1);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormConnect";
            Resizable = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormConnect";
            Load += FormConnect_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private AntdUI.PageHeader pageHeader1;
        private TextBox tbIpPort;
        private Label label1;
        private Label label2;
        private AntdUI.Button btnConnect;
        private ListBox lsHistory;
    }
}