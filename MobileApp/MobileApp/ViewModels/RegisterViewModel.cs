using MobileApp.Views;
using Model;
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
    public class RegisterViewModel : BaseViewModel
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

            if (string.IsNullOrWhiteSpace(Ime))
            {
                await Application.Current.MainPage.DisplayAlert("", "Ime je obavezno!", "OK");
                return;
            }
            else if (!Regex.Match(Ime, @"^[a-zA-ZČčĆćŽžĐđŠš ]+$", RegexOptions.IgnoreCase).Success)
            {
                await Application.Current.MainPage.DisplayAlert("", "Dovoljena su samo slova!", "OK");
                return;

            }
            else if (Ime.Length > 50)
            {
                await Application.Current.MainPage.DisplayAlert("", "Makismalna dozvoljena duzina imena je 50 karaktera!", "OK");
                return;

            }
            if (string.IsNullOrWhiteSpace(Prezime))
            {
                await Application.Current.MainPage.DisplayAlert("", "Prezime je obavezno!", "OK");
                return;
            }
            else if (!Regex.Match(Prezime, @"^[a-zA-ZČčĆćŽžĐđŠš ]+$", RegexOptions.IgnoreCase).Success)
            {
                await Application.Current.MainPage.DisplayAlert("", "Dovoljena su samo slova!", "OK");
                return;

            }
            else if (Prezime.Length > 50)
            {
                await Application.Current.MainPage.DisplayAlert("", "Makismalna dozvoljena duzina prezimena je 50 karaktera!", "OK");
                return;

            }
            if (string.IsNullOrEmpty(Spol))
            {
                await Application.Current.MainPage.DisplayAlert("", "Spol je obavezan!", "OK");
                return;
            }
            if (string.IsNullOrWhiteSpace(Email))
            {
                await Application.Current.MainPage.DisplayAlert("", "Email je obavezan!", "OK");
                return;
            }
            if (!Regex.Match(Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", RegexOptions.IgnoreCase).Success)
            {
                await Application.Current.MainPage.DisplayAlert("", "Neispravan format email-a!", "OK");
                return;
            }
            KorisniciSearchRequest emailrequest = new KorisniciSearchRequest
            {
                Email = Email
            };
            List<Model.Korisnik> korisnik = await _korisnikService.Get<List<Model.Korisnik>>(emailrequest);
            if (Telefon != null && !Regex.Match(Telefon, @"^[0-9]+$", RegexOptions.IgnoreCase).Success)
            {
                await Application.Current.MainPage.DisplayAlert("", "Dozvoljeni su samo brojevi!", "OK");
                return;
            }
            if (string.IsNullOrWhiteSpace(Username))
            {
                await Application.Current.MainPage.DisplayAlert("", "Username je obavezan!", "OK");
                return;
            }
            KorisniciSearchRequest usernamerequest = new KorisniciSearchRequest
            {
                Username = Username
            };
            korisnik = await _korisnikService.Get<List<Model.Korisnik>>(usernamerequest);
            if (korisnik.Count > 0)
            {
                await Application.Current.MainPage.DisplayAlert("", "Username je vec registrovan!", "OK");
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("", "Password je obavezan!", "OK");
                return;
            }
            if (Password.Length < 5)
            {
                await Application.Current.MainPage.DisplayAlert("", "Password mora sadrzavati minimalno 5 karaktera!", "OK");
                return;
            }
            if (Password != PasswordConfirmation)
            {
                await Application.Current.MainPage.DisplayAlert("", "Passwordi se ne slazu!", "OK");
                return;
            }

            if (korisnik.Count > 0)
            {
                await Application.Current.MainPage.DisplayAlert("", "Email je vec registrovan!", "OK");
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
                Uloga = "AppUser",
                Username = Username,
                Password = Password
            };
            await _korisnikService.Insert<Korisnik>(request);
            Application.Current.MainPage = new LoginPage();
        }
    }
}
