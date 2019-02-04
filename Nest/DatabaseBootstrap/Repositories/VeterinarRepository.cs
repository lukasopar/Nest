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
        public VeterinarRepository(ISession session) : base(session)
        {
        }
        public Veterinar DohvatiVeterinaraPrijava(string username, string password)
        {
           
            using (ITransaction transaction = _session.BeginTransaction())
            {
                Veterinar entity = _session.Query<Veterinar>().Where(x => x.KorisnickoIme.Equals(username) && x.Lozinka.Equals(password)).SingleOrDefault();
                return entity;
            }
            
        }
        public List<VrstaZivotinje> DohvatiSveVrsteVeterinar(int id)
        {
            
            using (ITransaction transaction = _session.BeginTransaction())
            {
                    
                var entity = _session.Query<VrstaZivotinje>().Where(x => x.Veterinar.Id == id && x.Aktivno).ToList();
                return entity;
            }
            
        }
        public VrstaZivotinje DohvatiVrstuZivotinjeKodVeterinara(int idZivotinja, int idVeterinar)
        {
            
            using (ITransaction transaction = _session.BeginTransaction())
            {
                var ziv = _session.Query<Zivotinja>().Where(zivotinja => zivotinja.Id == idZivotinja).FetchMany(Zivotinja => Zivotinja.VrstaZivotinjes).ThenFetch(v => v.Veterinar).SingleOrDefault();
                var vrsta = ziv.VrstaZivotinjes.Where(v => v.Veterinar.Id == idVeterinar).SingleOrDefault();
                return vrsta;
            }
            
        }
        public List<VrstaPostupka> DohvatiSvePostupke(int id)
        {
            
            using (ITransaction transaction = _session.BeginTransaction())
            {
                var query = _session.Query<VrstaPostupka>().Where(vrsta => vrsta.Veterinar.Id == id && vrsta.Aktivno == true).ToList();
                return query;
            }
            
        }
        public List<LijekKodVeterinara> DohvatiSveLijekoveKodVeterinara(int id)
        {
            
            using (ITransaction transaction = _session.BeginTransaction())
            {
                var query = _session.Query<LijekKodVeterinara>().Where(x => x.Veterinar.Id == id && x.Aktivno == true)
                    .Fetch(x => x.Lijek)
                    .ToList();
                return query;
            }
            
        }

    }
}
