using DesktopForms.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForms.ViewInterfaces
{
    public interface IGlavniView
    {
        GlavniPresenter Presenter { set; }
    }
}
