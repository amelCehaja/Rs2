using MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TjelesniNapredakAdd : ContentPage
    {

        TjelesniNapredakAddViewModel model = null;
        public TjelesniNapredakAdd()
        {
            BindingContext = model = new TjelesniNapredakAddViewModel();
            InitializeComponent();
        }
        public async void Spremi_Click(object Sender, EventArgs e)
        {
            await model.Spremi();
            await Application.Current.MainPage.DisplayAlert("", "Uspjesno ste dodali tjelesni napredak!", "OK");
            await Navigation.PopModalAsync();
        }
    }
}