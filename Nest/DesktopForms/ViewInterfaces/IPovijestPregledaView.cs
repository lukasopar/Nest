using DesktopForms.Presenters;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForms.ViewInterfaces
{
    public interface IPovijestPregledaView
    {
        List<Postupak> Postupci { get; set; }
        RacunPresenter Presenter { set; }
        bool Dodavanje { get; set; }
        IzvjestajiPresenter PresenterIzvjestaji { set; }
        bool Izvjestaj { get; set; }
    }
}
