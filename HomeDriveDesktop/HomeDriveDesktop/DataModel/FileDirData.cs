using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDriveDesktop.DataModel {
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
}
