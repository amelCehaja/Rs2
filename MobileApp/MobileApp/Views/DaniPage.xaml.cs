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
    public partial class DaniPage : ContentPage
    {
        public DanViewModel model = null;
        public DaniPage(PlanIProgram planIProgram)
        {
            InitializeComponent();
            BindingContext = model = new DanViewModel
            {
                PlanIProgram = planIProgram
            };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadDani();
        }

        public async void Select_Dan(object sender, SelectedItemChangedEventArgs e)
        {
            var dan = e.SelectedItem as Dan;
            await Navigation.PushModalAsync(new DanDetailsPage(dan));
        }
    }
}