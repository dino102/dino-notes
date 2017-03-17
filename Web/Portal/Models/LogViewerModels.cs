//using MongoDB.Bson;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;

namespace DinoNotes.Web.Portal.Models {

    public class LogEntriesModel {
        public List<LogEntryModel> LogEntries { get; set; }
    }

    public class LogEntryModel {
        //public ObjectId Id { get; private set; }
        public DateTime Date { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public int ThreadID { get; set; }
        public int ProcessID { get; set; }
        public string ProcessName { get; set; }
        public string UserName { get; set; }
    }
}