using HomeDriveDesktop.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            // Debug.WriteLine($"heightAdjust: {heightAdjust}");
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

            if (!(result?.Success ?? false)) {
                MessageBox.Show($"Login Failed: {result?.Message ?? "Unknow Error"}", "Home Drive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FormMain.LoggedAccount = result.Account;
            MessageBox.Show($"Welcome back, {result.Account.Username}");
            FormMain.Instance.SetMainPage();
        }
    }
}
