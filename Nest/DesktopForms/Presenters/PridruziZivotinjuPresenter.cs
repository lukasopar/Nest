using DatabaseBootstrap;
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
    public class PridruziZivotinjuPresenter
    {
        private readonly IPridruziZivotinjuView _view;
        private readonly IVlasnikRepository _repositoryVlasnik;
        private readonly IVeterinarRepository _repositoryVeterinar;
        private readonly IZivotinjaRepository _repositoryZiv;
        private readonly PostupakPresenter _presenter;
        public PridruziZivotinjuPresenter(IPridruziZivotinjuView view, IVlasnikRepository repositoryVlasnik, IVeterinarRepository repositoryVeterinar, IZivotinjaRepository repositoryZiv, PostupakPresenter presenter)
        {
            _view = view;
            view.Presenter = this;
            _repositoryVeterinar = repositoryVeterinar;
            _repositoryVlasnik = repositoryVlasnik;
            _repositoryZiv = repositoryZiv;
            _presenter = presenter;

            UpdateVlasnikListView();
        }

        public void UpdateVlasnikListView(string query = "")
        {
            var bolesti = _repositoryVlasnik.DohvatiSve();
            _view.Vlasnici = bolesti.Where(x => (x.Ime + " "+ x.Prezime).Contains(query)).ToList();
            _view.VrsteZivotinja = _repositoryVeterinar.DohvatiSveVrsteVeterinar(NHibernateService.PrijavljeniVeterinar.Id);
        }

        public void UpdateZivotinjaListView(Vlasnik vlasnik)
        {
            vlasnik.Zivotinjas = _repositoryVlasnik.DohvatiVlasnikaSaZivotinjom(vlasnik.Id);
        }

        public VrstaZivotinje OdabranaZivotinja(Zivotinja zivotinja)
        {
            var vrsta = _repositoryVeterinar.DohvatiVrstuZivotinjeKodVeterinara(zivotinja.Id, NHibernateService.PrijavljeniVeterinar.Id);
            return vrsta;
        }

        public void Spremi(Zivotinja zivotinja, VrstaZivotinje vrsta)
        {
            if(vrsta !=null)
            {
                //zivotinja.PridruziVrstuZivotinjeKodVeterinara(vrsta);
                //_repositoryZiv.Azuriraj(zivotinja);
                _repositoryZiv.AzurirajSNovomVrstom(zivotinja, vrsta);
                
            }
            _presenter.OdabranaZivotinja(zivotinja);
        }
    }
}
