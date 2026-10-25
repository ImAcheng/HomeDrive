using AntdUI;
using HomeDriveDesktop.DataModel;
using System.Net.Http.Json;

namespace HomeDriveDesktop {
    internal class AccountAPI {
        /// <summary>
        /// This is to check if user logged in successfully or not.
        /// </summary>
        public static bool IsNull() {
            if (FormMain.LoggedAccount == null) {
                Notification.warn(FormMain.Instance, "Home Drive", $"Oops, we can't get your account data.\n" +
                    $"Please login again!", autoClose: 2);
                return true;
            }

            return false;
        }

        public static async Task<AccRqResp?> LoginTo(string uname, string pwd) {
            try {
                using var resp = await FormMain.ApiClient.PostAsJsonAsync("api/account/login", new {
                    username = uname,
                    password = pwd
                });

                return await resp.Content.ReadFromJsonAsync<AccRqResp>();
            }
            catch (HttpRequestException) {
                return new AccRqResp() { Success = false, Message = "API connection failed." };
            }
        }
    }
}
