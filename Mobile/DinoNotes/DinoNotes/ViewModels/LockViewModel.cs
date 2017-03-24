using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using DinoNotes.Utilities;
using System.Threading.Tasks;

namespace DinoNotes.ViewModels {
    public class LockViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string name = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private Page _page;

        // view properties
        public string PassCode { get; set; }

        private bool _isBusy;
        public bool IsBusy {
            get { return _isBusy; }
            set {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
                UnlockCommand.ChangeCanExecute();
            }
        }

        // view methods
        public Command UnlockCommand { get; }

        // constructor
        public LockViewModel(Page page) {
            this._page = page;
            UnlockCommand = new Command(Unlock, () => !IsBusy);
        }

        private async void Unlock() {
            IsBusy = true;

            await Task.Delay(1000); // delay for a sec
            if (PassCode == "1234") {

                Application.Current.MainPage = new Views.RootView();

            } else {
                await Application.Current.MainPage.DisplayAlert("Lock", "Invalid pin or code.", "OK");
            }

            IsBusy = false;
        }
    }
}
