namespace HomeDriveDesktop.MainPageGrids {
    partial class FileActionForm {
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
            btnDownload = new AntdUI.Button();
            btnDelete = new AntdUI.Button();
            label1 = new Label();
            button1 = new AntdUI.Button();
            SuspendLayout();
            // 
            // btnDownload
            // 
            btnDownload.Dock = DockStyle.Top;
            btnDownload.IconSvg = "ArrowDownOutlined";
            btnDownload.Location = new Point(0, 0);
            btnDownload.Margin = new Padding(4);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(152, 44);
            btnDownload.TabIndex = 0;
            btnDownload.Text = "Download";
            btnDownload.Click += btnDownload_Click;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Top;
            btnDelete.ForeColor = Color.Red;
            btnDelete.IconSvg = "DeleteOutlined";
            btnDelete.Location = new Point(0, 88);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(152, 44);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.Click += btnDelete_Click;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.ForeColor = SystemColors.AppWorkspace;
            label1.Location = new Point(0, 132);
            label1.Name = "label1";
            label1.Size = new Size(152, 30);
            label1.TabIndex = 2;
            label1.Text = "Home Drive";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.IconSvg = "ShareAltOutlined";
            button1.Location = new Point(0, 44);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(152, 44);
            button1.TabIndex = 3;
            button1.Text = "Share";
            // 
            // FileActionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(152, 162);
            Controls.Add(label1);
            Controls.Add(btnDelete);
            Controls.Add(button1);
            Controls.Add(btnDownload);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "FileActionForm";
            Resizable = false;
            Text = "FileActionForm";
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Button btnDownload;
        private AntdUI.Button btnDelete;
        private Label label1;
        private AntdUI.Button button1;
    }
}