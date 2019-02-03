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
    public class BolestiPresenter
    {
        private readonly IBolestiView _view;
        private readonly IUnitOfWork _unit;
        private readonly PostupakPresenter _presenterDijagnoza;
        

        public BolestiPresenter(IBolestiView view, IUnitOfWork unitOfWork, PostupakPresenter postupakPresenter)
        {
            _view = view;
            view.Presenter = this;
            _unit = unitOfWork;
            _presenterDijagnoza = postupakPresenter;
            _view.Dijagnoza = postupakPresenter == null ? false : true;
            UpdateBolestiListView();
        }

        public void UpdateBolestiListView(string query = "")
        {
            var bolesti = _unit.BolestiRepository.DohvatiSve();
            _view.Bolesti = bolesti.Where(x => x.Naziv.ToLower().Contains(query.ToLower())).ToList();
        }
        public void DetaljiBolest(Bolest bolest)
        {
            BolestDetaljiForm detalji = new BolestDetaljiForm();
            detalji.Presenter = this;
            var dohvaceno = _unit.BolestiRepository.DohvatiPrekoIDSLijekovima(bolest.Id);
            detalji.Bolest = dohvaceno;
            //detalji.Bolest = bolest;
            detalji.Show();
        }
        public void DodanaDijagnoza(List<Bolest> bolesti)
        {
            _presenterDijagnoza.DodanaDijagnoza(bolesti);
        }

        public void CloseUnitOfWork()
        {
            this._unit.Dispose();
        }
    }
}
