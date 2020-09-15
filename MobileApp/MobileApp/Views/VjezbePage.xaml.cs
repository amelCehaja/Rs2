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
    public partial class VjezbePage : ContentPage
    {
        VjezbeViewModel model = null;
        public VjezbePage()
        {
            BindingContext = model = new VjezbeViewModel();
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadMisici();
            await model.LoadVjezbe();
        }
        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var vjezba = e.SelectedItem as Vjezba;
            await Navigation.PushModalAsync(new VjezbaDetailsPage(vjezba));
        }
    }
}