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
            InitializeComponent();
            model = new OcjenaViewModel
            {
                PlanId = planId,
                Rating = 5
            };
            BindingContext = model;
        }
        private async void Ocjeni(object sender, EventArgs e)
        {
            await model._ocijeni();
            await Navigation.PopModalAsync();
        }
    }
}