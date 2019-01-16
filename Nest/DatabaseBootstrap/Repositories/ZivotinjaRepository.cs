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
    }
}
