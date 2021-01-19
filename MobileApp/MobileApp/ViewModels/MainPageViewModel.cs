using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileApp.ViewModels
{
    public class MainPageViewModel:BaseViewModel
    {
        private bool _clan;
        public bool Clan
        {
            get { return _clan; }
            set { SetProperty(ref _clan, value); }
        }
        private int _brojPrisutnih;
        public int BrojPrisutnih {
            get { return _brojPrisutnih; }
            set { SetProperty(ref _brojPrisutnih, value); }
        }
        private readonly APIService _prisutniClanoviService = new APIService("PrisutnostClana");
        public MainPageViewModel() { }
        public async Task Prisutni()
        {
            try
            {
                var prisutni = await _prisutniClanoviService.Get<List<Model.PrisutnostClana>>(null);
                BrojPrisutnih = prisutni.Count;
                Clan = true;
            }
            catch(Exception ex)
            {
                Clan = false;
            }
        }
    }
}
