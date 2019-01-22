using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseBootstrap;
using DatabaseBootstrap.IRepositories;
using DatabaseBootstrap.Repositories;
using DesktopForms.Views;
using DesktopForms.ViewInterfaces;
using DesktopForms.Views;
using Nest.Model.Domain;

namespace DesktopForms.Presenters
{
    public class RacunPresenter
    {
        IRacunView _view;
        IRacunRepository _repository;
        IPostupakRepository _repositoryPostupak;
        IVeterinarRepository _repositoryVeterinar;
        //ILijekoviRepository _repositoryLijekovi;
        public RacunPresenter(IRacunView view, IRacunRepository repository, IVeterinarRepository veterinarRepository, IPostupakRepository repositoryPostupak,ILijekoviRepository lijekoviRepository = null)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;
            _repositoryVeterinar = veterinarRepository;
            _repositoryPostupak = repositoryPostupak;
            //_repositoryLijekovi = lijekoviRepository;
            NapuniView();
        }

        private void NapuniView()
        {      
            _view.Postupci = new List<Postupak>();
            _view.Lijekovi = new List<LijekStavkaRacuna>();
        }
        public void DodajPostupak()
        {
            PovijestPregledaForm form = new PovijestPregledaForm();
            form.Postupci = _repositoryPostupak.DohvatiSDetaljimaPostupakeNeplacene(NHibernateService.PrijavljeniVeterinar.Id);
            form.Presenter = this;
            form.Dodavanje = true;
            form.Show();
        }
        
         public void DodaniPostupci(List<Postupak> postupci)
         {
             var stariPostupci = _view.Postupci;
            stariPostupci.AddRange(postupci);
            stariPostupci = stariPostupci.Distinct().ToList();
             _view.Postupci = stariPostupci;
         }
        
         public void IzbrisiIzPostupaka(Postupak postupak)
         {
             var stariPostupci = _view.Postupci;
            //_view.Bolesti = stareBolesti.Remove(bolest;
            stariPostupci.Remove(postupak);
            _view.Postupci = stariPostupci;
         }
        public void DodajLijek()
        {
            LijekoviKodVeterinaraForm form = new LijekoviKodVeterinaraForm();
            form.Lijekovi = _repositoryVeterinar.DohvatiSveLijekoveKodVeterinara(NHibernateService.PrijavljeniVeterinar.Id);
            form.Presenter = this;
            
            form.Show();
        }
        public void DodaniLijekovi(List<LijekKodVeterinara> lijekovi)
        {
            var stavke = _view.Lijekovi;
            foreach(var lijek in lijekovi)
            {
                var test = stavke.Where(stavka => stavka.LijekKodVeterinara.Equals(lijek)).SingleOrDefault();
                
                if (test != null)
                {
                    test.Kolicina += 1;
                }
                else
                {
                    LijekStavkaRacuna stavka = new LijekStavkaRacuna()
                    {
                        Kolicina = 1,
                        LijekKodVeterinara = lijek
                    };
                    stavke.Add(stavka);
                }
            }
            _view.Lijekovi = stavke;
        }
        public void IzbrisiIzLijekova(LijekStavkaRacuna lijek)
        {
            var stavke = _view.Lijekovi;
            var test = stavke.Where(stavka => stavka.Equals(lijek)).SingleOrDefault();
            if (test.Kolicina > 1)
            {
                test.Kolicina -= 1;
            }
            else
            {
                stavke.Remove(test);
            }
            _view.Lijekovi = stavke;

        }
        /**
         public void DodajTerapiju()
         {
             LijekoviForm form = new LijekoviForm();
             LijekoviPresenter presenter = new LijekoviPresenter(form, new LijekoviRepository(), this);
             form.Show();
         }
         public void DodanaTerapija(List<Lijek> lijekovi)
         {
             var stariLijekovi = _view.Lijekovi;
             stariLijekovi.AddRange(lijekovi);
             stariLijekovi = stariLijekovi.Distinct().ToList();
             _view.Lijekovi = stariLijekovi;
             var s = SloziInterakcijuUpozorenje(stariLijekovi);
             _view.InterakcijaUpozorenje = s;
         }
         public void IzbrisiIzTerapije(Lijek lijek)
         {
             var stariLijekovi = _view.Lijekovi;
             stariLijekovi.Remove(lijek);
             _view.Lijekovi = stariLijekovi.Distinct().ToList();
             var s = SloziInterakcijuUpozorenje(stariLijekovi);
             _view.InterakcijaUpozorenje = s;
         }


         public void NoviPostupak(Zivotinja zivotinja, VrstaPostupka vrsta, List<Lijek> lijekovi, List<Bolest> bolesti, String napomena)
         {
             Postupak novi = new Postupak
             {
                 Zivotinja = zivotinja,
                 Lijeks = new HashSet<Lijek>(lijekovi),
                 Bolests = new HashSet<Bolest>(bolesti),
                 Opaska = napomena,
                 VrstaPostupka = vrsta,
                 Datum = DateTime.Now
             };
             _repository.Stvori(novi);
         }
         */
    }
}