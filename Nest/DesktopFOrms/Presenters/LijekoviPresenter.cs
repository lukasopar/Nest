using DesktopFOrms.ViewInterfaces;
using Model.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopFOrms.Presenters
{
    public class LijekoviPresenter
    {
        private readonly ILijekoviView _view;
        private readonly ILijekoviRepository _repository;


        public LijekoviPresenter(ILijekoviView view, ILijekoviRepository repository)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;

            UpdateLijekoviListView();
        }

        private void UpdateLijekoviListView()
        {
            //var lijekovi = _repository.DohvatiSve().ToList();
            var tup1 = new Tuple<string, string>("Lijek1", "slab");
            var tup2 = new Tuple<string, string>("Lijek2", "jaci");
            var l = new List<Tuple<string,string>>();
            l.Add(tup1);
            l.Add(tup2);
            _view.Lijekovi = l;
            _view.LijekoviIme = new List<string>();
            _view.LijekoviOpis = new List<string>();

        }
    }
}
