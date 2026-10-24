using HomeDriveDesktop.DataModel;
using System.Net.Http.Json;

namespace HomeDriveDesktop {
    internal class AccountAPI {
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
