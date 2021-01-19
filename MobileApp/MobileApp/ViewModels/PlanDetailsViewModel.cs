using MobileApp.Views;
using Model;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileApp.ViewModels
{
    public class PlanDetailsViewModel:BaseViewModel
    {
        private readonly APIService _ocjenaService = new APIService("Ocjena");
        private readonly APIService _korisnikPlanService = new APIService("KorisnikPlan");
        private readonly APIService _clanarinaService = new APIService("Clanarina");
        public PlanDetailsViewModel()
        {
            
        }
        public PlanIProgram PlanIProgram { get; set; }
        string _ocjena = string.Empty;
        public string Ocjena
        {
            get { return _ocjena; }
            set { SetProperty(ref _ocjena, value); }
        }
        private bool _ocijenjen;
        public bool Ocijenjen
        {
            get { return _ocijenjen; }
            set { SetProperty(ref _ocijenjen, value); }
        }
        public async Task ProvjeraOcjene()
        {
            Model.Requests.OcjenaSearchRequest request = new Model.Requests.OcjenaSearchRequest
            {
                PlanId = PlanIProgram.Id,
                KorisnikId = APIService.UserId
            };
            var ocjene = await _ocjenaService.Get<List<Ocjena>>(request);
            if(ocjene.Count > 0)
                Ocijenjen = false;
            else
                Ocijenjen = true;
            if (Posjeduje == false)
                Ocijenjen = false;
        }
        private bool _posjeduje;
        public bool Posjeduje
        {
            get { return _posjeduje; }
            set { SetProperty(ref _posjeduje, value); }
        }
        private bool _posjedujeOposite;
        public bool PosjedujeOposite
        {
            get { return _posjedujeOposite; }
            set { SetProperty(ref _posjedujeOposite, value); }
        }
        public async Task ProvjeraPOsjedovanja()
        {
            KorisnikPlanSearchRequest request = new KorisnikPlanSearchRequest
            {
                KorisnikId = APIService.UserId,
                PlanId = PlanIProgram.Id
            };
            List<KorisnikPlan> korisnikPlanovi = await _korisnikPlanService.Get<List<KorisnikPlan>>(request);
            if (korisnikPlanovi.Count > 0)
            {
                Posjeduje = true;
                PosjedujeOposite = false;
            }
            else
            {
                Posjeduje = false;
                PosjedujeOposite = true;
            }

            ClanarinaSearchRequest clanarinaSearchRequest = new ClanarinaSearchRequest
            {
                KorisnikId = APIService.UserId
            };
            List<Model.Clanarina> clanarine = await _clanarinaService.Get<List<Model.Clanarina>>(clanarinaSearchRequest);
            if(clanarine.Count > 0)
            {
                foreach(var x in clanarine)
                {
                    if(x.DatumDodavanja<= DateTime.Today && x.DatumIsteka >= DateTime.Today)
                    {
                        Posjeduje = true;
                    }
                }
            }
            

        }
        public ICommand Ocijeni { get; set; }
        public ObservableCollection<Ocjena> Ocjene { get; set; } = new ObservableCollection<Ocjena>();
        public async Task GetOcjene()
        {
            Model.Requests.OcjenaSearchRequest request = new Model.Requests.OcjenaSearchRequest
            {
                PlanId = PlanIProgram.Id
            };
            double avgOcjena = 0;
            var list = await _ocjenaService.Get<List<Ocjena>>(request);
            Ocjene.Clear();
            if (list.Count > 0)
            {
                foreach (var x in list)
                {
                    x.DatumVrijemeString = x.Datum.ToString("dd.MM.yyyy") + " - " + x.Vrijeme.ToString();
                    Ocjene.Add(x);
                }
                avgOcjena = Math.Round(list.Average(x => x.Rating), 1);
            }
            Ocjena = "Ocjena: " + avgOcjena.ToString() + " / 5" + " ("+list.Count()+")";
        }      
    }
}
