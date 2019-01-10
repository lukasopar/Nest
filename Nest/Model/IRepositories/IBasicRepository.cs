
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model.Repositories
{
    public interface IBasicRepository<T>
    {
        IQueryable<T> DohvatiSve();
        T DohvatiPrekoID(Guid id);
        void Stvori(T entity);
        void Azuriraj(T entity);
        void Izbrisi(Guid id);
    }
}
