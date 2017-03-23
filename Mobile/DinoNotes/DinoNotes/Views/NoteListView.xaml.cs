using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DinoNotes.ViewModels;

namespace DinoNotes.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteListView : ContentPage {
        public NoteListView() {
            InitializeComponent();
            BindingContext = new NoteListViewModel(this);
        }

        protected override void OnAppearing() {
            lvNotes.SelectedItem = null;
        }
    }
}
