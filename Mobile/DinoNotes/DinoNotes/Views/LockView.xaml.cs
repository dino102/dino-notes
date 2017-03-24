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
    public partial class LockView : ContentPage {
        public LockView() {
            InitializeComponent();
            BindingContext = new LockViewModel(this);
        }
    }
}
