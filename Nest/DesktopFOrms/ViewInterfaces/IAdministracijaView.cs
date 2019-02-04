using DatabaseBootstrap.Observer;
using Nest.Model.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForms.ViewInterfaces
{
    public interface IAdministracijaView : IObserver<VrstaZivotinje>, IObserver<VrstaPostupka>
    {
        IList<VrstaZivotinje> Vrste { set; }
        IList<VrstaPostupka> Postupci { set; }
        Presenters.AdministracijaPresenter Presenter { set; }
    }
}
