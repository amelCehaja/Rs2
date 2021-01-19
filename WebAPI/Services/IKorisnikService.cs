using Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public interface IKorisnikService
    {
        List<Model.Korisnik> Get(KorisniciSearchRequest request);
        Model.Korisnik Insert(KorisnikInsertRequest request);
        Model.Korisnik GetByID(int id);
        Model.Korisnik Update(int id, KorisnikUpdateRequest request);
        Model.Korisnik Authenticiraj(string username, string pass);
        Model.Korisnik GetByBrojKartice(string brojKartice);
    }
}
