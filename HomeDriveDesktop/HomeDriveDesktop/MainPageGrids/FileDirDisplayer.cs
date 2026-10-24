using AntdUI;
using HomeDriveDesktop.DataModel;

namespace HomeDriveDesktop.MainPageGrids {
    public partial class FileDirDisplayer : UserControl {
        private readonly FileDirData _data;

        public FileDirDisplayer(FileDirData data) {
            InitializeComponent();
            _data = data;
        }

        private void FileDirDisplayer_Load(object sender, EventArgs e) {
            lbFileDirName.Text = _data.FileDirName;
            lbCreateTime.Text = _data.CreateDateTime.ToString("yyyy-MM-dd HH:mm");
            lbIcon.PrefixSvg = _data.Type == 0 ? "FileFilled" : "FolderFilled";
            _AddCommonEvents(this);
        }


        private void FileDirDisplayer_MouseEnter(object sender, EventArgs e) {
            this.BackColor = Color.LightGray;
        }

        private void FileDirDisplayer_MouseLeave(object sender, EventArgs e) {
            this.BackColor = Color.FromName("ControlLight");
        }

        private async void FileDirDisplayer_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                DriveDisplayer.Instance.OpenFileAction(_data);
            }
            else if (e.Button == MouseButtons.Left) {
                if (_data.Type == 0) return;
                await DriveDisplayer.Instance.GoToFolder(_data.FileDirDataId);
            }
        }

        private void _AddCommonEvents(Control control) {
            foreach (Control ctrl in control.Controls) {
                ctrl.MouseEnter += FileDirDisplayer_MouseEnter;
                ctrl.MouseLeave += FileDirDisplayer_MouseLeave;
                ctrl.MouseClick += FileDirDisplayer_MouseClick;

                if (ctrl.HasChildren) _AddCommonEvents(ctrl);
            }
        }
    }
}
