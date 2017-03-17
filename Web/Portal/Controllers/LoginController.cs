using System;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using DinoNotes.Web.Portal.Models;
using DinoNotes.Core.Security;
using DinoNotes.Core.Helpers;

namespace DinoNotes.Web.Portal.Controllers {
    public class LoginController : Controller {

        private const string _apiAuthTokenCookieName = "apitoken";

        [HttpGet]
        public ActionResult Index(string returnUrl) {
            ViewBag.ReturnUrl = returnUrl;

            if (Request.IsAuthenticated) {
                return RedirectToLocal(returnUrl);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model, string returnUrl) {
            if (!ModelState.IsValid) {
                return View();
            }

            // call api token auth
            var token = TokenManager.GetToken(WebConfigAppSettings.ApiHost, model.Username, model.Password);
            if (token != null) {

                // save API auth token to cookie
                HttpCookie apiAuthTokenCookie = new HttpCookie(_apiAuthTokenCookieName);
                apiAuthTokenCookie.Value = token.access_token;
                apiAuthTokenCookie.Expires = DateTime.Now.AddDays(1);
                HttpContext.Response.SetCookie(apiAuthTokenCookie);

                // TODO: where to get this from API?
                // set web app's own user claim identity here
                // (use to display user information)
                var identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, "Dino Pelagio"),
                        new Claim(ClaimTypes.NameIdentifier, model.Username),
                        new Claim(ClaimTypes.Email, "dino102@gmail.com")
                    }, "ApplicationCookie");

                var owinContext = Request.GetOwinContext();
                var owinAuthManager = owinContext.Authentication;
                owinAuthManager.SignIn(new AuthenticationProperties() { IsPersistent = model.RememberMe }, identity);

                return RedirectToLocal(returnUrl);
            }

            // reset model
            model.Username = string.Empty;
            model.Password = string.Empty;
            ModelState.Clear();

            // auth failed
            ModelState.AddModelError("invalid", "Invalid username or password");
            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl) {
            if (Url.IsLocalUrl(returnUrl)) {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOut(string returnUrl) {
            // expire api auth token
            // save API auth token to cookie
            System.Web.HttpCookie apiAuthTokenCookie = new System.Web.HttpCookie(_apiAuthTokenCookieName);
            apiAuthTokenCookie.Value = string.Empty;
            apiAuthTokenCookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Response.SetCookie(apiAuthTokenCookie);

            var owinContext = Request.GetOwinContext();
            var owinAuthManager = owinContext.Authentication;
            owinAuthManager.SignOut("ApplicationCookie");

            if (string.IsNullOrEmpty(returnUrl)) {
                return RedirectToAction("Index", "Login");
            } else {
                return Redirect($"/Login?ReturnUrl={HttpUtility.UrlEncode(returnUrl)}");
            }
        }
    }
}