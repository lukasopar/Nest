using DatabaseBootstrap.IRepositories;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBootstrap.Repositories
{
    public class PostupakRepository : BasicRepository<Postupak>, IPostupakRepository
    {
    }
}
