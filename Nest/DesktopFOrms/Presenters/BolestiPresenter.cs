using DatabaseBootstrap.IRepositories;
using DesktopFOrms.ViewInterfaces;
using DesktopFOrms.Views;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopFOrms.Presenters
{
    public class BolestiPresenter
    {
        private readonly IBolestiView _view;
        private readonly IBolestiRepository _repository;


        public BolestiPresenter(IBolestiView view, IBolestiRepository repository)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;

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
        
    }
}
