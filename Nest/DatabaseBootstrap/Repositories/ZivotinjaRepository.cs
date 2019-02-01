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
        public ZivotinjaRepository(ISession session) : base(session)
        {

        }
        public void AzurirajSNovomVrstom(Zivotinja entity, VrstaZivotinje vrsta)
        {
            
            using (ITransaction transaction = _session.BeginTransaction())
            {
                    
                _session.Update(entity);
                entity.PridruziVrstuZivotinjeKodVeterinara(vrsta);
                _session.Transaction.Commit();
            }
            
        }
        public List<Postupak> DohvatiZivotinjaPostupke(int id)
        {
           
            using (ITransaction transaction = _session.BeginTransaction())
            {

                var query = _session.Query<Postupak>().Where(p => p.Zivotinja.Id == id)
                    .Fetch(p => p.VrstaPostupka)
                    .ThenFetch(p => p.Veterinar)
                    .Fetch(p => p.Bolests)
                    .Fetch(p => p.Lijeks)
                    .OrderByDescending(p => p.Datum)
                    .ToList();
                return query;
                   
            }
            
        }
    }
}
