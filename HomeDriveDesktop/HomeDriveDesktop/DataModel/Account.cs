using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDriveDesktop.DataModel {
    public class Account {
        public Guid AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AccRqResp {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Account? Account { get; set; }
    }
}
