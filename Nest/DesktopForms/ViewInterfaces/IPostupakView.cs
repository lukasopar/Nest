using DesktopForms.Presenters;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopFOrms.ViewInterfaces
{
    public interface IPostupakView
    {
        Zivotinja Zivotinja { get; set; }
        List<VrstaPostupka> VrstePostupaka {get; set;}
        List<Bolest> Bolesti { get; set; }
        List<Lijek> Lijekovi { get; set; }

        PostupakPresenter Presenter { set; }
    }
}
