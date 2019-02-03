using DatabaseBootstrap;
using DatabaseBootstrap.IRepositories;
using DatabaseBootstrap.Repositories;
using DesktopForms.ViewInterfaces;
using Model;
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
        private readonly IUnitOfWork _unit;
        private readonly IAdministracijaView _view;

        public AdministracijaPresenter(IAdministracijaView view, IUnitOfWork unit)
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
            VrstaZivotinje vrsta = ModelFactory.CreateVrstaZivotinje(NHibernateService.PrijavljeniVeterinar, text, true);
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
            VrstaPostupka vrsta = ModelFactory.CreateVrstaPostupka(NHibernateService.PrijavljeniVeterinar, naziv, opis, cijena, true);
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
