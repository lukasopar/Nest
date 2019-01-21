using DesktopForms.Presenters;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopFOrms.ViewInterfaces
{
    public interface IPovijestPregledaView
    {
        List<Postupak> Postupci { get; set; }
        PostupakPresenter Presenter { set; }
    }
}
