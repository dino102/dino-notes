using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DinoNotes.Services.Api.Controllers {
    public class HomeController : ApiController {

        [AcceptVerbs("GET")]
        public string Index() {
            return "DinoNotes API - v1.0";
        }

        [Authorize]
        [AcceptVerbs("GET")]
        public string About() {
            return "DinoNotes About Info";
        }

    }
}