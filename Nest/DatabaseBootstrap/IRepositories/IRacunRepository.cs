using DatabaseBootstrap.Repositories;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBootstrap.IRepositories
{
    public interface IRacunRepository : IBasicRepository<Racun>
    {
        List<Racun> DohvatiSveRacune(int id);

    }
}
