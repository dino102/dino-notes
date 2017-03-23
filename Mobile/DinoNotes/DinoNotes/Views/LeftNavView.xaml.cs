using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DinoNotes.ViewModels;

namespace DinoNotes.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeftNavView : ContentPage {

        public LeftNavView() {
            InitializeComponent();
            BindingContext = new LeftNavViewModel();
        }

        // expose this listView control for changing the active page during navigation
        public ListView LeftNavMenuList {
            get { return leftNavMenuList; }
        }
        public ListView LeftSystemOptionsList {
            get { return leftSystemOptionsList; }
        }
    }
}
