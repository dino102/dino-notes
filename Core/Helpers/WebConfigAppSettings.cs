using System.Configuration;

namespace DinoNotes.Core.Helpers {
    public static class WebConfigAppSettings {
        public static string ApiHost {
            get { return ConfigurationManager.AppSettings["js_ApiUrl"]; }
        }

    }
}
