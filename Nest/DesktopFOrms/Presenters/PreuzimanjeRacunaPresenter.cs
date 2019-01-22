using DatabaseBootstrap;
using DatabaseBootstrap.IRepositories;
using DesktopForms.ViewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForms.Presenters
{
    public class PreuzimanjeRacunaPresenter
    {
        IPreuzimanjeRacunaView _view;
        IRacunRepository _repository;
        
        public PreuzimanjeRacunaPresenter(IPreuzimanjeRacunaView view, IRacunRepository repository)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;
            
            NapuniView();
        }
        public void NapuniView()
        {
            var lista = _repository.DohvatiSveRacune(NHibernateService.PrijavljeniVeterinar.Id);
            _view.Racuni = lista;
        }
    }
}
