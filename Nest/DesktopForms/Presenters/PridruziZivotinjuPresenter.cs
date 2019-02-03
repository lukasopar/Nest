using DatabaseBootstrap;
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
    public class PridruziZivotinjuPresenter
    {
        private readonly IPridruziZivotinjuView _view;
        private readonly IUnitOfWork _unit;
        private readonly PostupakPresenter _presenter;
        public PridruziZivotinjuPresenter(IPridruziZivotinjuView view, IUnitOfWork unit, PostupakPresenter presenter)
        {
            _view = view;
            view.Presenter = this;
            _unit = unit;
            _presenter = presenter;

            UpdateVlasnikListView();
        }

        public void UpdateVlasnikListView(string query = "")
        {
            var bolesti = _unit.VlasnikRepository.DohvatiSve();
            _view.Vlasnici = bolesti.Where(x => (x.Ime + " "+ x.Prezime).Contains(query)).ToList();
            _view.VrsteZivotinja = _unit.VeterinarRepository.DohvatiSveVrsteVeterinar(NHibernateService.PrijavljeniVeterinar.Id);
        }

        public void UpdateZivotinjaListView(Vlasnik vlasnik)
        {
            vlasnik.Zivotinjas = _unit.VlasnikRepository.DohvatiVlasnikaSaZivotinjom(vlasnik.Id);
        }

        public VrstaZivotinje OdabranaZivotinja(Zivotinja zivotinja)
        {
            var vrsta = _unit.VeterinarRepository.DohvatiVrstuZivotinjeKodVeterinara(zivotinja.Id, NHibernateService.PrijavljeniVeterinar.Id);
            return vrsta;
        }

        public void Spremi(Zivotinja zivotinja, VrstaZivotinje vrsta)
        {
            if(vrsta !=null)
            {
                //zivotinja.PridruziVrstuZivotinjeKodVeterinara(vrsta);
                //_repositoryZiv.Azuriraj(zivotinja);
                _unit.ZivotinjaRepository.AzurirajSNovomVrstom(zivotinja, vrsta);
                
            }
            _presenter.OdabranaZivotinja(zivotinja);
        }

        public void CloseUnitOfWork()
        {
            this._unit.Dispose();
        }
    }
}
