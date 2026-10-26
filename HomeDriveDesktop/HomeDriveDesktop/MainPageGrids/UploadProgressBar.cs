using AntdUI;

namespace HomeDriveDesktop.MainPageGrids {
    public partial class UploadProgressBar : UserControl {
        private readonly string _FileName;

        public UploadProgressBar(string fp) {
            InitializeComponent();
            _FileName = Path.GetFileName(fp);
        }

        private void UploadProgressBar_Load(object sender, EventArgs e) {
            lbFileName.Text = _FileName;
        }

        public void SetStatusTo(TType state, bool loading) {
            spin1.Visible = loading;
            icoState.State = state;
        }
    }
}
