using DatabaseBootstrap.Repositories;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBootstrap.IRepositories
{
    public interface IPostupakRepository : IBasicRepository<Postupak>
    {
        List<Postupak> DohvatiSDetaljimaPostupkeZivotinja(int idZivotinja);
        List<Postupak> DohvatiSDetaljimaPostupkeNeplacene(int idVeterinar);
        List<Postupak> DohvatiSDetaljimaPostupkePoDatumu(int idVeterinar, DateTime datum);

    }
}
