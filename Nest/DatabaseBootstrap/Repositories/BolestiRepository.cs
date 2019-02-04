using DatabaseBootstrap.IRepositories;
using Nest.Model.Domain;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseBootstrap.Repositories
{
    public class StavkeRepository : BasicRepository<LijekStavkaRacuna>, IStavkeRepository
    {

        public StavkeRepository(ISession session) : base(session)
        {  
        }
       

    }
}
