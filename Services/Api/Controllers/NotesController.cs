using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DinoNotes.Services.Api.Models;

namespace DinoNotes.Services.Api.Controllers {

    [Authorize]
    public class NotesController : ApiController {

        [AcceptVerbs("GET")]
        public List<NoteMeta> GetList() {

            return new List<NoteMeta> {
                new NoteMeta {
                    Id = 1,
                    Title = "Note One",
                    IsPinned = false
                },
                new NoteMeta {
                    Id = 2,
                    Title = "Note Two",
                    IsPinned = true
                },
                new NoteMeta {
                    Id = 3,
                    Title = "Note Three"
                }
            }.OrderByDescending(o => o.IsPinned).ToList();
        }

        [AcceptVerbs("GET")]
        public NoteInfo GetNote(int id) {

            return new NoteInfo {
                Id = 1,
                Title = "Note One",
                DateUpdated = new DateTime(),
                Content = "abc 123",
                IsPinned = false
            };
        }

    }
}