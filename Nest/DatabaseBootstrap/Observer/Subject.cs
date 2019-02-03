using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseBootstrap.Observer
{
    public interface Subject<T>
    {
        void Attach(IObserver<T> observer);
        void Detach(IObserver<T> observer);
        void Notify(T entity, bool state);
    }
}
