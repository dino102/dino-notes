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
            var isLoggedIn = Properties.ContainsKey(Constants.ISLOGGEDIN) && (bool)Properties[Constants.ISLOGGEDIN];
            if (isLoggedIn) {
                MainPage = new Views.RootView();
            } else {
                MainPage = new Views.LoginView();
            }
        }

        protected override void OnStart() {

            //// seed tables
            //SQLiteConnection connection = DependencyService.Get<ISQLite>().GetConnection();
            //var tableInfo = connection.GetTableInfo("User");
            //if (tableInfo.Count <= 0) {

            //    // Users table
            //    var userRepo = new UsersRepository();
            //    userRepo.Insert(new User { Username = "admin", Password = "a", Email = "admin@rational.com.sg", FirstName = "Admin", LastName = "Admin" });
            //    userRepo.Insert(new User { Username = "dino", Password = "p", Email = "apelagio@rational.com.sg", FirstName = "Dino", LastName = "Pelagio" });
            //    userRepo.Insert(new User { Username = "paolo", Password = "b", Email = "pbriones@rational.com.sg", FirstName = "Paolo", LastName = "Briones" });
            //    userRepo.Insert(new User { Username = "jon", Password = "l", Email = "jlimjap@rational.com.sg", FirstName = "Jon", LastName = "Limjap" });
            //    userRepo.Insert(new User { Username = "mike", Password = "f", Email = "mfelina@rational.com.sg", FirstName = "Mike", LastName = "Felina" });

            //    // Settings table
            //    var settingRepo = new SettingsRepository();
            //    settingRepo.Insert(new Setting { Key = "key1", Value = "value1", Description = "..." });
            //}
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
