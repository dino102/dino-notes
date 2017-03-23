using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DinoNotes.Models;
using Xamarin.Forms;

namespace DinoNotes.ViewModels {
    public class NoteListViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string name = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private Page _page;

        private ObservableCollection<NoteInfo> _noteList = new ObservableCollection<NoteInfo>();
        public ObservableCollection<NoteInfo> NoteList {
            get { return _noteList; }
            set {
                _noteList = value;
                OnPropertyChanged();
            }
        }

        public NoteListViewModel(Page page) {
            _page = page;

            ObservableCollection<NoteInfo> notes = new ObservableCollection<NoteInfo> {
                new NoteInfo {
                    Uid = Guid.NewGuid().ToString(),
                    Title = "Note One",
                    Content = "The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog. The quick brown fox jumps over the lazy dog",
                    DateUpdated = DateTime.Now,
                    IsPinned = false,
                    Image = "",
                    IsDeleted = false
                },
                new NoteInfo {
                    Uid = Guid.NewGuid().ToString(),
                    Title = "Note Two",
                    Content = "The quick brown fox jumps over the lazy dog",
                    DateUpdated = DateTime.Now,
                    IsPinned = true,
                    Image = "ic_action_tag.png",
                    IsDeleted = false
                },
                new NoteInfo {
                    Uid = Guid.NewGuid().ToString(),
                    Title = "Note Three",
                    Content = "The quick brown fox jumps over the lazy dog",
                    DateUpdated = DateTime.Now,
                    IsPinned = false,
                    Image = "",
                    IsDeleted = false
                }
            };

            this.NoteList = notes;
        }

        private NoteInfo _selectedItem = new NoteInfo();
        public NoteInfo SelectedItem {
            get {
                return _selectedItem;
            }
            set {
                _selectedItem = value;
                //OnPropertyChanged();
                if (_selectedItem == null || _selectedItem.Title == null) {
                    return;
                }
                NavigateToNoteItemView(_selectedItem);
                SelectedItem = null;
            }
        }

        public async void NavigateToNoteItemView(NoteInfo noteInfo) {
            await _page.Navigation.PushAsync(new Views.NoteItemView(noteInfo));
        }

    }
}
