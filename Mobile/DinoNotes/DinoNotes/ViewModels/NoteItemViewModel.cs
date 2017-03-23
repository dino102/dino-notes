using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using DinoNotes.Models;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace DinoNotes.ViewModels {
    public class NoteItemViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string name = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private Page _page;

        public string Title { get; set; }
        public string Content { get; set; }
        public Command SaveCommand { get;  }
        public Command DeleteCommand { get; }

        private bool _isBusy;
        public bool IsBusy {
            get { return _isBusy; }
            set {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));

                SaveCommand.ChangeCanExecute();
                DeleteCommand.ChangeCanExecute();
            }
        }

        public NoteItemViewModel(Page page, NoteInfo noteInfo) {
            _page = page;
            Title = noteInfo.Title;
            Content = noteInfo.Content;

            DeleteCommand = new Command(Delete, () => !IsBusy);
            SaveCommand = new Command(Save, () => !IsBusy);
        }

        public async void Delete() {
            var answer = await _page.DisplayAlert("Dino Notes", "Do you wan't to delete this note?", "Yes", "No");
            if (answer) {
                IsBusy = true;
                await Task.Delay(1000);
                await _page.DisplayAlert("Dino Notes", "Deleted!", "OKAY");
                IsBusy = false;
            }
        }

        public async void Save() {
            IsBusy = true;
            await Task.Delay(1000);
            await _page.DisplayAlert("Dino Notes", "Saved!", "OKAY");
            IsBusy = false;
        }


    }
}
