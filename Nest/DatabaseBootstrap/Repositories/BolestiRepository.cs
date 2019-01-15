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
        public Bolest DohvatiPrekoIDSLijekovima(int id)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var entity = session.Query<Bolest>().Where(x => x.Id == id).Fetch(x => x.Lijeks);
                    return entity.FirstOrDefault();
                }
            }
            
        }

    }
}
