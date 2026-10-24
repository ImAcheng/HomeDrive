namespace HomeDriveDesktop.MainPageGrids {
    partial class FileDirDisplayer {
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
            lbIcon = new AntdUI.Label();
            label3 = new AntdUI.Label();
            lbFileDirName = new Label();
            lbCreateTime = new Label();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // lbIcon
            // 
            lbIcon.Dock = DockStyle.Left;
            lbIcon.Font = new Font("Microsoft JhengHei UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 136);
            lbIcon.Location = new Point(20, 0);
            lbIcon.Name = "lbIcon";
            lbIcon.PrefixSvg = "FolderOutlined";
            lbIcon.Size = new Size(33, 50);
            lbIcon.TabIndex = 0;
            lbIcon.Text = " ";
            // 
            // label3
            // 
            label3.Dock = DockStyle.Left;
            label3.Font = new Font("Microsoft JhengHei UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 136);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.PrefixSvg = "";
            label3.Size = new Size(20, 50);
            label3.TabIndex = 2;
            label3.Text = " ";
            // 
            // lbFileDirName
            // 
            lbFileDirName.Dock = DockStyle.Fill;
            lbFileDirName.Location = new Point(53, 0);
            lbFileDirName.Name = "lbFileDirName";
            lbFileDirName.Size = new Size(406, 50);
            lbFileDirName.TabIndex = 3;
            lbFileDirName.Text = "File / Dir";
            lbFileDirName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbCreateTime
            // 
            lbCreateTime.Dock = DockStyle.Right;
            lbCreateTime.Location = new Point(459, 0);
            lbCreateTime.Name = "lbCreateTime";
            lbCreateTime.Size = new Size(176, 50);
            lbCreateTime.TabIndex = 4;
            lbCreateTime.Text = "yyyy-MM-dd HH:mm";
            lbCreateTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(635, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(65, 50);
            panel1.TabIndex = 5;
            // 
            // FileDirDisplayer
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(lbFileDirName);
            Controls.Add(lbCreateTime);
            Controls.Add(panel1);
            Controls.Add(lbIcon);
            Controls.Add(label3);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
            Margin = new Padding(4);
            Name = "FileDirDisplayer";
            Size = new Size(700, 50);
            Load += FileDirDisplayer_Load;
            MouseClick += FileDirDisplayer_MouseClick;
            MouseEnter += FileDirDisplayer_MouseEnter;
            MouseLeave += FileDirDisplayer_MouseLeave;
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Label lbIcon;
        private AntdUI.Label label3;
        private Label lbFileDirName;
        private Label lbCreateTime;
        private Panel panel1;
    }
}
