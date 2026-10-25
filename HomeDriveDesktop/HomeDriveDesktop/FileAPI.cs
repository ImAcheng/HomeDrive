using AntdUI;
using HomeDriveDesktop.DataModel;
using HomeDriveDesktop.MainPageGrids;
using Polly;
using System.Diagnostics;
using System.Net.Http.Json;

namespace HomeDriveDesktop {
    public static class FileAPI {
        public static async Task<List<FileDirData>> GetFileDirFrom(Guid? parentId = null) {
            try {
                var resp = await FormMain.ApiClient.PostAsJsonAsync($"api/filedir/get-files",
                    new GetFileDirData() { OwnerId = FormMain.LoggedAccount.AccountId, ParentId = parentId });

                if (resp == null || !resp.IsSuccessStatusCode)
                    return new List<FileDirData>(0);

                var ctx = await resp.Content.ReadFromJsonAsync<List<FileDirData>>();

                return ctx == null ? new List<FileDirData>(0) : ctx;
            }
            catch (HttpRequestException) {
                return new List<FileDirData>(0);
            }
        }

        /// <summary>
        /// Select files and upload them one by one (to prevent one failed all failed problem).
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static async Task<bool> UploadFile(Guid? parentId) {
            if (AccountAPI.IsNull()) return false;

            using var ofd = new OpenFileDialog() {
                Multiselect = true
            };

            if (ofd.ShowDialog() != DialogResult.OK) return false;

            var filePaths = ofd.FileNames;

            bool atLeastOneFileWasUploaded = false;
            foreach (string fp in filePaths) {
                var policy = await Policy.Handle<HttpRequestException>()
                .OrResult<bool>(rs => !rs)
                .RetryAsync(3, (ex, rc) => {
                    Notification.close_all();
                    Notification.warn(FormMain.Instance, "Home Drive",
                        $"Retrying to upload\n{fp}.", autoClose: 2);
                })
                .ExecuteAndCaptureAsync(() => _UploadToServer(parentId, fp));

                if (policy.Outcome == OutcomeType.Failure) {
                    Notification.close_all();
                    Notification.error(FormMain.Instance, "Home Drive", $"Sorrry, but we can't upload\n{fp}", autoClose:2);
                }
                else {
                    atLeastOneFileWasUploaded = true;
                }
            }

            return atLeastOneFileWasUploaded;
        }

        private static async Task<bool> _UploadToServer(Guid? parentId, string fp) {
            using var form = new MultipartFormDataContent();

            using var fileStream = new FileStream(fp, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 8192, useAsync: true);
            using var content = new StreamContent(fileStream);
            form.Add(content, "file", Path.GetFileName(fp));

            var resp = await FormMain.ApiClient.PostAsync(
                $"api/filedir/upload-file/{FormMain.LoggedAccount.AccountId}/{parentId}",
                form
            );

            // this should be empty if it was success
            Debug.WriteLine($"[Debug] {await resp.Content.ReadAsStringAsync()}");

            return resp.IsSuccessStatusCode;
        }

        public static async Task DeleteFileOrDir(Guid targetId) {
            var resp = await FormMain.ApiClient.PostAsync($"api/filedir/delete/{FormMain.LoggedAccount.AccountId}/{targetId}", null);

            if (!resp.IsSuccessStatusCode) {
                MessageBox.Show($"Failed to delete.\nReason: {await resp.Content.ReadAsStringAsync()}");
            }
        }

        public static async Task CreateDirectory(Guid? parentId) {
            string? name = InputFormDialog.ShowInput();
            if (string.IsNullOrWhiteSpace(name)) return;

            string url =
                $"api/filedir/create-dir/{FormMain.LoggedAccount.AccountId}?name={Uri.EscapeDataString(name)}";

            if (parentId.HasValue)
                url += $"&parentId={parentId.Value}";

            var resp = await FormMain.ApiClient.PostAsync(url, null);

            if (!resp.IsSuccessStatusCode) {
                MessageBox.Show(
                    $"Failed to create directory.\n{await resp.Content.ReadAsStringAsync()}"
                );
            }
        }

        public static async Task DownloadFileAsync(Guid id) {
            string savePath = Path.Combine("Downloads/");

            if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);

            try {
                using var resp = await FormMain.ApiClient.GetAsync($"api/filedir/download/{id}");
                resp.EnsureSuccessStatusCode();

                string fileName = resp.Content.Headers.ContentDisposition?.FileName?.Trim('"') ?? $"Untitled_{id}";

                string fp = Path.Combine(savePath, fileName);

                await using var stream = await resp.Content.ReadAsStreamAsync();
                await using var file = File.Create(fp);

                await stream.CopyToAsync(file);
            }
            catch (Exception ex) {
                Notification.error(FormMain.Instance, "Home Drive", $"Failed to download this file!\n{ex.Message}");
                return;
            }

            try {
                Process.Start(new ProcessStartInfo {
                    FileName = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.Windows),
                        "explorer.exe"
                    ),
                    Arguments = $"\"{Path.GetFullPath(savePath)}\"",
                    UseShellExecute = true
                });
            }
            catch {

            }
        }

        public static async Task<List<FileDirData>> SearchFiles(string keyword) {
            try {
                var resp = await FormMain.ApiClient
                    .GetAsync($"api/filedir/search/{FormMain.LoggedAccount.AccountId}/{keyword}");

                if (resp == null || !resp.IsSuccessStatusCode)
                    return new List<FileDirData>(0);

                var ctx = await resp.Content.ReadFromJsonAsync<List<FileDirData>>();

                return ctx == null ? new List<FileDirData>(0) : ctx;
            }
            catch (HttpRequestException) {
                return new List<FileDirData>(0);
            }
        }
    }

    public class GetFileDirData {
        public Guid OwnerId { get; set; }
        public Guid? ParentId { get; set; }
    }
}
