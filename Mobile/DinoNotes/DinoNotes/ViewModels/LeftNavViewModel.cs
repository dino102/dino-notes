using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DinoNotes.Utilities;
using DinoNotes.Models;
using DinoNotes.Views;

namespace DinoNotes.ViewModels {
    public class LeftNavViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        //private Page _page;
        private const string _menuItemRowHeight = "45";

        public string UserDisplayName {
            get {
                return Globals.ActiveUsername;
            }
        }

        public string UserEmail {
            get {
                return Globals.ActiveUserEmail;
            }
        }

        private ObservableCollection<LeftNavMenuItem> _leftNavMenuItem = new ObservableCollection<LeftNavMenuItem>();
        public ObservableCollection<LeftNavMenuItem> LeftNavMenuItems {
            get { return _leftNavMenuItem; }
            set {
                _leftNavMenuItem = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<LeftNavMenuItem> _leftSystemOptionsItem = new ObservableCollection<LeftNavMenuItem>();
        public ObservableCollection<LeftNavMenuItem> LeftSystemOptionsItems {
            get { return _leftSystemOptionsItem; }
            set {
                _leftSystemOptionsItem = value;
                OnPropertyChanged();
            }
        }

        //public LeftNavMenuItem LeftNavMenuSelectedItem { get; set; }

        // fix to make the list view height dynamic
        // (for some reason xaml expand the list view to
        //  occupy the whole page)
        public string MenuItemRowHeight {
            get { return _menuItemRowHeight; }
        }
        public string MenuHeightNav {
            get {
                return (this.LeftNavMenuItems.Count * int.Parse(MenuItemRowHeight)).ToString();
            }
        }
        public string MenuHeightSystemOptions {
            get {
                return (this._leftSystemOptionsItem.Count * int.Parse(MenuItemRowHeight)).ToString();
            }
        }

        private bool _isBusy;
        public bool IsBusy {
            get { return _isBusy; }
            set {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        // const
        public LeftNavViewModel() {
            //_page = page;

            // initialize menu items
            LeftNavMenuItems = new ObservableCollection<LeftNavMenuItem> {
                new LeftNavMenuItem { Title = "Notes", Icon = "nav_ic_action_list_2.png", TargetPage = typeof(NoteListView) },
                new LeftNavMenuItem { Title = "Tags", Icon = "nav_ic_action_trash.png", TargetPage = typeof(NoteListView) },
            };

            LeftSystemOptionsItems = new ObservableCollection<LeftNavMenuItem> {
                new LeftNavMenuItem { Title = "Settings", Icon = "nav_ic_action_gear.png", TargetPage = typeof(NoteListView) },
                new LeftNavMenuItem { Title = "Log out", Icon = "nav_ic_action_lock_closed.png", TargetPage = null }
            };
        }

        void OnPropertyChanged([CallerMemberName]string name = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        
    }
}
