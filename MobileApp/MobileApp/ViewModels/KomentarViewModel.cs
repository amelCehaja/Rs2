using Model;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class KomentarViewModel:BaseViewModel
    {
        private readonly APIService _komentarService = new APIService("Komentar");
        public KomentarViewModel()
        {
            PitanjeCommand = new Command(async () => await PostaviPitanje());
        }
        int _planId;
        public int PlanId
        {
            get { return _planId; }
            set { SetProperty(ref _planId, value); }
        }
        string _pitanje = string.Empty;
        public string Pitanje
        {
            get { return _pitanje; }
            set { SetProperty(ref _pitanje, value); }
        }
        public ICommand PitanjeCommand { get; set; }
        public ObservableCollection<Model.Komentar> Komentari { get; set; } = new ObservableCollection<Model.Komentar>();
        public async Task LoadKomentare()
        {
            Komentari.Clear();
            KomentarSearchRequest request = new KomentarSearchRequest
            {
                PlanId = PlanId
            };
            List<Komentar> list = await _komentarService.Get<List<Komentar>>(request);
            if(list.Count > 0)
            {
                foreach(var x in list)
                {
                    x.ImePrezime = x.Korisnik.Ime + " " + x.Korisnik.Prezime;
                    x.DatumString = x.Datum.ToString("dd.MM.yyyy");
                    Komentari.Add(x);
                }
            }
        }
        public async Task PostaviPitanje()
        {
            KomentarInsertRequest request = new KomentarInsertRequest
            {
                Opis = Pitanje,
                Datum = DateTime.Today,
                KorisnikId = APIService.UserId,
                PlanId = PlanId
            };
            await _komentarService.Insert<object>(request);
            await Application.Current.MainPage.DisplayAlert("", "Uspjesno ste postavili pitanje!", "OK");
            await LoadKomentare();
        }
    }
}
