using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DinoNotes.Web.Portal {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(object sender, EventArgs e) {
            Exception exception = Server.GetLastError();

            int statusCode = 500;
            if (exception.GetType() == typeof(HttpException)) {
                statusCode = ((HttpException)exception).GetHttpCode();
            }

            HttpContext httpContext = HttpContext.Current;
            httpContext.Response.Clear();
            RequestContext requestContext = ((MvcHandler)httpContext.CurrentHandler).RequestContext;
            string controllerName = "Error";
            string actionName = "Index";
            requestContext.RouteData.Values["controller"] = controllerName;
            requestContext.RouteData.Values["action"] = actionName;
            requestContext.RouteData.Values["statusCode"] = statusCode;
            requestContext.RouteData.Values["exception"] = exception;

            IControllerFactory factory = ControllerBuilder.Current.GetControllerFactory();
            IController controller = factory.CreateController(requestContext, controllerName);
            controller.Execute(requestContext);
            httpContext.Server.ClearError();
            Response.End();
        }
    }
}
