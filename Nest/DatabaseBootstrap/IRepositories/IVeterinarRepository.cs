using DatabaseBootstrap.Repositories;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBootstrap.IRepositories
{
    public interface IVeterinarRepository : IBasicRepository<Veterinar>
    {
        Veterinar DohvatiVeterinaraPrijava(string username, string password);
        List<VrstaZivotinje> DohvatiSveVrsteVeterinar(int id);
        VrstaZivotinje DohvatiVrstuZivotinjeKodVeterinara(int idZivotinja, int idVeterinar);
        List<VrstaPostupka> DohvatiSvePostupke(int id);
    }
}
