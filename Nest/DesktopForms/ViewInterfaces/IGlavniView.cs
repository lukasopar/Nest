using DesktopFOrms.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopFOrms.ViewInterfaces
{
    public interface IGlavniView
    {
        GlavniPresenter Presenter { set; }
    }
}
