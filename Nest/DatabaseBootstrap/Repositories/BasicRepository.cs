using Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseBootstrap.Repositories
{
    public class BasicRepository<T> : IBasicRepository<T> where T : EntityClass
    {
        public List<T> DohvatiSve()
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IQueryable<T> query = session.Query<T>().AsQueryable();
                    return query.ToList();
                }
            }
        }

        public void Azuriraj(T entity)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    session.Transaction.Commit();
                }
            }
        }

        public T DohvatiPrekoID(Guid id)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    T entity = session.Get<T>(id);
                    return entity;
                }
            }
        }

        public void Izbrisi(Guid id)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var queryString = string.Format("delete {0} where id = :id", typeof(T));
                    session.CreateQuery(queryString)
                           .SetParameter("id", id)
                           .ExecuteUpdate();

                    transaction.Commit();
                }
            }
        }

        public void Stvori(T entity)
        {
            using (ISession session = NHibernateService.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(entity);
                    transaction.Commit();
                }
            }
        }

        
    }
}
