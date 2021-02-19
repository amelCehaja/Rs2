using MobileApp.ViewModels;
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
    public partial class OcjenaPage : ContentPage
    {
        private OcjenaViewModel model = null;
        public OcjenaPage(int planId)
        {
            
            model = new OcjenaViewModel
            {
                PlanId = planId
            };
            BindingContext = model;
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            model._loadOcjene();
            base.OnAppearing();
        }
        private async void Ocjeni(object sender, EventArgs e)
        {
            bool ocijeni = await model._ocijeni();
            if(ocijeni == true)
                await Navigation.PopModalAsync();
        }
    }
}