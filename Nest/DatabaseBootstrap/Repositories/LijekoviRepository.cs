using DatabaseBootstrap;
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
    public class LijekoviRepository : BasicRepository<Lijek>, ILijekoviRepository
    {
        public Lijek DohvatiLijekPoId(int id)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Lijek query = session.Query<Lijek>().Where(lijek => lijek.Id == id).Fetch(lijek => lijek.Bolests)
                        .FetchMany(lijek => lijek.InterakcijaLijekovas2)
                        .ThenFetch(lijek => lijek.Lijek1)
                        .FetchMany(lijek => lijek.InterakcijaLijekovas2)
                        .ThenFetch(lijek => lijek.Lijek2)
                        .FetchMany(lijek => lijek.InterakcijaLijekovas1)
                        .ThenFetch(lijek => lijek.Lijek1)
                        .FetchMany(lijek => lijek.InterakcijaLijekovas1)
                        .ThenFetch(lijek => lijek.Lijek2)
                        .FirstOrDefault();
                    return query;
                }
            }
        }
    }
}
