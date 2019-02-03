﻿using DatabaseBootstrap;
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
    public class DostupniLijekoviPresenter
    {
        private readonly IDostupniLijekovi _view;
        private readonly IUnitOfWork _unit;

        public DostupniLijekoviPresenter(IDostupniLijekovi view, IUnitOfWork unit)
        {
            _view = view;
            _view.Presenter = this;
            _unit = unit;
            UpdateLijekovi();
        }

        private void UpdateLijekovi()
        {
            List<Lijek> lijekovi = _unit.LijekoviRepository.DohvatiSve().ToList();
            List<LijekKodVeterinara> lijekoviVeterinara = _unit.VeterinarLijekRepository.DohvatiLijekoveVeterinara(NHibernateService.PrijavljeniVeterinar.Id);
            _view.Lijekovi = lijekovi;
            _view.LijekoviKodVeterinara = lijekoviVeterinara;
        }
        

        internal void DodajLijekVeterinaru(Lijek lijek, double number, string text)
        {
            LijekKodVeterinara lijekKodVeterinara = ModelFactory.CreateLijekKodVeterinara(lijek, NHibernateService.PrijavljeniVeterinar, number, true, text);
            _unit.VeterinarLijekRepository.Stvori(lijekKodVeterinara);
            AzurirajLijekoveVeterinara();
        }

        private void AzurirajLijekoveVeterinara()
        {
            List<LijekKodVeterinara> lijekoviVeterinara = _unit.VeterinarLijekRepository.DohvatiLijekoveVeterinara(NHibernateService.PrijavljeniVeterinar.Id);
            _view.LijekoviKodVeterinara = lijekoviVeterinara;
        }

        public void CloseUnitOfWork()
        {
            this._unit.Dispose();
        }

        internal void IzbrisiLijekKodVeterinara(LijekKodVeterinara lijek)
        {
            lijek.Aktivno = false;
            _unit.VeterinarLijekRepository.Azuriraj(lijek);
            AzurirajLijekoveVeterinara();
        }
    }
}
