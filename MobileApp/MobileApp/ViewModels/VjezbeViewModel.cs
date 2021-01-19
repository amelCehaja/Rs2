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
    public class VjezbeViewModel:BaseViewModel
    {
        private readonly APIService _vjezbaService = new APIService("Vjezba");
        private readonly APIService _misicService = new APIService("Misic");
        public VjezbeViewModel()
        {
            LoadCommand = new Command(async () => await LoadVjezbe());
        }
        Misic _misic = null;
        public Misic Misic
        {
            get { return _misic; }
            set
            {
                SetProperty(ref _misic, value);
                if(value!= null)
                {
                    LoadCommand.Execute(null);
                }
            }
        }
        public ObservableCollection<Misic> Misici { get; set; } = new ObservableCollection<Misic>();
        public ObservableCollection<Vjezba> Vjezbe { get; set; } = new ObservableCollection<Vjezba>();
        public ICommand LoadCommand { get; set; }
        public async Task LoadVjezbe()
        {
            VjezbaSearchRequest request = null;
            Vjezbe.Clear();
            if (Misic != null)
            {
                request = new VjezbaSearchRequest
                {
                    Misic = Misic.Naziv
                };
            }
            List<Model.Vjezba> _vjezbe = await _vjezbaService.Get<List<Model.Vjezba>>(request);
            if(_vjezbe.Count > 0)
            {
                foreach(var x in _vjezbe)
                {
                    Vjezbe.Add(x);
                }
            }
        }
        public async Task LoadMisici()
        {
            Misici.Clear();
            List<Misic> list = await _misicService.Get<List<Misic>>(null);
            if(list.Count > 0)
            {
                foreach(var x in list)
                {
                    Misici.Add(x);
                }
            }
        }
    }
}
