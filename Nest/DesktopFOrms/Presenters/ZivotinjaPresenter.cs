using DatabaseBootstrap;
using DatabaseBootstrap.IRepositories;
using DatabaseBootstrap.Repositories;
using DesktopForms.ViewInterfaces;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopForms.Presenters
{
    public class ZivotinjaPresenter
    {
        private readonly IZivotinjaView _view;
        private readonly UnitOfWork _unit;

        public ZivotinjaPresenter(IZivotinjaView view, UnitOfWork unit)
        {
            _view = view;
            view.Presenter = this;
            _unit = unit;
            InitListe();
        }

        public void RegistrirajZivotinju(Zivotinja zivotinja)
        {
            _unit.ZivotinjaRepository.Stvori(zivotinja);
        }

        public void UpdateVlasnik(Vlasnik vlasnik, Zivotinja zivotinja)
        {
            vlasnik.DodajZivotinju(zivotinja);
            _unit.VlasnikRepository.Azuriraj(vlasnik);
        }

        public void PridruziVrstuZivotinjeKodVeterinara(Zivotinja zivotinja, VrstaZivotinje vrsta)
        {
            zivotinja.PridruziVrstuZivotinjeKodVeterinara(vrsta);
        }

        public void InitListe()
        {
            _view.VrsteZivotinja = _unit.VrstaRepository.DohvatiVrsteVeterinara(NHibernateService.PrijavljeniVeterinar.Id);
            _view.Vlasnici = _unit.VlasnikRepository.DohvatiSveVlasnike();
        }

        public void UpdateVlasnikList(String nameLike)
        {
            _view.Vlasnici = _unit.VlasnikRepository.DohvatiSveVlasnike().Where(vlasnik => vlasnik.KorisnickoIme.Contains(nameLike)).ToList();
        }

        public void CloseUnitOfWork()
        {
            this._unit.Dispose();
        }
    }
}
