using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DinoNotes.Utilities;
using DinoNotes.Views;

namespace DinoNotes.ViewModels {
    public class RootViewModel {

        private Page _page;
        public RootViewModel(Page page) {
            _page = page;
            LogoutCommand = new Command(Logout);
        }

        // view methods
        public Command LogoutCommand { get; }

        private async void Logout() {
            Application.Current.Properties[Constants.ISLOGGEDIN] = false;

            // load the Root page
            await _page.Navigation.PushModalAsync(new LoginView());

            // prevents Android devices from using the back button
            if (Device.OS == TargetPlatform.Android) {
                Application.Current.MainPage = new LoginView();
            }
        }
    }
}
