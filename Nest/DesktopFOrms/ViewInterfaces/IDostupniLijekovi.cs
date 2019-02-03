using DatabaseBootstrap.Observer;
using DesktopForms.Presenters;
using Nest.Model.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForms.ViewInterfaces
{
    public interface IDostupniLijekovi : IObserver<Lijek>, IObserver<LijekKodVeterinara>
    {
        IList<LijekKodVeterinara> LijekoviKodVeterinara { set; }
        IList<Lijek> Lijekovi { set; }
        DostupniLijekoviPresenter Presenter { set; }
    }
}
