using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DinoNotes.Services.Api.Controllers {
    public class SecurityController : ApiController {

        [AcceptVerbs("GET")]
        public string Info() {

            return "INFO message";
        }

    }
}