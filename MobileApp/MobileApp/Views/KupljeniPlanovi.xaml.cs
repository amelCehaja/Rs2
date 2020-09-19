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
    public partial class KupljeniPlanovi : ContentPage
    {
        KupljeniPlanoviVM model = null;
         public KupljeniPlanovi()
        {
            InitializeComponent();
            BindingContext = model = new KupljeniPlanoviVM ();
            
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var plan = e.SelectedItem as PlanIProgram;
            await Navigation.PushModalAsync(new PlanDetailsPage(plan));
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadPlanove();
        }
    }
}