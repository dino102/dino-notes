using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace DinoNotes.Web.Portal.Helpers {
    public static class JavascriptHelper {
        public static string GenerateJsConfig() {
            string output = string.Empty;

            var js = new StringBuilder();
            js.Append("var js={};");
            js.Append("js.config={");

            // get only those app settings prefixed with "js_"
            var settings = ConfigurationManager.AppSettings.AllKeys.Where(k => k.StartsWith("js_")).ToList();

            for (int i = 0; i < settings.Count; i++) {
                var key = settings[i];
                var name = key.Replace("js_", string.Empty); // remove prefix for js naming
                var value = ConfigurationManager.AppSettings[key];
                js.Append(name);
                js.Append(":");
                js.Append("'");
                js.Append(HttpUtility.JavaScriptStringEncode(value));
                js.Append("'");
                if (i != settings.Count - 1) {
                    js.Append(",");
                }
            }
            js.Append("};");

            output = js.ToString();
            return output;
        }
    }
}