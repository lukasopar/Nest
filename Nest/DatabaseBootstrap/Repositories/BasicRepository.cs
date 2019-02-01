using Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseBootstrap.Repositories
{
    public class BasicRepository<T> : IBasicRepository<T> where T : EntityClass
    {
        protected readonly ISession _session;
        public BasicRepository(ISession session)
        {
            _session = session;
        }
        public List<T> DohvatiSve()
        {
            
            using (ITransaction transaction = _session.BeginTransaction())
            {
                IQueryable<T> query = _session.Query<T>().AsQueryable();
                return query.ToList();
            }
            
        }

        public void Azuriraj(T entity)
        {
            
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(entity);
                    _session.Transaction.Commit();
                }
            
        }

        public T DohvatiPrekoID(int id)
        {
           
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    T entity = _session.Get<T>(id);
                    return entity;
                }
            
        }

        public void Izbrisi(int id)
        {
            
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    var queryString = string.Format("delete {0} where id = :id", typeof(T));
                    _session.CreateQuery(queryString)
                           .SetParameter("id", id)
                           .ExecuteUpdate();

                    transaction.Commit();
                }
           
        }

        public void Stvori(T entity)
        {
            
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Save(entity);
                    transaction.Commit();
                }
            
        }

        
    }
}
