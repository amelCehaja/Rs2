using MobileApp.ViewModels;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LiveTreningOdmorPage : ContentPage
    {
        public LiveTreningOdmorViewModel model = null;
        public LiveTreningOdmorPage(ObservableCollection<SetVjezba> sets)
        {
            InitializeComponent();
            BindingContext = model = new LiveTreningOdmorViewModel
            {
                SetVjezbe = sets
            };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
             model.Start();
        }

        private async void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(e.NewTextValue == "Kraj odmora!" && model.SetVjezbe.Count>1)
            {
                model.Kraj();
                await Navigation.PushModalAsync(new LiveTreningVjezbaPage(model.SetVjezbe));
            }
        }
    }
}