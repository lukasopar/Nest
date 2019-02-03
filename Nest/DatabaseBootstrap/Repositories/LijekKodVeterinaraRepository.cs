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
    public class LijekKodVeterinaraRepository : BasicRepository<LijekKodVeterinara>, ILijekKodVeterinaraRepository
    {

        public LijekKodVeterinaraRepository(ISession session) : base(session)
        {
        }

        public List<LijekKodVeterinara> DohvatiLijekoveVeterinara(int idVeterinara)
        {
            using (ITransaction transaction = _session.BeginTransaction())
            {
                IQueryable<LijekKodVeterinara> query = _session.Query<LijekKodVeterinara>().Where(item => item.Veterinar.Id == idVeterinara && item.Aktivno == true)
                    .Fetch(lijek => lijek.Lijek).AsQueryable();
                return query.ToList();
            }
        }
        
    }
}
