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
    public class PlanoviViewModel
    {
        private readonly APIService _recommenderService = new APIService("Recommender");
        private readonly APIService _tjelesniDetalji = new APIService("TjelesniDetalji");
        public PlanoviViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public Model.Recomender recomender { get; set; } = new Recomender();
        public ObservableCollection<PlanIProgram> RecomendPlanoviList { get; set; } = new ObservableCollection<PlanIProgram>();
        public ObservableCollection<PlanIProgram> OtherPlanoviList { get; set; } = new ObservableCollection<PlanIProgram>();

        public ICommand InitCommand { get; set; }
        public async Task Init()
        {
            RecomendPlanoviList.Clear();
            OtherPlanoviList.Clear();
            TjelesniDetaljiSearchRequest detaljiSearchRequest = new TjelesniDetaljiSearchRequest { KorisnikId = APIService.UserId };
            var tjelesniDetalji = await _tjelesniDetalji.Get<List<TjelesniDetalji>>(detaljiSearchRequest);
            int id = tjelesniDetalji[0].Id;
            RecommenderRequest recommenderRequest = new RecommenderRequest
            {
                TjelesniDetaljiId = id
            };
            recomender = await _recommenderService.Get<Model.Recomender>(recommenderRequest);
            foreach(var x in recomender.Recommended)
            {
                RecomendPlanoviList.Add(x);
            }
            foreach(var x in recomender.Other)
            {
                OtherPlanoviList.Add(x);
            }
        }
    }
}
