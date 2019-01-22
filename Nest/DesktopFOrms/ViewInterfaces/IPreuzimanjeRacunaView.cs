using DesktopForms.Presenters;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForms.ViewInterfaces
{
    public interface IPreuzimanjeRacunaView
    {
        List<Racun> Racuni { get; set; }
        PreuzimanjeRacunaPresenter Presenter { set; }
    }
}
