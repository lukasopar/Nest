using DatabaseBootstrap.Repositories;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBootstrap.IRepositories
{
    public interface IVlasnikRepository : IBasicRepository<Vlasnik>
    {
        List<Vlasnik> DohvatiSveVlasnike();
        List<Zivotinja> DohvatiVlasnikaSaZivotinjom(int id);
        Vlasnik DohvatiVlasnikaPrijava(string username, string password);
        Vlasnik DohvatiVlasnikaKorisnickoIme(string username);
        List<Zivotinja> DohvatiVlasnikoveZivotinje(int id);


    }
}
