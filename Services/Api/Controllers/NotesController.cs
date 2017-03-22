using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DinoNotes.Services.Api.Models;
using System.Configuration;
using Couchbase;
using Couchbase.Core;

namespace DinoNotes.Services.Api.Controllers {

    [Authorize]
    public class NotesController : ApiController {

        private readonly IBucket _bucket = ClusterHelper.GetBucket(ConfigurationManager.AppSettings.Get("CouchbaseNotesBucket"));

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
                Id = 2,
                Title = "Note" + id,
                DateUpdated = new DateTime(),
                Content = "abc 123",
                IsPinned = false
            };
        }

        /// <summary>
        /// This web method should receive 'application/json' as the body of the post. 
        /// If not, the POST data content will not match the 'FromBody' model argument, 
        ///    then model properties will be NULL or its default data type values
        /// </summary>
        /// <param name="postData"></param>
        /// <returns>UID of the affected record</returns>
        [AcceptVerbs("POST")]
        public string SaveNote([FromBody]NoteInfo postData) {
            string apiResult = string.Empty;

            string uid = Guid.NewGuid().ToString();
            var note = new Document<NoteInfo> {
                Id = uid,
                Content = new NoteInfo {
                    Uid = uid,
                    Title = postData.Title,
                    DateUpdated = DateTime.Now,
                    Content = postData.Content,
                    IsPinned = false,
                    IsDeleted = false
                }
            };

            var result = _bucket.Upsert(note);
            if (result.Success) {
                apiResult = uid;
            }

            return apiResult;
        }

    }
}