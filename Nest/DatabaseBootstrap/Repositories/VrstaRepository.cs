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
    public class VrstaRepository : BasicRepository<VrstaZivotinje>, IVrstaRepository
    {
        public VrstaRepository(ISession session) : base(session)
        {
        }
        public List<VrstaZivotinje> DohvatiVrsteVeterinara(int idVeterinara)
        {
            
            using (ITransaction transaction = _session.BeginTransaction())
            {
                IQueryable<VrstaZivotinje> query = _session.Query<VrstaZivotinje>().Where(item => item.Veterinar.Id == idVeterinara && item.Aktivno == true)
                    .AsQueryable();
                return query.ToList();
            }            
        }
    }
}
