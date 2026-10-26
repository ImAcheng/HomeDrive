namespace HomeDriveDesktop.MainPageGrids {
    partial class UploadProgressBar {
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
            icoState = new AntdUI.IconState();
            lbFileName = new AntdUI.Label();
            spin1 = new AntdUI.Spin();
            SuspendLayout();
            // 
            // icoState
            // 
            icoState.Dock = DockStyle.Left;
            icoState.Location = new Point(0, 0);
            icoState.Margin = new Padding(4);
            icoState.Name = "icoState";
            icoState.Padding = new Padding(14, 13, 14, 13);
            icoState.Size = new Size(50, 50);
            icoState.State = AntdUI.TType.Info;
            icoState.TabIndex = 0;
            icoState.Text = "Progress";
            // 
            // lbFileName
            // 
            lbFileName.Dock = DockStyle.Fill;
            lbFileName.Location = new Point(50, 0);
            lbFileName.Margin = new Padding(4);
            lbFileName.Name = "lbFileName";
            lbFileName.Size = new Size(200, 50);
            lbFileName.TabIndex = 4;
            lbFileName.Text = "Filename here :D";
            // 
            // spin1
            // 
            spin1.CirSize = 25;
            spin1.CirWidth = 3;
            spin1.ColorScheme = AntdUI.TAMode.Dark;
            spin1.Dock = DockStyle.Right;
            spin1.Location = new Point(250, 0);
            spin1.Name = "spin1";
            spin1.Padding = new Padding(0, 25, 0, 0);
            spin1.Size = new Size(50, 50);
            spin1.TabIndex = 5;
            spin1.Text = "";
            // 
            // UploadProgressBar
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbFileName);
            Controls.Add(spin1);
            Controls.Add(icoState);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "UploadProgressBar";
            Size = new Size(300, 50);
            Load += UploadProgressBar_Load;
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.IconState icoState;
        private AntdUI.Label lbFileName;
        private AntdUI.Spin spin1;
    }
}
