using Model;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModels
{
    public class DanViewModel:BaseViewModel
    {
        private readonly APIService _danService = new APIService("Dan");
        public DanViewModel()
        {

        }
        public ObservableCollection<Dan> Dani { get; set; } = new ObservableCollection<Dan>();
        public PlanIProgram PlanIProgram { get; set; }
        public async Task LoadDani()
        {
            Dani.Clear();
            DanSearchRequest request = new DanSearchRequest
            {
                PlanIProgramId = PlanIProgram.Id
            };
            List<Dan> _dani = await _danService.Get<List<Dan>>(request);
            if(_dani.Count > 0)
            {
                foreach(var x in _dani)
                {
                    x.Naziv = "Dan " + x.RedniBroj.ToString();
                    Dani.Add(x);
                }
            }
        }
    }
}
