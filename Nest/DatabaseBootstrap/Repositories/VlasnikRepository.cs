﻿using DatabaseBootstrap;
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
    public class VlasnikRepository : BasicRepository<Vlasnik>, IVlasnikRepository
    {
        public VlasnikRepository(ISession session) : base(session)
        {
        }
        public List<Vlasnik> DohvatiSveVlasnike()
        {
       
            using (ITransaction transaction = _session.BeginTransaction())
            {
                IQueryable<Vlasnik> query = _session.Query<Vlasnik>().Fetch(vlasnik => vlasnik.Zivotinjas).AsQueryable();
                return query.ToList();
            }
        
        }

        public List<Zivotinja> DohvatiVlasnikaSaZivotinjom(int id)
        {
           
            using (ITransaction transaction = _session.BeginTransaction())
            {
                var query = _session.Query<Vlasnik>().Where(vlasnik => vlasnik.Id == id).FetchMany(vlasnik => vlasnik.Zivotinjas).SingleOrDefault();
                return query.Zivotinjas.ToList();
            }
            
            
        }
        public Vlasnik DohvatiVlasnikaPrijava(string username, string password)
        {
            
            using (ITransaction transaction = _session.BeginTransaction())
            {
                Vlasnik entity = _session.Query<Vlasnik>().Where(x => x.KorisnickoIme.Equals(username) && x.Lozinka.Equals(password)).SingleOrDefault();
                return entity;
            }
            
        }
        public Vlasnik DohvatiVlasnikaKorisnickoIme(string username)
        {
            
            using (ITransaction transaction = _session.BeginTransaction())
            {
                Vlasnik entity = _session.Query<Vlasnik>().Where(x => x.KorisnickoIme.Equals(username)).SingleOrDefault();
                return entity;
            }
            
        }
        public List<Zivotinja> DohvatiVlasnikoveZivotinje(int id)
        {
            return null;
        }
    }
}
