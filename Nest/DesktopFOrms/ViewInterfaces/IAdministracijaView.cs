using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForms.ViewInterfaces
{
    public interface IAdministracijaView
    {
        IList<VrstaZivotinje> Vrste { set; }
        IList<VrstaPostupka> Postupci { set; }
        Presenters.AdministracijaPresenter Presenter { set; }
    }
}
