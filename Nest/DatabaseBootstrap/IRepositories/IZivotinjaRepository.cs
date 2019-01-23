using DatabaseBootstrap.Repositories;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBootstrap.IRepositories
{
    public interface IZivotinjaRepository : IBasicRepository<Zivotinja>
    {
        void AzurirajSNovomVrstom(Zivotinja entity, VrstaZivotinje vrsta);
        List<Postupak> DohvatiZivotinjaPostupke(int id);

    }
}
