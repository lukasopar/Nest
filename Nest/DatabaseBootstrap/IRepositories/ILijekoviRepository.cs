using DatabaseBootstrap.Repositories;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseBootstrap.IRepositories
{
    public interface ILijekoviRepository : IBasicRepository<Lijek>
    {
        Lijek DohvatiLijekPoId(int id);
    }
}
