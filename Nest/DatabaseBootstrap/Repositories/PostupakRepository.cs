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
    public class PostupakRepository : BasicRepository<Postupak>, IPostupakRepository
    {
        public List<Postupak> DohvatiSDetaljimaPostupkeZivotinja(int idZivotinja)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var lista = session.Query<Postupak>().Where(x => x.Zivotinja.Id == idZivotinja)
                        .Fetch(x => x.Zivotinja)
                        .Fetch(x => x.VrstaPostupka)
                        .FetchMany(x => x.Lijeks)
                        .FetchMany(x => x.Bolests)
                        .ToList();
                    return lista;
                }
            }
        }
        public List<Postupak> DohvatiSDetaljimaPostupkeNeplacene(int idVeterinar)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var lista = session.Query<Postupak>().Where(x => x.VrstaPostupka.Veterinar.Id == idVeterinar && x.Racun == null)
                        .Fetch(x => x.Zivotinja)
                        .Fetch(x => x.VrstaPostupka)
                        .FetchMany(x => x.Lijeks)
                        .FetchMany(x => x.Bolests)
                        .ToList();
                    return lista;
                }
            }
        }
        public List<Postupak> DohvatiSDetaljimaPostupkePoDatumu(int idVeterinar, DateTime datum)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var lista = session.Query<Postupak>().Where(x => x.VrstaPostupka.Veterinar.Id == idVeterinar && x.Datum.Value.Date.Equals(datum.Date))
                        .Fetch(x => x.Zivotinja)
                        .Fetch(x => x.VrstaPostupka)
                        .FetchMany(x => x.Lijeks)
                        .FetchMany(x => x.Bolests)
                        .ToList();
                    return lista;
                }
            }
        }
    }
}
