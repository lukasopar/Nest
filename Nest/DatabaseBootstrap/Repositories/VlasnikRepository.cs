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

        public IList<Zivotinja> DohvatiVlasnikaSaZivotinjom(int id)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var query = session.Query<Vlasnik>().Where(vlasnik => vlasnik.Id == id).FetchMany(vlasnik => vlasnik.Zivotinjas).SingleOrDefault();
                    return query.Zivotinjas;
                }            }
            
        }
        public Vlasnik DohvatiVlasnikaPrijava(string username, string password)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Vlasnik entity = session.Query<Vlasnik>().Where(x => x.KorisnickoIme.Equals(username) && x.Lozinka.Equals(password)).SingleOrDefault();
                    return entity;
                }
            }
        }
    }
}
