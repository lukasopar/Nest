using DesktopForms.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForms.ViewInterfaces
{
    public interface IPrijavaView
    {
        string KorisnickoIme { get; set; }
        string Lozinka { get;  set; }
        PrijavaPresenter Presenter { set; }
        bool PogrešnaPrijava { get; set; }
        void CloseForm();
    }
}
