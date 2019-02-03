using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBootstrap.Observer
{
    public interface IObserver<T>
    {
        void Update(T entity, bool state);
    }
}
