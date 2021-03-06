﻿using DatabaseBootstrap.IRepositories;
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
    public class VlasnikPresenter
    {
        private readonly IVlasnikView _view;
        private readonly IUnitOfWork _unit;


        public VlasnikPresenter(IVlasnikView view, IUnitOfWork unit)
        {
            _view = view;
            view.Presenter = this;
            _unit = unit;
        }

        public void registrirajVlasnika(Vlasnik vlasnik)
        {
            _unit.VlasnikRepository.Stvori(vlasnik);
        }

        public void CloseUnitOfWork()
        {
            this._unit.Dispose();
        }

        internal bool KorisnickoImeZauzet(string text)
        {
            Vlasnik vlasnik = _unit.VlasnikRepository.DohvatiVlasnikaKorisnickoIme(text);
            return vlasnik != null;
        }
    }
}
