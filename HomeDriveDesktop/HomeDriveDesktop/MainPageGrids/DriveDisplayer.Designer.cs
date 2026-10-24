namespace HomeDriveDesktop.MainPageGrids {
    partial class DriveDisplayer {
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
            input1 = new AntdUI.Input();
            panel1 = new AntdUI.Panel();
            lbDirs = new AntdUI.Label();
            btnPrev = new Button();
            btnUploadFile = new AntdUI.Button();
            btnCreateDir = new AntdUI.Button();
            btnShareFile = new AntdUI.Button();
            panelFiles = new AntdUI.Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // input1
            // 
            input1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            input1.Location = new Point(3, 14);
            input1.Name = "input1";
            input1.PlaceholderText = "Search your files!";
            input1.Size = new Size(549, 60);
            input1.TabIndex = 1;
            input1.TextChanged += input1_TextChanged;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.Back = SystemColors.ControlDark;
            panel1.Controls.Add(lbDirs);
            panel1.Controls.Add(btnPrev);
            panel1.Location = new Point(9, 80);
            panel1.Name = "panel1";
            panel1.Radius = 5;
            panel1.Size = new Size(785, 33);
            panel1.TabIndex = 5;
            panel1.Text = "panel1";
            // 
            // lbDirs
            // 
            lbDirs.BackColor = Color.Transparent;
            lbDirs.Dock = DockStyle.Fill;
            lbDirs.Location = new Point(33, 0);
            lbDirs.Name = "lbDirs";
            lbDirs.Prefix = "  ";
            lbDirs.Size = new Size(752, 33);
            lbDirs.TabIndex = 0;
            lbDirs.Text = "Dir / Dir / File";
            lbDirs.Visible = false;
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.Transparent;
            btnPrev.Dock = DockStyle.Left;
            btnPrev.FlatAppearance.BorderSize = 0;
            btnPrev.FlatStyle = FlatStyle.Flat;
            btnPrev.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 136);
            btnPrev.ForeColor = Color.FromArgb(64, 64, 64);
            btnPrev.Location = new Point(0, 0);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(33, 33);
            btnPrev.TabIndex = 1;
            btnPrev.Text = "<";
            btnPrev.UseVisualStyleBackColor = false;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnUploadFile
            // 
            btnUploadFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUploadFile.IconSvg = "FileAddOutlined";
            btnUploadFile.Location = new Point(671, 14);
            btnUploadFile.Name = "btnUploadFile";
            btnUploadFile.Size = new Size(60, 60);
            btnUploadFile.TabIndex = 6;
            btnUploadFile.Click += btnUploadFile_Click;
            // 
            // btnCreateDir
            // 
            btnCreateDir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateDir.IconSvg = "FolderAddOutlined";
            btnCreateDir.Location = new Point(737, 14);
            btnCreateDir.Name = "btnCreateDir";
            btnCreateDir.Size = new Size(60, 60);
            btnCreateDir.TabIndex = 7;
            btnCreateDir.Click += btnCreateDir_Click;
            // 
            // btnShareFile
            // 
            btnShareFile.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnShareFile.IconSvg = "SearchOutlined";
            btnShareFile.Location = new Point(558, 14);
            btnShareFile.Name = "btnShareFile";
            btnShareFile.Size = new Size(60, 60);
            btnShareFile.TabIndex = 8;
            btnShareFile.Click += btnShareFile_Click;
            // 
            // panelFiles
            // 
            panelFiles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFiles.AutoScroll = true;
            panelFiles.Back = SystemColors.ControlLight;
            panelFiles.Location = new Point(9, 119);
            panelFiles.Name = "panelFiles";
            panelFiles.Radius = 5;
            panelFiles.Size = new Size(785, 482);
            panelFiles.TabIndex = 9;
            panelFiles.Text = "panel1";
            // 
            // DriveDisplayer
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelFiles);
            Controls.Add(btnShareFile);
            Controls.Add(btnCreateDir);
            Controls.Add(btnUploadFile);
            Controls.Add(panel1);
            Controls.Add(input1);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "DriveDisplayer";
            Size = new Size(800, 615);
            Load += DriveDisplayer_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private AntdUI.Input input1;
        private AntdUI.Panel panel1;
        private AntdUI.Label lbDirs;
        private Button btnPrev;
        private AntdUI.Button btnUploadFile;
        private AntdUI.Button btnCreateDir;
        private AntdUI.Button btnShareFile;
        private AntdUI.Panel panelFiles;
    }
}
