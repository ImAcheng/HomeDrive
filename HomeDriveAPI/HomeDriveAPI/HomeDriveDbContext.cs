using Microsoft.EntityFrameworkCore;

namespace HomeDriveAPI {
    public class HomeDriveDbContext : DbContext {
        public HomeDriveDbContext(DbContextOptions<HomeDriveDbContext> options) :base(options) { }

        public DbSet<Account> Account { get; set; }
        public DbSet<FileDirData> FileDirData { get; set; }
        public DbSet<FileDirAccess> FileDirAccesse { get; set; }
    }

    public class Account {
        public Guid AccountId { get; set; }
        public string Username { get; set; }
        public string LoginPassword { get; set; }
    }

    public class FileDirData {
        public Guid FileDirDataId { get; set; }
        public Guid AccountId { get; set; }
        public byte Type { get; set; }
        public string FileDirName { get; set; }
        public Guid? ParentDirId { get; set; }
        public string? MimeType { get; set; }
        public byte Status { get; set; }
        public byte PrivacyPolicy { get; set; }
        public DateTimeOffset CreateDateTime { get; set; }

        public virtual Account Account { get; set; }
    }

    public class FileDirAccess {
        public Guid FileDirAccessId { get; set; }
        public Guid FileDirDataId { get; set; }
        public Guid AccountId { get; set; }

        public virtual FileDirData FileDirData { get; set; }
        public virtual Account Account { get; set; }
    }
}
