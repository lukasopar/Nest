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
    public class ZivotinjaRepository : BasicRepository<Zivotinja>, IZivotinjaRepository
    {
        public void AzurirajSNovomVrstom(Zivotinja entity, VrstaZivotinje vrsta)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    
                    session.Update(entity);
                    entity.PridruziVrstuZivotinjeKodVeterinara(vrsta);
                    session.Transaction.Commit();
                }
            }
        }
        public List<Postupak> DohvatiZivotinjaPostupke(int id)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {

                    var query = session.Query<Postupak>().Where(p => p.Zivotinja.Id == id)
                        .Fetch(p => p.VrstaPostupka)
                        .ThenFetch(p => p.Veterinar)
                        .Fetch(p => p.Bolests)
                        .Fetch(p => p.Lijeks)
                        .ToList();
                    return query;
                   
                }
            }
        }
    }
}
