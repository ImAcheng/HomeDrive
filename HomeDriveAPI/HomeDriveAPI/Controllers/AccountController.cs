using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeDriveAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase {
        private readonly HomeDriveDbContext _db;

        public AccountController(HomeDriveDbContext db) {
            _db = db;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginToAccount([FromBody] AccRqData data) {
            try {
                var acc = await _db.Account
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Username == data.Username);

                if (acc == null) {
                    return BadRequest(new { success = false, message = "Account not found." });
                }

                if (acc.LoginPassword != data.Password) {
                    return BadRequest(new { success = false, message = "Incorrect password." });
                }

                return Ok(new { success = true, message = "Success.", account = acc });
            }
            catch {
                return BadRequest(new { success = false, message = "Database lost or unknown exception(s) occurred." });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount([FromBody] AccRqData data) {
            if (await _db.Account.AsNoTracking().AnyAsync(u => u.Username == data.Username)) {
                return BadRequest(new { success = false, message = "Username was taken." });
            }

            try {
                Account acc = new Account() {
                    AccountId = Guid.NewGuid(),
                    Username = data.Username,
                    LoginPassword = data.Password
                };

                await _db.Account.AddAsync(acc);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex) {
                return BadRequest(new { success = false, message = $"Failed to create account: {ex.Message}" });
            }

            return Ok();
        }
    }

    public class AccRqData {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
