using Model;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModels
{
    public class DanDetailsViewModel:BaseViewModel
    {
        private readonly APIService _danSetService = new APIService("DanSet");
        private readonly APIService _setVjezbaService = new APIService("SetVjezba");
        public DanDetailsViewModel()
        {

        }
        public ObservableCollection<DanSet> DanSetovi { get; set; } = new ObservableCollection<DanSet>();
        public Dan Dan { get; set; }
        public ObservableCollection<SetVjezba> SetVjezbe { get; set; } = new ObservableCollection<SetVjezba>();
        public async Task LoadDanSetovi()
        {
            DanSetovi.Clear();
            DanSetSearchRequest request = new DanSetSearchRequest
            {
                DanId = Dan.Id
            };
            List<DanSet> list = await _danSetService.Get<List<DanSet>>(request);
            if(list.Count > 0)
            {
                foreach(var x in list)
                {
                    DanSetovi.Add(x);
                }
            }
        }
        public async Task LoadSetVjezbe()
        {
            if (DanSetovi.Count > 0)
            {
                
                foreach(var x in DanSetovi)
                {
                    SetVjezbaSearchRequest setVjezbaSearchRequest = new SetVjezbaSearchRequest
                    {
                        DanSetId = x.Id
                    };
                    List<SetVjezba> setVjezbe = await _setVjezbaService.Get<List<SetVjezba>>(setVjezbaSearchRequest);
                    foreach(var y in setVjezbe)
                    {
                        y.VjezbaId = x.VjezbaId;
                        SetVjezbe.Add(y);
                    }

                }
            }
        }

    }
}
