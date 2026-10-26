using AntdUI;
using HomeDriveDesktop.Helpers;

namespace HomeDriveDesktop {
    public partial class LoginPage : UserControl {
        public LoginPage() {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);

            // center the login field (with a variable height adjustment)
            int heightAdjust = Math.Clamp((int)((float)(this.Size.Height / 1080F * 80)), 0, 80);
            panel1.Location = new Point(this.Size.Width / 2 - panel1.Width / 2, this.Size.Height / 2 - panel1.Height / 2 - heightAdjust);
        }

        private async void btnLogin_Click(object sender, EventArgs e) {
            if (FormMain.ApiClient.BaseAddress == null) {
                using var fcd = new FormConnect();
                fcd.ShowDialog();
                return;
            }

            btnLogin.Loading = true;

            string uname = tbUsername.Text.TrimStart().TrimEnd().ToLower();
            string pwd = tbPassword.Text.TrimStart().TrimEnd();

            var result = await AccountAPI.LoginTo(uname, pwd);

            btnLogin.Loading = false;

            // normally, result.Account is null shouldn't be null.
            // if it is, it's because I wrote a bad api.
            if (!(result?.Success ?? false) || result.Account == null) {
                HDMsgBox.Show(FormMain.Instance, $"Login Failed: {result?.Message ?? "Unknow Error"}", TType.Error);
                return;
            }

            FormMain.LoggedAccount = result.Account;
            HDMsgBox.Show(FormMain.Instance, $"Welcome back, {result.Account.Username}", TType.Success);
            FormMain.Instance.SetMainPage();
        }
    }
}
