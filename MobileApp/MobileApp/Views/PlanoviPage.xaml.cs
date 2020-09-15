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
    public partial class PlanoviPage : ContentPage
    {
        private PlanoviViewModel model = null;
        public PlanoviPage()
        {
            InitializeComponent();
            BindingContext = model = new PlanoviViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var plan = e.SelectedItem as PlanIProgram;
            await Navigation.PushModalAsync(new PlanDetailsPage(plan));
        }
    }
}