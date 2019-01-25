using DatabaseBootstrap;
using DatabaseBootstrap.IRepositories;
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
        private readonly IVrstaRepository _vrstaRepository;
        private readonly IVrstaPostupkaRepository _postupakRepository;
        private readonly IAdministracijaView _view;

        public AdministracijaPresenter(IAdministracijaView view, IVrstaPostupkaRepository postupakRepository, IVrstaRepository vrstaRepository)
        {
            _view = view;
            _view.Presenter = this;
            _vrstaRepository = vrstaRepository;
            _postupakRepository = postupakRepository;
            UpdatePostupke();
            UpdateVrste();
        }

        private void UpdateVrste()
        {
            int idVeterinara = NHibernateService.PrijavljeniVeterinar.Id;
            _view.Vrste = _vrstaRepository.DohvatiVrsteVeterinara(idVeterinara);
        }

        private void UpdatePostupke()
        {
            int idVeterinara = NHibernateService.PrijavljeniVeterinar.Id;
            _view.Postupci = _postupakRepository.DohvatiPostupkeVeterinara(idVeterinara);
        }

        internal void DodajVrstu(string text)
        {
            VrstaZivotinje vrsta = new VrstaZivotinje();
            vrsta.Aktivno = true;
            vrsta.Veterinar = NHibernateService.PrijavljeniVeterinar;
            vrsta.Vrsta = text;
            vrsta.Zivotinjas = new List<Zivotinja>();
            _vrstaRepository.Stvori(vrsta);
            UpdateVrste();
        }

        internal void IzbrisiVrstuZivotinje(VrstaZivotinje vrsta)
        {
            vrsta.Aktivno = false;
            _vrstaRepository.Azuriraj(vrsta);
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
            _postupakRepository.Stvori(vrsta);
            UpdatePostupke();
        }

        internal void IzbrisiVrstuPostupka(VrstaPostupka vrsta)
        {
            vrsta.Aktivno = false;
            _postupakRepository.Azuriraj(vrsta);
            UpdatePostupke();
        }
    }
}
