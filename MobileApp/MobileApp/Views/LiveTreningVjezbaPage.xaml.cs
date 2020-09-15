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
    public partial class LiveTreningVjezbaPage : ContentPage
    {
        public LiveTreningVjezbaViewModel model = null;
        public LiveTreningVjezbaPage(ObservableCollection<SetVjezba> sets)
        {
            InitializeComponent();
            BindingContext = model = new LiveTreningVjezbaViewModel
            {
                SetVjezbe = sets
            };
        }
        protected override async void OnAppearing()
        {
            await model.LoadVjezba();
            base.OnAppearing();
            
        }
        public async void Dalje(object sender, EventArgs e)
        {
            if(model.SetVjezbe.Count == 1)
            {
                await Application.Current.MainPage.DisplayAlert("Kraj", "Uspjesno ste zavrsili trening!", "OK");
                Application.Current.MainPage = new MainPage();
                return; 
            }
            await Navigation.PushModalAsync(new LiveTreningOdmorPage(model.SetVjezbe));
        }
    }

}