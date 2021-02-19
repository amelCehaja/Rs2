using Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class TjelesniNapredakAddViewModel:BaseViewModel
    {
        private readonly APIService _tjelesniNapredakService = new APIService("tjelesniDetalji");
        public TjelesniNapredakAddViewModel()
        {
            
        }

        private bool _firstLogin;
        public bool First
        {
            get { return _firstLogin; }
            set { SetProperty(ref _firstLogin, value); }
        }

        private bool _firstLoginOP;
        public bool FirstOP
        {
            get { return _firstLoginOP; }
            set { SetProperty(ref _firstLoginOP, value); }
        }

        private string _kilaza = null;
        public string Kilaza
        {
            get { return _kilaza; }
            set { SetProperty(ref _kilaza, value); }
        }
        private string _obimBicepsa = null;
        public string ObimBicepsa
        {
            get { return _obimBicepsa; }
            set { SetProperty(ref _obimBicepsa, value); }
        }
        private string _obimNoge = null;
        public string ObimNoge
        {
            get { return _obimNoge; }
            set { SetProperty(ref _obimNoge, value); }
        }
        private string _obimStruka = null;
        public string ObimStruka
        {
            get { return _obimStruka; }
            set { SetProperty(ref _obimStruka, value); }
        }
        private string _obimPrsa = null;
        public string ObimPrsa
        {
            get { return _obimPrsa; }
            set { SetProperty(ref _obimPrsa, value); }
        }
        private string _tezina = null;
        public string Tezina
        {
            get { return _tezina; }
            set { SetProperty(ref _tezina, value); }
        }
        public async Task<bool> Spremi()
        {
            if(string.IsNullOrEmpty(ObimBicepsa) || !Regex.Match(ObimBicepsa, @"^[0-9.]+$", RegexOptions.IgnoreCase).Success)
            {
                await Application.Current.MainPage.DisplayAlert("", "Obim bicepsa mora biti broj!", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(ObimPrsa) || !Regex.Match(ObimPrsa, @"^[0-9.]+$", RegexOptions.IgnoreCase).Success)
            {
                await Application.Current.MainPage.DisplayAlert("", "Obim prsa mora biti broj!", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(ObimNoge) || !Regex.Match(ObimNoge, @"^[0-9.]+$", RegexOptions.IgnoreCase).Success)
            {
                await Application.Current.MainPage.DisplayAlert("", "Obim noge mora biti broj!", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(ObimStruka) || !Regex.Match(ObimStruka, @"^[0-9.]+$", RegexOptions.IgnoreCase).Success)
            {
                await Application.Current.MainPage.DisplayAlert("", "Obim struka mora biti broj!", "OK");
                return false;
            }
            if (string.IsNullOrEmpty(Tezina) || !Regex.Match(Tezina, @"^[0-9.]+$", RegexOptions.IgnoreCase).Success)
            {
                await Application.Current.MainPage.DisplayAlert("", "Tezina mora biti broj!", "OK");
                return false;
            }

            TjelesniDetaljiInsertRequest request = new TjelesniDetaljiInsertRequest
            {
                Datum = DateTime.Today,
                KorisnikId = APIService.UserId,
                ObimBicepsa = Double.Parse(ObimBicepsa),
                ObimNoge = Double.Parse(ObimNoge),
                ObimPrsa = Double.Parse(ObimPrsa),
                ObimStruka = Double.Parse(ObimStruka),
                Tezina = Double.Parse(Tezina)
            };
            await _tjelesniNapredakService.Insert<object>(request);
            return true;
        }

        public async Task<bool> FirstLogin()
        {
            TjelesniDetaljiSearchRequest request = new TjelesniDetaljiSearchRequest
            {
                KorisnikId = APIService.UserId
            };
            var tjelesniDetalji = await _tjelesniNapredakService.Get<List<Model.TjelesniDetalji>>(request);
            if (tjelesniDetalji.Count > 0)
                return false;
            return true;
        }
        public async Task Init()
        {
            First = await FirstLogin();
            if (First == true)
                FirstOP = false;
            else
                FirstOP = true;
        }
    }
}
