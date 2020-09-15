using MobileApp.Views;
using Model;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class RegisterViewModel:BaseViewModel
    {
        private APIService _korisnikService = new APIService("Korisnik");
        public RegisterViewModel()
        {
            RegisterCommand = new Command(async () => { await Register(); });
        }
        string _ime = string.Empty;
        public string Ime
        {
            get { return _ime; }
            set { SetProperty(ref _ime, value); }
        }
        string _prezime = string.Empty;
        public string Prezime
        {
            get { return _prezime; }
            set { SetProperty(ref _prezime, value); }
        }
        DateTime _datumRodenja = DateTime.Today;
        public DateTime DatumRodenja
        {
            get { return _datumRodenja; }
            set { SetProperty(ref _datumRodenja, value); }
        }
        string _spol = string.Empty;
        public string Spol
        {
            get { return _spol; }
            set { SetProperty(ref _spol, value); }
        }
        string _telefon = string.Empty;
        public string Telefon
        {
            get { return _telefon; }
            set { SetProperty(ref _telefon, value); }
        }
        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
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
        string _passwordConfirmation = string.Empty;
        public string PasswordConfirmation
        {
            get { return _passwordConfirmation; }
            set { SetProperty(ref _passwordConfirmation, value); }
        }
        public ICommand RegisterCommand { get; set; }
        async Task Register()
        {
            IsBusy = true;
            if(Password != PasswordConfirmation)
            {
                await Application.Current.MainPage.DisplayAlert("", "Passwordi se ne slazu!", "OK");
                return;
            }
            Model.Requests.KorisnikInsertRequest request = new Model.Requests.KorisnikInsertRequest
            {
                Ime = Ime,
                Prezime = Prezime,
                DatumRodenja = DatumRodenja,
                Spol = Spol,
                Email = Email,
                Telefon = Telefon,
                Uloga = "MobKorisnik",
                Username = Username,
                Password = Password
            };
            await _korisnikService.Insert<Korisnik>(request);
            Application.Current.MainPage = new LoginPage();
        }
    }
}
