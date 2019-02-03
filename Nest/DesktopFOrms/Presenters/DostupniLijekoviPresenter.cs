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
    public class DostupniLijekoviPresenter
    {
        private readonly ILijekKodVeterinaraRepository _veterinarLijekRepository;
        private readonly ILijekoviRepository _lijekRepository;
        private readonly IDostupniLijekovi _view;

        public DostupniLijekoviPresenter(IDostupniLijekovi view, ILijekKodVeterinaraRepository veterinarLijekRepository, ILijekoviRepository lijekRepository)
        {
            _view = view;
            _view.Presenter = this;
            _lijekRepository = lijekRepository;
            _veterinarLijekRepository = veterinarLijekRepository;
            UpdateLijekovi();
        }

        private void UpdateLijekovi()
        {
            List<Lijek> lijekovi = _lijekRepository.DohvatiSve().ToList();
            List<LijekKodVeterinara> lijekoviVeterinara = _veterinarLijekRepository.DohvatiLijekoveVeterinara(NHibernateService.PrijavljeniVeterinar.Id);
            _view.Lijekovi = lijekovi;
            _view.LijekoviKodVeterinara = lijekoviVeterinara;
        }
        

        internal void DodajLijekVeterinaru(Lijek lijek, double number, string text)
        {
            LijekKodVeterinara lijekKodVeterinara = new LijekKodVeterinara();
            lijekKodVeterinara.Lijek = lijek;
            lijekKodVeterinara.Napomena = text;
            lijekKodVeterinara.Cijena = number;
            lijekKodVeterinara.Aktivno = true;
            lijekKodVeterinara.Veterinar = NHibernateService.PrijavljeniVeterinar;
            _veterinarLijekRepository.Stvori(lijekKodVeterinara);
            AzurirajLijekoveVeterinara();
        }

        private void AzurirajLijekoveVeterinara()
        {
            List<LijekKodVeterinara> lijekoviVeterinara = _veterinarLijekRepository.DohvatiLijekoveVeterinara(NHibernateService.PrijavljeniVeterinar.Id);
            _view.LijekoviKodVeterinara = lijekoviVeterinara;
        }
    }
}
