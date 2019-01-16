using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForms.ViewInterfaces
{
    public interface IZivotinjaView
    {
        IList<Vlasnik> Vlasnici { get; set; }
        Presenters.ZivotinjaPresenter Presenter { set; }
    }
}
