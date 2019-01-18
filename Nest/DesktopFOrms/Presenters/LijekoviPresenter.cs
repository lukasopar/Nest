using DatabaseBootstrap.IRepositories;
using DesktopForms.ViewInterfaces;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForms.Presenters
{
    public class LijekoviPresenter
    {
        private readonly ILijekoviView _view;
        private readonly ILijekoviRepository _repository;
        private readonly PostupakPresenter _postupakPresenter;


        public LijekoviPresenter(ILijekoviView view, ILijekoviRepository repository, PostupakPresenter postupakPresenter = null)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;
            _postupakPresenter = postupakPresenter;
            _view.Terapija = postupakPresenter == null ? false : true;
            UpdateLijekoviListView();
        }

        private void UpdateLijekoviListView()
        {
            var lijekovi = _repository.DohvatiSve();
            _view.Lijekovi = lijekovi;
        }
        public void DodanaTerapija(List<Lijek> lijekovi)
        {
            _postupakPresenter.DodanaTerapija(lijekovi);
        }
    }
}
