
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseBootstrap.Repositories
{
    public interface IBasicRepository<T> where T : EntityClass
    {
        IQueryable<T> DohvatiSve();
        T DohvatiPrekoID(Guid id);
        void Stvori(T entity);
        void Azuriraj(T entity);
        void Izbrisi(Guid id);
    }
}
