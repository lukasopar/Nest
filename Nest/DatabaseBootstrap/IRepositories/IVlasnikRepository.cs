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
        IList<Zivotinja> DohvatiVlasnikaSaZivotinjom(int id);
    }
}
