using DatabaseBootstrap;
using DatabaseBootstrap.IRepositories;
using DatabaseBootstrap.Repositories;
using DesktopForms.ViewInterfaces;
using DesktopForms.Views;
using DesktopFOrms.Views;
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
        private readonly IVeterinarRepository _repository;
        public PrijavaPresenter(IPrijavaView view, IVeterinarRepository repository)
        {
            _view = view;
            view.Presenter = this;
            view.PogrešnaPrijava = false;
            _repository = repository;
        }
        public void PokusajPrijave()
        {
            var prijava = _repository.DohvatiVeterinaraPrijava(_view.KorisnickoIme, _view.Lozinka);
            if(prijava == null)
            {
                _view.PogrešnaPrijava = true;
                _view.Lozinka = "";
                return;
            }
            NHibernateService.PrijavljeniVeterinar = prijava;
            _view.CloseForm();

            RacunForm form = new RacunForm();
            RacunPresenter presenter = new RacunPresenter(form, new RacunRepository(), new VeterinarRepository(), new PostupakRepository());

            form.Show();

        }
    }
}
