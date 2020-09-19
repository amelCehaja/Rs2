using MobileApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public async void Vjezbe(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new VjezbePage());
        }
        public async void Planovi(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PlanoviPage());
        }
        public async void TjelesniNapredak(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TjelesniNapredakList());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new KupljeniPlanovi());
        }
    }
}
