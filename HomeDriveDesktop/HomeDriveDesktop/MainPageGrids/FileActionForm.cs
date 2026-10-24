using AntdUI;

namespace HomeDriveDesktop.MainPageGrids {
    public partial class FileActionForm : Window {
        private readonly Guid _fileId;
        private System.Windows.Forms.Timer closeTimer;

        public FileActionForm(Guid fileId) {
            InitializeComponent();
            _fileId = fileId;

            closeTimer = new System.Windows.Forms.Timer();
            closeTimer.Interval = 100;
            closeTimer.Tick += CloseTimer_Tick;
            closeTimer.Start();
        }

        private async void CloseTimer_Tick(object? sender, EventArgs e) {
            if (_CheckIfFocused(this.Controls)) return;
            closeTimer.Stop();
            Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e) {
            closeTimer.Dispose();
            base.OnFormClosed(e);
        }

        private async void btnDownload_Click(object sender, EventArgs e) {
            await FileAPI.DownloadFileAsync(_fileId);
        }

        private async void btnDelete_Click(object sender, EventArgs e) {
            await FileAPI.DeleteFileOrDir(_fileId);
            await DriveDisplayer.Instance._LoadAndPutFiles(DriveDisplayer.Instance.CurrentDirId);
            this.Close();
        }

        private bool _CheckIfFocused(Control.ControlCollection ctrls) {
            if (this.Focused) return true;

            foreach (Control item in ctrls) {
                if (item.Focused) return true;
            }

            return false;
        }
    }
}
