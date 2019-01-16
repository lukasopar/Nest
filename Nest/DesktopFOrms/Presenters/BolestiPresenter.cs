using DatabaseBootstrap.IRepositories;
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
        private readonly IBolestiRepository _repository;
        private readonly PostupakPresenter _presenterDijagnoza;

        public BolestiPresenter(IBolestiView view, IBolestiRepository repository, PostupakPresenter postupakPresenter)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;
            _presenterDijagnoza = postupakPresenter;
            _view.Dijagnoza = postupakPresenter == null ? false : true;
            UpdateBolestiListView();
        }

        public void UpdateBolestiListView(string query = "")
        {
            var bolesti = _repository.DohvatiSve();
            _view.Bolesti = bolesti.Where(x => x.Naziv.Contains(query)).ToList();
        }
        public void DetaljiBolest(Bolest bolest)
        {
            BolestDetaljiForm detalji = new BolestDetaljiForm();
            detalji.Presenter = this;
            var dohvaceno = _repository.DohvatiPrekoIDSLijekovima(bolest.Id);
            detalji.Bolest = dohvaceno;
            //detalji.Bolest = bolest;
            detalji.ShowDialog();
        }
        public void DodanaDijagnoza(List<Bolest> bolesti)
        {
            _presenterDijagnoza.DodanaDijagnoza(bolesti);
        }
    }
}
