using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Xamarin.Forms;
using DinoNotes.Models;
using static DinoNotes.Utilities.Extensions;



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

            LoadList(string.Empty);
        }

        private void LoadList(string searchFilter) {
            List<NoteInfo> notes = new List<NoteInfo> {
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
                    Content = "The quick brown fox jumps over the lazy dog. my filter",
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

            if (searchFilter == string.Empty) {
                this.NoteList = notes.ToObservableCollection();
            } else {
                this.NoteList = notes.FindAll(x => x.Content.Contains(searchFilter)).ToObservableCollection();
            }
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

        private string _searchFilter;
        public string SearchFilter {
            get { return _searchFilter; }
            set {
                _searchFilter = value;
                OnPropertyChanged(nameof(_searchFilter));

                LoadList(_searchFilter);
            }
        }

        

    }
}
