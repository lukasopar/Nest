using DatabaseBootstrap.IRepositories;
using Nest.Model.Domain;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseBootstrap.Repositories
{
    public class VrstaPostupkaRepository : BasicRepository<VrstaPostupka>, IVrstaPostupkaRepository
    {
        public List<VrstaPostupka> DohvatiPostupkeVeterinara(int idVeterinar)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var lista = session.Query<VrstaPostupka>().Where(x => x.Veterinar.Id == idVeterinar && x.Aktivno == true).ToList();
                    return lista;
                }
            }
        }
    }
}
