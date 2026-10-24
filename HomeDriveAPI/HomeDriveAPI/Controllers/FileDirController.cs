using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace HomeDriveAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class FileDirController : ControllerBase {
        private readonly HomeDriveDbContext _db;
        private readonly IWebHostEnvironment _env;

        public FileDirController(HomeDriveDbContext db, IWebHostEnvironment env) {
            _db = db;
            _env = env;
        }

        [HttpPost("get-files")]
        public async Task<IActionResult> GetFileDirFrom([FromBody] GetFileDirData data) {
            var fileDirs = await _db.FileDirData
                .AsNoTracking()
                .Where(f => f.ParentDirId == data.ParentId && f.AccountId == data.OwnerId && f.Status == 0)
                .OrderBy(f => f.Type)
                .ThenByDescending(f => f.CreateDateTime)
                .ToListAsync();

            return Ok(fileDirs);
        }

        [HttpPost("upload-file/{uid:guid}/{pid:guid?}")]
        public async Task<IActionResult> UploadFile(
                    [FromRoute] Guid uid,
                    [FromRoute] Guid? pid,
                    [FromForm] IFormFile file) {

            if (file == null)
                return BadRequest("File is required.");

            if (file.Length >= 10L * 1024 * 1024 * 1024)
                return BadRequest("File size is too big (> 10GB)");

            Guid fid = Guid.NewGuid();

            string dir = Path.Combine(
                _env.ContentRootPath,
                ".STORAGE",
                uid.ToString()
            );

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            string fp = Path.Combine(dir, fid.ToString());

            try {
                await using (var fs = new FileStream(
                    fp,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.None,
                    81920,
                    useAsync: true)) {
                    await file.CopyToAsync(fs);
                }

                var dbData = new FileDirData() {
                    FileDirDataId = fid,
                    AccountId = uid,
                    Type = 0,
                    FileDirName = file.FileName,
                    ParentDirId = pid,
                    MimeType = GetMimeType(file.FileName),
                    PrivacyPolicy = 0,
                    CreateDateTime = DateTimeOffset.UtcNow
                };

                await _db.FileDirData.AddAsync(dbData);
                await _db.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex) {
                if (System.IO.File.Exists(fp))
                    System.IO.File.Delete(fp);

                return BadRequest(ex.Message);
            }
        }

        [HttpPost("delete/{uid:guid}/{fdid:guid}")]
        public async Task<IActionResult> DeleteFileOrDir([FromRoute] Guid uid, [FromRoute] Guid fdid) {
            var target = await _db.FileDirData.FirstOrDefaultAsync(f => f.AccountId == uid && f.FileDirDataId == fdid);

            if (target == null) {
                return BadRequest("Target file not found.");
            }

            try {
                if (target.Type == 1) {
                    await DeleteChildrenRecursive(target.FileDirDataId);
                    return Ok();
                }

                target.Status = 2;
                await _db.SaveChangesAsync();

                string dir = Path.Combine(
                    _env.ContentRootPath,
                    ".STORAGE",
                    uid.ToString()
                );

                string fp = Path.Combine(dir, target.FileDirDataId.ToString());

                System.IO.File.Delete(fp);

                return Ok();
            }
            catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-dir/{uid:guid}")]
        public async Task<IActionResult> CreateDirectory([FromRoute] Guid uid, 
                                                         [FromQuery] Guid? parentId, [FromQuery] string name) {

            var data = new FileDirData() {
                FileDirDataId = Guid.NewGuid(),
                AccountId = uid,
                Type = 1,
                FileDirName = name,
                ParentDirId = parentId,
                MimeType = null,
                Status = 0,
                PrivacyPolicy = 0,
                CreateDateTime = DateTimeOffset.UtcNow
            };

            await _db.FileDirData.AddAsync(data);
            await _db.SaveChangesAsync();

            return Ok(data.FileDirDataId);
        }

        [HttpGet("download/{id:guid}")]
        public async Task<IActionResult> Download(Guid id) {
            var file = await _db.FileDirData
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.FileDirDataId == id);

            if (file == null || file.Type != 0)
                return NotFound();

            var path = Path.Combine(_env.ContentRootPath, ".STORAGE", file.AccountId.ToString(), id.ToString());

            if (!System.IO.File.Exists(path))
                return NotFound();

            return PhysicalFile(
                path,
                "application/octet-stream",
                file.FileDirName
            );
        }

        [HttpGet("search/{uid:guid}/{keyword}")]
        public async Task<IActionResult> SearchFiles([FromRoute] Guid uid, [FromRoute] string keyword) {
            var result = await _db.FileDirData
                .AsNoTracking()
                .Where(x => x.AccountId == uid &&
                            x.FileDirName.Trim().ToLower().Contains(keyword.Trim().ToLower()) && 
                            x.Status == 0)
                .ToListAsync();

            return Ok(result);
        }

        private static string GetMimeType(string fileName) {
            var provider = new FileExtensionContentTypeProvider();

            return provider.TryGetContentType(fileName, out var type)
                ? type
                : "application/octet-stream";
        }

        private async Task DeleteChildrenRecursive(Guid parentId) {
            try {
                var children = await _db.FileDirData
                    .Where(x => x.ParentDirId == parentId)
                    .ToListAsync();

                foreach (var child in children) {
                    try {
                        if (child.Type == 1) {
                            await DeleteChildrenRecursive(child.FileDirDataId);
                        }

                        child.Status = 2;

                        string dir = Path.Combine(
                            _env.ContentRootPath,
                            ".STORAGE",
                            child.AccountId.ToString()
                        );

                        string fp = Path.Combine(
                            dir,
                            child.FileDirDataId.ToString()
                        );

                        try {
                            System.IO.File.Delete(fp);
                        }
                        catch {
                            
                        }
                    }
                    catch {
                        
                    }
                }

                var self = await _db.FileDirData.FindAsync(parentId);
                self.Status = 2;

                await _db.SaveChangesAsync();
            }
            catch {
                
            }
        }
    }

    public class GetFileDirData {
        public Guid OwnerId { get; set; }
        public Guid? ParentId { get; set; }
        public int SortingDirection { get; set; } = 0; // 0: time asc, 1: time desc
    }
}
