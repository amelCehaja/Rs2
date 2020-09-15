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
    public partial class DanDetailsPage : ContentPage
    {
        public DanDetailsViewModel model = null;
        public DanDetailsPage(Dan dan)
        {
            BindingContext = model = new DanDetailsViewModel { 
                Dan = dan
            };
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadDanSetovi();
        }
        public async void Start(object sender, EventArgs e)
        {
            await model.LoadSetVjezbe();
            await Navigation.PushModalAsync(new LiveTreningVjezbaPage(model.SetVjezbe));
        }
    }
}