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
        public List<VrstaZivotinje> DohvatiSveVrsteVeterinar(int id)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    
                    var entity = session.Query<VrstaZivotinje>().Where(x => x.Veterinar.Id == id).ToList();
                    return entity;
                }
            }
        }
        public VrstaZivotinje DohvatiVrstuZivotinjeKodVeterinara(int idZivotinja, int idVeterinar)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var ziv = session.Query<Zivotinja>().Where(zivotinja => zivotinja.Id == idZivotinja).FetchMany(Zivotinja => Zivotinja.VrstaZivotinjes).ThenFetch(v => v.Veterinar).SingleOrDefault();
                    var vrsta = ziv.VrstaZivotinjes.Where(v => v.Veterinar.Id == idVeterinar).SingleOrDefault();
                    return vrsta;
                }            }
        }
        public List<VrstaPostupka> DohvatiSvePostupke(int id)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var query = session.Query<VrstaPostupka>().Where(vrsta => vrsta.Veterinar.Id == id && vrsta.Aktivno == true).ToList();
                    return query;
                }            }
        }
        public List<LijekKodVeterinara> DohvatiSveLijekoveKodVeterinara(int id)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var query = session.Query<LijekKodVeterinara>().Where(x => x.Veterinar.Id == id)
                        .Fetch(x => x.Lijek)
                        .ToList();
                    return query;
                }            }
        }

    }
}
