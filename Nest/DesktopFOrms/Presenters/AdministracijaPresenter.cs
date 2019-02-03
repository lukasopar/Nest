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
    public class AdministracijaPresenter
    {
        private readonly UnitOfWork _unit;
        private readonly IAdministracijaView _view;

        public AdministracijaPresenter(IAdministracijaView view, UnitOfWork unit)
        {
            _view = view;
            _view.Presenter = this;
            _unit = unit;
            UpdatePostupke();
            UpdateVrste();
        }

        private void UpdateVrste()
        {
            int idVeterinara = NHibernateService.PrijavljeniVeterinar.Id;
            _view.Vrste = _unit.VrstaRepository.DohvatiVrsteVeterinara(idVeterinara);
        }

        private void UpdatePostupke()
        {
            int idVeterinara = NHibernateService.PrijavljeniVeterinar.Id;
            _view.Postupci = _unit.VrstaPostupkaRepository.DohvatiPostupkeVeterinara(idVeterinara);
        }

        internal void DodajVrstu(string text)
        {
            VrstaZivotinje vrsta = new VrstaZivotinje();
            vrsta.Aktivno = true;
            vrsta.Veterinar = NHibernateService.PrijavljeniVeterinar;
            vrsta.Vrsta = text;
            vrsta.Zivotinjas = new List<Zivotinja>();
            _unit.VrstaRepository.Stvori(vrsta);
            UpdateVrste();
        }

        internal void IzbrisiVrstuZivotinje(VrstaZivotinje vrsta)
        {
            vrsta.Aktivno = false;
            _unit.VrstaRepository.Azuriraj(vrsta);
            UpdateVrste();
        }

        internal void DodajVrstuPostupka(string naziv, string opis, double cijena)
        {
            VrstaPostupka vrsta = new VrstaPostupka();
            vrsta.Naziv = naziv;
            vrsta.Opis = opis;
            vrsta.Cijena = cijena;
            vrsta.Aktivno = true;
            vrsta.Veterinar = NHibernateService.PrijavljeniVeterinar;
            vrsta.Postupaks = new List<Postupak>();
            _unit.VrstaPostupkaRepository.Stvori(vrsta);
            UpdatePostupke();
        }

        internal void IzbrisiVrstuPostupka(VrstaPostupka vrsta)
        {
            vrsta.Aktivno = false;
            _unit.VrstaPostupkaRepository.Azuriraj(vrsta);
            UpdatePostupke();
        }

        public void CloseUnitOfWork()
        {
            this._unit.Dispose();
        }
    }
}
