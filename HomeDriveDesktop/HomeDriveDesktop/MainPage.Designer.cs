namespace HomeDriveDesktop {
    partial class MainPage {
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
            splitter1 = new AntdUI.Splitter();
            btnLogout = new Button();
            btnGoShared = new Button();
            btnGoMyDrive = new Button();
            ((System.ComponentModel.ISupportInitialize)splitter1).BeginInit();
            splitter1.Panel1.SuspendLayout();
            splitter1.SuspendLayout();
            SuspendLayout();
            // 
            // splitter1
            // 
            splitter1.Dock = DockStyle.Fill;
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            // 
            // splitter1.Panel1
            // 
            splitter1.Panel1.BackColor = SystemColors.ControlLight;
            splitter1.Panel1.Controls.Add(btnLogout);
            splitter1.Panel1.Controls.Add(btnGoShared);
            splitter1.Panel1.Controls.Add(btnGoMyDrive);
            splitter1.Size = new Size(1000, 615);
            splitter1.SplitterDistance = 200;
            splitter1.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = SystemColors.Control;
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Location = new Point(0, 565);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(200, 50);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Log out";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnGoShared
            // 
            btnGoShared.BackColor = SystemColors.Control;
            btnGoShared.Dock = DockStyle.Top;
            btnGoShared.FlatAppearance.BorderSize = 0;
            btnGoShared.FlatStyle = FlatStyle.Flat;
            btnGoShared.Location = new Point(0, 50);
            btnGoShared.Name = "btnGoShared";
            btnGoShared.Size = new Size(200, 50);
            btnGoShared.TabIndex = 1;
            btnGoShared.Text = "Shared with Me";
            btnGoShared.UseVisualStyleBackColor = false;
            // 
            // btnGoMyDrive
            // 
            btnGoMyDrive.BackColor = SystemColors.Control;
            btnGoMyDrive.Dock = DockStyle.Top;
            btnGoMyDrive.FlatAppearance.BorderSize = 0;
            btnGoMyDrive.FlatStyle = FlatStyle.Flat;
            btnGoMyDrive.Location = new Point(0, 0);
            btnGoMyDrive.Name = "btnGoMyDrive";
            btnGoMyDrive.Size = new Size(200, 50);
            btnGoMyDrive.TabIndex = 0;
            btnGoMyDrive.Text = "My Drive";
            btnGoMyDrive.UseVisualStyleBackColor = false;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitter1);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "MainPage";
            Size = new Size(1000, 615);
            Load += MainPage_Load;
            splitter1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitter1).EndInit();
            splitter1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.Splitter splitter1;
        private Button btnGoMyDrive;
        private Button btnGoShared;
        private Button btnLogout;
    }
}
