using System;
using System.Web.Mvc;
using DinoNotes.Web.Portal.Models;

namespace DinoNotes.Web.Portal.Controllers {
    public class ErrorController : Controller {
        public ActionResult Index(int statusCode, Exception exception) {
            ErrorViewModel model = new ErrorViewModel {
                StatusCode = statusCode,
                Message = exception.Message
            };

            Response.TrySkipIisCustomErrors = true;
            return View(model);
        }
    }
}