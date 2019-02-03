using DatabaseBootstrap.IRepositories;
using DatabaseBootstrap.Repositories;
using DesktopForms.ViewInterfaces;
using DesktopForms.Views;
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
        private readonly IUnitOfWork _unit;
        private readonly PostupakPresenter _postupakPresenter;

        public LijekoviPresenter(ILijekoviView view, IUnitOfWork unit, PostupakPresenter postupakPresenter = null)
        {
            _view = view;
            view.Presenter = this;
            _unit = unit;
            _postupakPresenter = postupakPresenter;
            _view.Terapija = postupakPresenter == null ? false : true;
            UpdateLijekoviListView();
        }

       

        private void UpdateLijekoviListView()
        {
            var lijekovi = _unit.LijekoviRepository.DohvatiSve();
            _view.Lijekovi = lijekovi;
        }
        public void DodanaTerapija(List<Lijek> lijekovi)
        {
            _postupakPresenter.DodanaTerapija(lijekovi);
        }

        public void CloseUnitOfWork()
        {
            this._unit.Dispose();
        }
    }
}
