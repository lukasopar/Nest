using DatabaseBootstrap.Repositories;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBootstrap.IRepositories
{
    public interface IPostupakRepository : IBasicRepository<Postupak>
    {
        List<Postupak> DohvatiSDetaljimaPostupakeZivotinja(int idZivotinja);
        List<Postupak> DohvatiSDetaljimaPostupakeNeplacene(int idVeterinar);

    }
}
