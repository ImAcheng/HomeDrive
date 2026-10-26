using AntdUI;
using HomeDriveDesktop.Helpers;

namespace HomeDriveDesktop {
    public partial class FormConnect : Window {
        public FormConnect() {
            InitializeComponent();
        }

        private static readonly string _ConnPropPath = Path.Combine(Application.CommonAppDataPath, "ConnHistory.txt");
        private List<string> _ConnHistory;

        private void FormConnect_Load(object sender, EventArgs e) {
            if (Path.Exists(_ConnPropPath)) {
                _ConnHistory = File.ReadAllLines(_ConnPropPath).ToList();
                lsHistory.Items.AddRange(_ConnHistory.ToArray());
            }
            else
                File.Create(_ConnPropPath).Close();
        }

        private async void btnConnect_Click(object sender, EventArgs e) {
            btnConnect.Loading = true;
            btnConnect.Text = "Connecting...";

            string ip_port = _IpPreProcess(tbIpPort.Text);
            var crs = await _TestConnection(ip_port);

            btnConnect.Loading = false;
            btnConnect.Text = "Connect";

            if (!crs.Success) {
                HDMsgBox.Show(this, crs.Message ?? string.Empty, TType.Error);
                return;
            }

            // store data here
            try {
                if (_ConnHistory.Any(x => x.Equals(ip_port)))
                    _ConnHistory.Remove(ip_port);
                _ConnHistory.Insert(0, ip_port);
                if (!File.Exists(_ConnPropPath))
                    File.Create(_ConnPropPath).Close();
                File.WriteAllText(_ConnPropPath, string.Join("\n", _ConnHistory));

                FormMain.ApiClient.BaseAddress = new Uri($"http://{ip_port}");
                Notification.success(FormMain.Instance, "Home Drive", "Connected!", autoClose: 3);
            }
            catch { }

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        ///     Test if application could connect to API
        /// </summary>
        private async Task<ConnectResult> _TestConnection(string ip_port) {
            using var client = new HttpClient();

            try {
                await client.GetAsync($"http://{ip_port}");
            }
            catch (HttpRequestException) {
                return new ConnectResult() { Success = false, Message = "Oops, HomeDrive failed to connect the target." };
            }
            catch (InvalidOperationException) {
                return new ConnectResult() { Success = false, Message = "Oops, your ip address format is not correct." };
            }
            catch (Exception ex) {
                return new ConnectResult() { Success = false, Message = $"Oops, we catched a problem:\n{ex.Message}" };
            }

            return new ConnectResult() { Success = true };
        }

        /// <summary>
        /// Simply turn "." to "localhost" and return
        /// </summary>
        private string _IpPreProcess(string ip_port) {
            try {
                string[] parts = ip_port.Split(':');
                string ip = parts[0].Trim(), port = parts[1].Trim();
                if (ip.Equals(".")) ip = "localhost";
                return $"{ip}:{port}";
            }
            catch {
                return string.Empty;
            }
        }

        private void lsHistory_SelectedIndexChanged(object sender, EventArgs e) {
            tbIpPort.Text = lsHistory.SelectedItem?.ToString() ?? string.Empty;
        }
    }

    public class ConnectResult {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
