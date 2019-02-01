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
    public class RacunRepository : BasicRepository<Racun>, IRacunRepository
    {
        public RacunRepository(ISession session) : base(session)
        {
        }
        public List<Racun> DohvatiSveRacune(int id)
        {
            
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    var query = _session.Query<Racun>()
                        .Where(r => r.LijekStavkaRacunas.Select(l => l.LijekKodVeterinara.Veterinar.Id).FirstOrDefault() == id || r.Postupaks.Select(p => p.VrstaPostupka.Veterinar.Id).FirstOrDefault() == id)
                        .FetchMany(r => r.LijekStavkaRacunas)
                        .ThenFetch(r => r.LijekKodVeterinara)
                        .ThenFetch(r => r.Lijek)
                        .FetchMany(r => r.Postupaks)
                        .ThenFetch(r => r.VrstaPostupka)
                        .ToList();
                    return query;
                }            
        }
    }
}
