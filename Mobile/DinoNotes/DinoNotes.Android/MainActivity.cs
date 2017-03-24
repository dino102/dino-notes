using System;

using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;

namespace DinoNotes.Droid {
    [Activity(Label = "Dino Notes", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {
        protected override void OnCreate(Bundle bundle) {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        /// <summary>
        /// Fix for Android's back button crashing from master detail page
        /// </summary>
        public override void OnBackPressed() {
            var md = Xamarin.Forms.Application.Current.MainPage as MasterDetailPage;
            if (md != null && !md.IsPresented &&
                (
                    !(md.Detail is NavigationPage) ||
                    (((NavigationPage)md.Detail).Navigation.NavigationStack.Count == 1 &&
                     ((NavigationPage)md.Detail).Navigation.ModalStack.Count == 0)
                )) {
                MoveTaskToBack(true);
            } else {
                base.OnBackPressed();
            }
        }

    }
}

