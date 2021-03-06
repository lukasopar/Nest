﻿using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseBootstrap;
using DatabaseBootstrap.IRepositories;
using DatabaseBootstrap.Repositories;
using DesktopForms.Views;
using DesktopForms.ViewInterfaces;
using Nest.Model.Domain;
using Model;

namespace DesktopForms.Presenters
{
    public class RacunPresenter
    {
        private IRacunView _view;
        private IUnitOfWork _unit;
        public RacunPresenter(IRacunView view,  IUnitOfWork unit)
        {
            _view = view;
            view.Presenter = this;
            _unit = unit;
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
            form.Postupci = _unit.PostupakRepository.DohvatiSDetaljimaPostupkeNeplacene(NHibernateService.PrijavljeniVeterinar.Id);
            form.Presenter = this;
            form.Dodavanje = true;
            form.Izvjestaj = false;
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
            form.Lijekovi = _unit.VeterinarRepository.DohvatiSveLijekoveKodVeterinara(NHibernateService.PrijavljeniVeterinar.Id);
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
                    test.PovecajKolicinu(1);
                }
                else
                {
                    LijekStavkaRacuna stavka = ModelFactory.CreateLijekStavkaRacuna(1, lijek, null);
                    stavke.Add(stavka);
                    _unit.StavkeRepository.Stvori(stavka);
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
                test.SmanjiKolicinu(1);
                _unit.StavkeRepository.Azuriraj(test);
            }
            else
            {
                stavke.Remove(test);
                //_unit.StavkeRepository.Izbrisi(test.Id);
            }
            _view.Lijekovi = stavke;

        }
        public void NoviRacun(Racun racun)
        {
            racun.Datum = DateTime.Now;
            _unit.RacunRepository.Stvori(racun);
            CloseUnitOfWork();
        }

        public void CloseUnitOfWork()
        {
            this._unit.Dispose();
        }

    }
}