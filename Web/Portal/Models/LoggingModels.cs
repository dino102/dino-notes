using System;

namespace DinoNotes.Web.Portal.Models {
    public class AuditLogModel {
        public string Controller { get; set; }
        public string Action { get; set; }
        // add other info
    }

    public class ErrorLogModel {
        public string Controller { get; set; }
        public string Action { get; set; }
        public ExceptionLogModel Exception { get; set; }
    }

    public class ExceptionLogModel {
        public string Type { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
    }
}