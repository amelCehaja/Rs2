using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Database;

namespace WebAPI.Services
{
    public class RecommenderService : IRecommender
    {
        private readonly RS2Context _context;
        private readonly IMapper _mapper;
        public RecommenderService(RS2Context rS2Context, IMapper mapper)
        {
            _context = rS2Context;
            _mapper = mapper;
        }
        public Model.Recomender Get(int tjelesniDetaljiId)
        {
            Database.TjelesniDetalji tjelesniDetalji = _context.TjelesniDetalji.Find(tjelesniDetaljiId);
            
            List<Database.PlanIprogram> recomendedList = new List<Database.PlanIprogram>();
            List<Database.PlanIprogram> otherList = new List<Database.PlanIprogram>();
            List<Database.PlanIprogram> planList = _context.PlanIprogram.Include(x => x.Kategorija).ToList();
            foreach (var plan in planList)
            {
                List<int> ocjene = new List<int>();

                List<Database.KorisnikPlanIprogram> korisnikPlanList = _context.KorisnikPlanIprogram.Include(x => x.TjelesniDetalji).Where(x => x.PlanId == plan.Id).ToList();
                foreach (var x in korisnikPlanList)
                {
                    var _tezinaRazlika = tjelesniDetalji.Tezina - x.TjelesniDetalji.Tezina;
                    var _bicepsRazlika = tjelesniDetalji.ObimBicepsa - x.TjelesniDetalji.ObimBicepsa;
                    var _strukRazlika = tjelesniDetalji.ObimStruka - x.TjelesniDetalji.ObimStruka;
                    var _nogaRazlika = tjelesniDetalji.ObimNoge - x.TjelesniDetalji.ObimNoge;
                    var _prsaRazlika = tjelesniDetalji.ObimPrsa - x.TjelesniDetalji.ObimPrsa;
                    if (_tezinaRazlika < 10 && _tezinaRazlika > -10 &&
                        _bicepsRazlika < 10 && _bicepsRazlika > -10 &&
                        _nogaRazlika < 15 && _nogaRazlika > -15 &&
                        _prsaRazlika < 15 && _prsaRazlika > -15 &&
                        _strukRazlika < 15 && _strukRazlika > -15)
                    {
                        Database.Ocjena ocjena = _context.Ocjena.Where(y => y.PlanId == plan.Id && y.KorisnikId == x.KorisnikId).FirstOrDefault();
                        if(ocjena != null)
                        {
                            ocjene.Add(ocjena.Rating);
                        }
                    }
                }
                if(ocjene.Count != 0)
                {
                    if(ocjene.Average() > 3)
                    {
                        recomendedList.Add(plan);
                    }
                    else
                    {
                        otherList.Add(plan);
                    }
                }
                else
                {
                    otherList.Add(plan);
                }
            }
            Model.Recomender model = new Recomender
            {
                Recommended = _mapper.Map<List<Model.PlanIProgram>>(recomendedList),
                Other = _mapper.Map<List<Model.PlanIProgram>>(otherList)
            };
            foreach(var x in model.Recommended)
            {
                x.Kategorija = _context.PlanKategorija.Where(y => y.Id == x.KategorijaId).Select(y => y.Naziv).SingleOrDefault();
            }
            foreach (var x in model.Other)
            {
                x.Kategorija = _context.PlanKategorija.Where(y => y.Id == x.KategorijaId).Select(y => y.Naziv).SingleOrDefault();
            }
            return model;
        }
    }
}
