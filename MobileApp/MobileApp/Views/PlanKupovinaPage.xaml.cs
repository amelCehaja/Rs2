﻿using MobileApp.ViewModels;
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
    public partial class PlanKupovinaPage : ContentPage
    {
        public PlanKupovinaViewModel model = null;
        public PlanKupovinaPage(PlanIProgram _plan)
        {
            
            BindingContext = model = new PlanKupovinaViewModel
            {
                PlanIProgram = _plan
            };
            InitializeComponent();
        }
        public async void Kupi(object sender, EventArgs e)
        {
            bool transaction = await model.Kupi();
            if (transaction == true)
            {
                await Application.Current.MainPage.DisplayAlert("", "Transakcija uspjesno izvrsena!", "OK");
                await Navigation.PopModalAsync();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}