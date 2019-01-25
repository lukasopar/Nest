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
        public List<VrstaZivotinje> DohvatiVrsteVeterinara(int idVeterinara)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IQueryable<VrstaZivotinje> query = session.Query<VrstaZivotinje>().Where(item => item.Veterinar.Id == idVeterinara && item.Aktivno == true)
                        .AsQueryable();
                    return query.ToList();
                }            }
        }
    }
}
