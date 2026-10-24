using HomeDriveDesktop.MainPageGrids;

namespace HomeDriveDesktop {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
        }

        private DriveDisplayer driveDisplayer = new DriveDisplayer();

        private void MainPage_Load(object sender, EventArgs e) {
            driveDisplayer.Parent = splitter1.Panel2;
            driveDisplayer.Dock = DockStyle.Fill;
        }

        private void btnLogout_Click(object sender, EventArgs e) {
            FormMain.Instance.SetLoginPage();
        }
    }
}
