
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForms.ViewInterfaces
{
    public interface IBolestiDetaljiView
    {
        Bolest Bolest { get; set; }
        Presenters.BolestiPresenter Presenter { set; }
    }
}
