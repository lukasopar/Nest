using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForms.ViewInterfaces
{
    public interface IDetaljiOLijekuView
    {
        Lijek Lijek { get; set; }
        IList<Bolest> Bolesti { get; set; }
        IList<InterakcijaLijekova> Interakcije { get; set; }
        Presenters.DetaljiOLijekuPresenter Presenter { set; }
    }
}
