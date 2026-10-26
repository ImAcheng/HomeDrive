namespace HomeDriveDesktop.MainPageGrids {
    partial class InputFormDialog {
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
            tbInput = new AntdUI.Input();
            btnConfirm = new AntdUI.Button();
            SuspendLayout();
            // 
            // pageHeader1
            // 
            pageHeader1.Dock = DockStyle.Top;
            pageHeader1.Location = new Point(0, 0);
            pageHeader1.Margin = new Padding(4);
            pageHeader1.MaximizeBox = false;
            pageHeader1.MinimizeBox = false;
            pageHeader1.Name = "pageHeader1";
            pageHeader1.ShowButton = true;
            pageHeader1.Size = new Size(293, 31);
            pageHeader1.TabIndex = 0;
            pageHeader1.Text = " ";
            // 
            // tbInput
            // 
            tbInput.Location = new Point(12, 49);
            tbInput.MaxLength = 500;
            tbInput.Name = "tbInput";
            tbInput.PlaceholderText = "Enter new folder's name!";
            tbInput.Size = new Size(269, 50);
            tbInput.TabIndex = 1;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(184, 105);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(97, 40);
            btnConfirm.TabIndex = 2;
            btnConfirm.Text = "Confirm";
            btnConfirm.Click += btnConfirm_Click;
            // 
            // InputFormDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(293, 158);
            Controls.Add(btnConfirm);
            Controls.Add(tbInput);
            Controls.Add(pageHeader1);
            Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4);
            Name = "InputFormDialog";
            Resizable = false;
            ResumeLayout(false);
        }

        #endregion

        private AntdUI.PageHeader pageHeader1;
        private AntdUI.Input tbInput;
        private AntdUI.Button btnConfirm;
    }
}