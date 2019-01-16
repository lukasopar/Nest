using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForms.ViewInterfaces
{
    public interface IBolestiView
    {
        IList<Bolest> Bolesti { get; set; }
        Presenters.BolestiPresenter Presenter {  set; }
        bool Dijagnoza { get; set; }
    }
}
