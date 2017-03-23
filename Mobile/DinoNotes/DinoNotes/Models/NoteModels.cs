using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoNotes.Models {
    public class NoteInfo {
        public string Uid { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool IsPinned { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
    }
}
