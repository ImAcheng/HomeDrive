using AntdUI;

namespace HomeDriveDesktop.MainPageGrids {
    public partial class InputFormDialog : Window {
        public InputFormDialog() {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        public static string? ShowInput() {
            using var form = new InputFormDialog();

            return form.ShowDialog() == DialogResult.OK ? form.tbInput.Text : null;
        }
    }
}
