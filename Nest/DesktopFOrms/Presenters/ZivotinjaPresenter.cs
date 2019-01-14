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
        private readonly IZivotinjaRepository _zivotinjaRepository;
        private readonly IVlasnikRepository _vlasniciRepository;

        public ZivotinjaPresenter(IZivotinjaView view, IZivotinjaRepository repository, IVlasnikRepository vlasnici_repository)
        {
            _view = view;
            view.Presenter = this;
            _zivotinjaRepository = repository;
            _vlasniciRepository = vlasnici_repository;
            _view.Vlasnici = vlasnici_repository.DohvatiSve();
        }

        public void RegistrirajZivotinju(Zivotinja zivotinja)
        {
            _zivotinjaRepository.Stvori(zivotinja);
        }

        public void UpdateVlasnikList(String nameLike)
        {
            _view.Vlasnici = _vlasniciRepository.DohvatiSve().Where(vlasnik => vlasnik.KorisnickoIme.Contains(nameLike)).ToList();
        }
    }
}
