using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModels
{
    public class LiveTreningVjezbaViewModel:BaseViewModel
    {
        private readonly APIService _vjezbaService = new APIService("Vjezba");
        public LiveTreningVjezbaViewModel()
        {

        }
        public ObservableCollection<Model.SetVjezba> SetVjezbe { get; set; } = new ObservableCollection<Model.SetVjezba>();
        
        
        private string _brojPonavljanja = String.Empty;
        public string BrojPonavljanja {
            get { return _brojPonavljanja; }
            set { SetProperty(ref _brojPonavljanja, value); }
        }
        private Vjezba _vjezba = new Vjezba();
        public Vjezba Vjezba
        {
            get { return _vjezba; }
            set { SetProperty(ref _vjezba, value); }
        }
        public async Task LoadVjezba()
        {
            Vjezba = await _vjezbaService.GetById<Vjezba>(SetVjezbe[0].VjezbaId);
            BrojPonavljanja = SetVjezbe[0].BrojPonavljanja.ToString();
        }
    

    }
}
