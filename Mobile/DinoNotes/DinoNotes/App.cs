using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DinoNotes.Utilities;

namespace DinoNotes {
    public class App : Application {
        public App() {
            if (Globals.IsLoggedIn) {
                MainPage = new Views.LockView();
            } else {
                MainPage = new Views.LoginView();
            }
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
            if (Globals.IsLoggedIn) {
                MainPage = new Views.LockView();
            } else {
                MainPage = new Views.LoginView();
            }
        }
    }
}
