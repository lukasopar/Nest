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
    public class BolestiRepository : BasicRepository<Bolest>, IBolestiRepository
    {

        public BolestiRepository(ISession session) : base(session)
        {  
        }
        public Bolest DohvatiPrekoIDSLijekovima(int id)
        {
            
            using (ITransaction transaction = _session.BeginTransaction())
            {
                var entity = _session.Query<Bolest>().Where(x => x.Id == id).Fetch(x => x.Lijeks);
                return entity.FirstOrDefault();
            }
            
            
        }

    }
}
