using HomeDriveDesktop.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeDriveDesktop.MainPageGrids {
    public partial class DriveDisplayer : UserControl {
        public static DriveDisplayer Instance;
        public Guid? CurrentDirId = null;

        public DriveDisplayer() {
            InitializeComponent();
        }

        private async void DriveDisplayer_Load(object sender, EventArgs e) {
            Instance = this;

            // init at top root
            await _LoadAndPutFiles();
        }

        #region functions
        public async Task _LoadAndPutFiles(Guid? parentId = null) {
            panelFiles.Controls.Clear();

            var acc = FormMain.LoggedAccount;

            if (acc == null) return;

            var fileDirs = await FileAPI.GetFileDirFrom(parentId);

            if (fileDirs.Count == 0) return;

            panelFiles.SuspendLayout();
            fileDirs.ForEach(fd => {
                panelFiles.Controls.Add(new FileDirDisplayer(fd) { Dock = DockStyle.Top });
            });
            panelFiles.ResumeLayout();
        }

        Stack<Guid?> FolderStack = new Stack<Guid?>();
        public async Task GoToFolder(Guid targetId) {
            FolderStack.Push(CurrentDirId);
            CurrentDirId = targetId;
            await _LoadAndPutFiles(targetId);
        }

        public async Task GoPrevFolder() {
            if (FolderStack.Count == 0) return;

            CurrentDirId = FolderStack.Pop();
            await _LoadAndPutFiles(CurrentDirId);
        }

        FileActionForm? _fileActionForm;
        public void OpenFileAction(FileDirData _data) {
            _fileActionForm?.Close();
            _fileActionForm?.Dispose();

            _fileActionForm = new FileActionForm(_data.FileDirDataId) {
                StartPosition = FormStartPosition.Manual,
                Location = new Point(Cursor.Position.X - 10, Cursor.Position.Y - 10)
            };

            _fileActionForm.Show();
        }
        #endregion

        private async void btnUploadFile_Click(object sender, EventArgs e) {
            await FileAPI.UploadFile(CurrentDirId);
            await _LoadAndPutFiles(CurrentDirId);
        }

        private async void btnCreateDir_Click(object sender, EventArgs e) {
            await FileAPI.CreateDirectory(CurrentDirId);
            await _LoadAndPutFiles(CurrentDirId);
        }

        bool isShowingSearchResult = true;
        private async void btnShareFile_Click(object sender, EventArgs e) {
            isShowingSearchResult = true;

            string keyword = input1.Text;

            panelFiles.Controls.Clear();

            var fileDirs = await FileAPI.SearchFiles(keyword);

            if (fileDirs.Count == 0) return;

            panelFiles.SuspendLayout();
            fileDirs.ForEach(fd => {
                panelFiles.Controls.Add(new FileDirDisplayer(fd) { Dock = DockStyle.Top });
            });
            panelFiles.ResumeLayout();
        }

        // the search input field
        private async void input1_TextChanged(object sender, EventArgs e) {
            if (isShowingSearchResult && input1.Text.Trim().Length == 0) {
                await _LoadAndPutFiles(CurrentDirId);
                isShowingSearchResult = false;
            }
        }

        private async void btnPrev_Click(object sender, EventArgs e) {
            await GoPrevFolder();
        }
    }
}
