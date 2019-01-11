using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopFOrms.ViewInterfaces
{
    public interface ILijekoviView
    {
        IList<Tuple<string, string>> Lijekovi { get; set; }
        IList<string> LijekoviIme { get; set; }
        IList<string> LijekoviOpis { get; set; }
        Presenters.LijekoviPresenter Presenter {  set; }
    }
}
