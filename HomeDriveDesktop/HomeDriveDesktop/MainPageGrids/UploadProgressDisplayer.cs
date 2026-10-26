using AntdUI;

namespace HomeDriveDesktop.MainPageGrids {
    public partial class UploadProgressDisplayer : Window {
        public UploadProgressDisplayer() {
            InitializeComponent();
        }

        private void UploadProgressDisplayer_Load(object sender, EventArgs e) {
            this.TopMost = true;

            // set position to bottom-left of main window
            _SetPos();

            FormMain.Instance.SizeChanged += (e, v) => {
                _SetPos();
            };

            FormMain.Instance.Move += (e, v) => {
                _SetPos();
            };
        }

        private void _SetPos() {
            this.Location = new Point(
                    FormMain.Instance.Right - 20 - this.Width,
                    FormMain.Instance.Bottom - 20 - this.Height
                );
        }

        public void AddBar(params UploadProgressBar[] bars) {
            foreach (var item in bars) {
                item.Parent = panel2;
                item.Dock = DockStyle.Top;
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            panel2.Controls.Clear();
            this.Hide();
        }
    }
}
