using DatabaseBootstrap.Observer;
using Model;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseBootstrap.Repositories
{
    public class BasicRepository<T> : IBasicRepository<T> where T : EntityClass
    {
        protected readonly ISession _session;

        private List<IObserver<T>> observers = new List<IObserver<T>>();
        public BasicRepository(ISession session)
        {
            _session = session;
        }
        public List<T> DohvatiSve()
        {
            
            using (ITransaction transaction = _session.BeginTransaction())
            {
                IQueryable<T> query = _session.Query<T>().AsQueryable();
                transaction.Commit();

                return query.ToList();
            }
            
        }

        public void Azuriraj(T entity)
        {
            
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    _session.Update(entity);
                    _session.Transaction.Commit();
                    Notify(entity, false);
                }
            
        }

        public T DohvatiPrekoID(int id)
        {
           
                using (ITransaction transaction = _session.BeginTransaction())
                {
                    T entity = _session.Get<T>(id);
                    transaction.Commit();
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
                    _session.SaveOrUpdate(entity);
                    transaction.Commit();
                    Notify(entity, true);
                }
            
        }

        public void Attach(IObserver<T> observer)
        {
            observers.Add(observer);
        }

        public void Detach(IObserver<T> observer)
        {
            observers.Remove(observer);
        }

        public void Notify(T entity, bool state)
        {
            foreach (IObserver<T> observer in observers)
            {
                observer.Update(entity, state);
            }
        }
    }
}
