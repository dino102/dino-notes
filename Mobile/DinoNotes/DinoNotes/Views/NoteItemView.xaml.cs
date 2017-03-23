using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DinoNotes.ViewModels;
using DinoNotes.Models;

namespace DinoNotes.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteItemView : ContentPage {
        public NoteItemView(NoteInfo noteInfo) {
            InitializeComponent();
            BindingContext = new NoteItemViewModel(this, noteInfo);
        }
    }
}
