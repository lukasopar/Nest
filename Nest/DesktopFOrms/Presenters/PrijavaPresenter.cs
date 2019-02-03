using DatabaseBootstrap;
using DatabaseBootstrap.IRepositories;
using DatabaseBootstrap.Repositories;
using DesktopForms.ViewInterfaces;
using DesktopForms.Views;
using DesktopForms.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForms.Presenters
{
   
    public class PrijavaPresenter
    {
        private readonly IPrijavaView _view;
        private readonly UnitOfWork _unit;
        public PrijavaPresenter(IPrijavaView view,UnitOfWork unit)
        {
            _view = view;
            view.Presenter = this;
            view.PogrešnaPrijava = false;
            _unit = unit;
        }
        public void PokusajPrijave()
        {
            var prijava = _unit.VeterinarRepository.DohvatiVeterinaraPrijava(_view.KorisnickoIme, _view.Lozinka);
            if(prijava == null)
            {
                _view.PogrešnaPrijava = true;
                _view.Lozinka = "";
                return;
            }
            NHibernateService.PrijavljeniVeterinar = prijava;
            _view.CloseForm();
            _unit.Dispose();

            GlavniForm form = new GlavniForm();
            GlavniPresenter presenter = new GlavniPresenter(form);
            form.Show();

        }

        public void CloseUnitOfWork()
        {
            this._unit.Dispose();
        }
    }
}
