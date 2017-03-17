using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DinoNotes.Web.Portal.Startup))]
namespace DinoNotes.Web.Portal {
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
