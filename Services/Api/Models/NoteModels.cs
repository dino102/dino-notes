using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DinoNotes.Services.Api.Models {
    public class NoteMeta {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsPinned { get; set; }
    }

    public class NoteInfo {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Content { get; set; }
        public bool IsPinned { get; set; }
        public bool IsDeleted { get; set; }
    }
}