using DatabaseBootstrap.IRepositories;
using Nest.Model.Domain;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseBootstrap.Repositories
{
    public class VrstaPostupkaRepository : BasicRepository<VrstaPostupka>, IVrstaPostupkaRepository
    {
        public VrstaPostupkaRepository(ISession session) : base(session)
        {
        }
        public List<VrstaPostupka> DohvatiPostupkeVeterinara(int idVeterinar)
        {
            
            using (ITransaction transaction = _session.BeginTransaction())
            {
                var lista = _session.Query<VrstaPostupka>().Where(x => x.Veterinar.Id == idVeterinar && x.Aktivno == true).ToList();
                return lista;
            }
            
        }
    }
}
