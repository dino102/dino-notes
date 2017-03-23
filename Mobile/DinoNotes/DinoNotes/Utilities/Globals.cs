using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DinoNotes.Utilities {
    public class Globals {
        public static bool IsLoggedIn {
            get {
                object result;
                Application.Current.Properties.TryGetValue(Constants.ISLOGGEDIN, out result);
                return result != null ? bool.Parse(result.ToString()) : false;
            }
            set {
                Application.Current.Properties[Constants.ISLOGGEDIN] = value;
            }
        }

        public static string ActiveUsername {
            get {
                object result;
                Application.Current.Properties.TryGetValue(Constants.ACTIVEUSERNAME, out result);
                return result != null ? result.ToString() : string.Empty;
            }
            set {
                Application.Current.Properties[Constants.ACTIVEUSERNAME] = value;
            }
        }

        public static string ActiveUserEmail {
            get {
                object result;
                Application.Current.Properties.TryGetValue(Constants.ACTIVEUSEREMAIL, out result);
                return result != null ? result.ToString() : string.Empty;
            }
            set {
                Application.Current.Properties[Constants.ACTIVEUSEREMAIL] = value;
            }
        }

    }
}
