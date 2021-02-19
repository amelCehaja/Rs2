using MobileApp.ViewModels;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TjelesniNapredakList : ContentPage
    {
        public TjelesniNapredakListViewModel model = null;
        public TjelesniNapredakList()
        {
            InitializeComponent();
            BindingContext = model = new TjelesniNapredakListViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadDetalji();
        }
        public async void Dodaj(object Sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TjelesniNapredakAdd());
        }
        public async void Detalji_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var _tjelesniDetalji = e.SelectedItem as TjelesniDetalji;
            await Navigation.PushModalAsync(new TjelesniNapredakDetailsPage(_tjelesniDetalji));
        }
        public async void Uporedi(object Sender, EventArgs e)
        {
            if(model.DetaljiJedan != null && model.DetaljiDva != null)
                await Navigation.PushModalAsync(new UporedbaTjelesnihDetaljaPage(model.DetaljiJedan, model.DetaljiDva));
            else
                await Application.Current.MainPage.DisplayAlert("", "Potrebno odabrati oba datuma za uporedbu!", "OK");
        }
    }
}