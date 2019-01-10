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

            _view.LijekoviIme = new List<string>();
            _view.LijekoviOpis = new List<string>();

        }
    }
}
