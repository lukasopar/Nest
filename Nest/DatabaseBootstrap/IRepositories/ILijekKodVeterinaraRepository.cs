using DatabaseBootstrap.Repositories;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBootstrap.IRepositories
{
    public interface ILijekKodVeterinaraRepository : IBasicRepository<LijekKodVeterinara>
    {
        List<LijekKodVeterinara> DohvatiLijekoveVeterinara(int idVeterinara);
    }
}
