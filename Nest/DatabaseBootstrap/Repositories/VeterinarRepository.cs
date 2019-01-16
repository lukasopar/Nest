using DatabaseBootstrap.IRepositories;
using Nest.Model.Domain;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseBootstrap.Repositories
{
    public class VeterinarRepository : BasicRepository<Veterinar>, IVeterinarRepository
    {
        public Veterinar DohvatiVeterinaraPrijava(string username, string password)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Veterinar entity = session.Query<Veterinar>().Where(x => x.KorisnickoIme.Equals(username) && x.Lozinka.Equals(password)).SingleOrDefault();
                    return entity;
                }
            }
        }
    }
}
