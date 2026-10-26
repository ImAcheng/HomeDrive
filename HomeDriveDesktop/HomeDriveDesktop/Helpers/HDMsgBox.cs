using AntdUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeDriveDesktop.Helpers {
    public static class HDMsgBox {
        public static DialogResult Show(Form source, string content, TType type) {
            return Modal.config(source, "Home Drive", content, type)
                    .SetDraggable(false)
                    .SetOk("Confirm")
                    .SetCancelHide()
                    .open();
        }
    }
}
