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
    public class ZivotinjaPresenter
    {
        private readonly IZivotinjaView _view;
        private readonly IVrstaRepository _vrstaRepository;
        private readonly IZivotinjaRepository _zivotinjaRepository;
        private readonly IVlasnikRepository _vlasniciRepository;

        public ZivotinjaPresenter(IZivotinjaView view, IZivotinjaRepository repository, IVrstaRepository vrstaRepository, 
            IVlasnikRepository vlasnici_repository)
        {
            _view = view;
            view.Presenter = this;
            _zivotinjaRepository = repository;
            _vlasniciRepository = vlasnici_repository;
            _vrstaRepository = vrstaRepository;
            _view.VrsteZivotinja = vrstaRepository.DohvatiVrsteVeterinara(NHibernateService.PrijavljeniVeterinar.Id);
            _view.Vlasnici = vlasnici_repository.DohvatiSveVlasnike();
        }

        public void RegistrirajZivotinju(Zivotinja zivotinja)
        {
            _zivotinjaRepository.Stvori(zivotinja);
        }

        public void UpdateVlasnik(Vlasnik vlasnik)
        {
            _vlasniciRepository.Azuriraj(vlasnik);
        }

        public void UpdateVlasnikList(String nameLike)
        {
            _view.Vlasnici = _vlasniciRepository.DohvatiSveVlasnike().Where(vlasnik => vlasnik.KorisnickoIme.Contains(nameLike)).ToList();
        }
    }
}
