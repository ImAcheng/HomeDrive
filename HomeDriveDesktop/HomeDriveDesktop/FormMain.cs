using AntdUI;
using HomeDriveDesktop.DataModel;

namespace HomeDriveDesktop {
    public partial class FormMain : Window {
        public FormMain() {
            InitializeComponent();
        }

        public static FormMain Instance;
        public static LoginPage? loginPage;
        private static MainPage? mainPage;

        public static HttpClient ApiClient = new HttpClient() { Timeout = TimeSpan.FromHours(2) };
        public static Account? LoggedAccount;

        private void FormMain_Load(object sender, EventArgs e) {
            Instance = this;
            this.Max();
            using var connForm = new FormConnect();
            connForm.ShowDialog();

            loginPage = new LoginPage() {
                Parent = panelMain,
                Dock = DockStyle.Fill
            }; loginPage.Show();
        }

        #region functions
        public void SetMainPage() {
            mainPage = new MainPage() {
                Dock = DockStyle.Fill,
                Parent = panelMain
            };
            mainPage.BringToFront();
            loginPage?.Dispose();
            loginPage = null;
        }

        public void SetLoginPage() {
            loginPage = new LoginPage() {
                Dock = DockStyle.Fill,
                Parent = panelMain
            };
            loginPage.BringToFront();
            mainPage?.Dispose();
            mainPage = null;
        }
        #endregion
    }
}
