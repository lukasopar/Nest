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
    public class VlasnikRepository : BasicRepository<Vlasnik>, IVlasnikRepository
    {
        public List<Vlasnik> DohvatiSveVlasnike()
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IQueryable<Vlasnik> query = session.Query<Vlasnik>().Fetch(vlasnik => vlasnik.Zivotinjas).AsQueryable();
                    return query.ToList();
                }            }        }
    }
}
