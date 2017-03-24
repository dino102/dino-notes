using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DinoNotes.Models;
using DinoNotes.Utilities;

namespace DinoNotes.Views {
    public class RootView : MasterDetailPage {

        public RootView() {

            //set the master page (in this case it's the Left Navigation page)
            LeftNavView leftNavView = new LeftNavView();
            leftNavView.LeftNavMenuList.ItemSelected += (sender, e) => {
                var item = e.SelectedItem as LeftNavMenuItem;
                if (item != null) {

                    // load the selected item as Detail page
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
                    //leftNavPage.LeftNavMenuList.SelectedItem = item;
                    leftNavView.LeftNavMenuList.SelectedItem = null; // de-select active item
                    IsPresented = false;
                }
            };
            leftNavView.LeftSystemOptionsList.ItemSelected += (sender, e) => {
                var item = e.SelectedItem as LeftNavMenuItem;
                if (item != null) {
                    switch (item.Title.ToUpper()) {
                        case "SETTINGS":
                            DisplayAlert("Dino Notes", "Settings", "OKAY");

                            // load the selected item as Detail page
                            // Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
                            break;
                        case "LOG OUT":
                            Globals.IsLoggedIn = false;

                            // load the Root page
                            Application.Current.MainPage = new LoginView();
                            //Navigation.PushModalAsync(new LoginView());

                            //// prevents Android devices from using the back button
                            //if (Device.OS == TargetPlatform.Android) {
                            //    Application.Current.MainPage = new LoginView();
                            //}
                            break;
                    }
                    IsPresented = false;
                    leftNavView.LeftSystemOptionsList.SelectedItem = null; // de-select active item
                }
            };
            Master = leftNavView;

            //set the initial detail page
            Detail = new NavigationPage(new NoteListView());
        }
    }
}
