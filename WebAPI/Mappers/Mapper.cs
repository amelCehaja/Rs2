using AutoMapper;
using Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Korisnik, Model.Korisnik>();
            CreateMap<KorisnikInsertRequest, Database.Korisnik>();
            CreateMap<Database.TipClanarine, Model.TipClanarine>();
            CreateMap<TipClanarineInsertRequest, Database.TipClanarine>();
            CreateMap<Database.Clanarina, Model.Clanarina>();
            CreateMap<ClanarinaInsertRequest, Database.Clanarina>();
            CreateMap<Database.PrisutnostClana, Model.PrisutnostClana>();
            CreateMap<PrisutnostClanaInsertRequest, Database.PrisutnostClana>();
            CreateMap<Database.Misic, Model.Misic>();
            CreateMap<Model.Misic, Database.Misic>();
            CreateMap<MisicInsertRequest, Database.Misic>();
            CreateMap<Database.Vjezba, Model.Vjezba>();
            CreateMap<VjezbaInsertRequest, Database.Vjezba>();
            CreateMap<PlanIProgramInsertRequest, Database.PlanIprogram>();
            CreateMap<Database.PlanIprogram, Model.PlanIProgram>();
            CreateMap<Database.Dan, Model.Dan>();
            CreateMap<DanInsertRequest, Database.Dan>();
            CreateMap<Database.DanSet, Model.DanSet>();
            CreateMap<Database.DanSet, Model.DanSet>();
            CreateMap<DanSetInsertRequest, Database.DanSet>();
            CreateMap<Database.SetVjezba, Model.SetVjezba>();
            CreateMap<SetVjezbaInsertRequest, Database.SetVjezba>();
            CreateMap<ICollection<Database.KorisnikUloga>, ICollection<Model.KorisniciUloge>>();
            CreateMap<Database.Ocjena, Model.Ocjena>();
            CreateMap<Model.Ocjena, Database.Ocjena>();
            CreateMap<OcjenaInsertRequest, Database.Ocjena>();
            CreateMap<Model.Komentar, Database.Komentar>();
            CreateMap<Database.Komentar, Model.Komentar>();
            CreateMap<KomentarInsertRequest, Database.Komentar>();
            CreateMap<Model.TjelesniDetalji, Database.TjelesniDetalji>();
            CreateMap<Database.TjelesniDetalji, Model.TjelesniDetalji>();
            CreateMap<TjelesniDetaljiInsertRequest, Database.TjelesniDetalji>();
            CreateMap<Model.KorisnikPlan, Database.KorisnikPlanIprogram>();
            CreateMap<Database.KorisnikPlanIprogram, Model.KorisnikPlan>();
            CreateMap<Model.KorisnikPlan, Database.KorisnikPlanIprogram>();
            CreateMap<Database.KorisnikPlanIprogram, Model.KorisnikPlan>();
            CreateMap<KorisnikPlanInsertRequest, Database.KorisnikPlanIprogram>();
            CreateMap<Database.PlanKategorija, Model.PlanKategorija>();
            CreateMap<Model.PlanKategorija, Database.PlanKategorija>();
            CreateMap<KorisnikUpdateRequest, Database.Korisnik>();
        }
    }
}
