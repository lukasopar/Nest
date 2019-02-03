
using DatabaseBootstrap.Observer;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseBootstrap.Repositories
{
    public interface IBasicRepository<T> : Subject<T> where T : EntityClass 
    {
        List<T> DohvatiSve();
        T DohvatiPrekoID(int id);
        void Stvori(T entity);
        void Azuriraj(T entity);
        void Izbrisi(int id);
    }
}
