using MobileApp.Views;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("korisnik");
        private readonly APIService _detaljiService = new APIService("tjelesniDetalji");
        public LoginViewModel()
        {
            RegisterCommand = new Command(() =>
            {
                Application.Current.MainPage = new RegisterPage();
            });
            LoginCommand = new Command(async () =>
            {
                await Login();
            });
        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand RegisterCommand { get; set; }
        public ICommand LoginCommand { get; set; }

        async Task Login()
        {
            IsBusy = true;
            try
            {
                APIService.Username = Username;
                APIService.Password = Password;
                KorisniciSearchRequest korisniciSearchRequest = new KorisniciSearchRequest
                {
                    Uloga = "Sve"
                };
                List<Model.Korisnik> korisnici = await _service.Get<List<Model.Korisnik>>(korisniciSearchRequest);
                APIService.UserId = korisnici.Where(x => x.Username == Username).Select(x => x.Id).SingleOrDefault();
                TjelesniDetaljiSearchRequest request = new TjelesniDetaljiSearchRequest
                {
                    KorisnikId = APIService.UserId
                };
                List<Model.TjelesniDetalji> detaljiList = await _detaljiService.Get<List<Model.TjelesniDetalji>>(request);
                if (detaljiList.Count == 0)
                    Application.Current.MainPage = new TjelesniNapredakAdd();
                else
                    Application.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
