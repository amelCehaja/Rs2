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
    public partial class KomentarPage : ContentPage
    {
        KomentarViewModel model = null;
        public KomentarPage(int planId)
        {
            BindingContext = model = new KomentarViewModel
            {
                PlanId = planId
            };
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            await model.LoadKomentare();
        }
    }
}