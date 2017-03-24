﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using DinoNotes.Utilities;
using System.Threading.Tasks;

namespace DinoNotes.ViewModels {
    public class LoginViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string name = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private Page _page;

        // view properties
        public string Username { get; set; }
        public string Password { get; set; }

        private bool _isBusy;
        public bool IsBusy {
            get { return _isBusy; }
            set {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
                LoginCommand.ChangeCanExecute();
            }
        }

        // view methods
        public Command LoginCommand { get; }

        // constructor
        public LoginViewModel(Page page) {
            this._page = page;
            LoginCommand = new Command(Login, () => !IsBusy);
        }

        private async void Login() {
            IsBusy = true;

            await Task.Delay(1000); // delay for a sec
            if (Username == "d" && Password == "p") {

                Globals.IsLoggedIn = true;
                Globals.ActiveUsername = "Dino Pelagio";
                Globals.ActiveUserEmail = "dino102@gmail.com";

                Application.Current.MainPage = new Views.RootView();
            } else {
                await Application.Current.MainPage.DisplayAlert("Login", "Invalid username or password.", "OK");
            }

            IsBusy = false;
        }
    }
}
