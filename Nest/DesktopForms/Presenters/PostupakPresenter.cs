﻿using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseBootstrap;
using DatabaseBootstrap.IRepositories;
using DatabaseBootstrap.Repositories;
using DesktopForms.Views;
using DesktopFOrms.ViewInterfaces;
using DesktopFOrms.Views;
using Nest.Model.Domain;

namespace DesktopForms.Presenters
{
    public class PostupakPresenter
    {
        IPostupakView _view;
        IPostupakRepository _repository;
        IVeterinarRepository _repositoryVeterinar;
        public PostupakPresenter(IPostupakView view, IPostupakRepository repository, IVeterinarRepository veterinarRepository)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;
            _repositoryVeterinar = veterinarRepository;
            NapuniView();
        }

        private void NapuniView()
        {
            _view.Zivotinja = null;
            _view.VrstePostupaka = _repositoryVeterinar.DohvatiSvePostupke(NHibernateService.PrijavljeniVeterinar.Id);
            _view.Bolesti = new List<Bolest>();
        }
        public void OdaberiZivotinju()
        {
            PridruziZivotinjuForm form = new PridruziZivotinjuForm();
            PridruziZivotinjuPresenter presenter = new PridruziZivotinjuPresenter(form, new VlasnikRepository(), new VeterinarRepository(), new ZivotinjaRepository(), this);
            form.Show();
        }
        public void OdabranaZivotinja(Zivotinja zivotinja)
        {
            _view.Zivotinja = zivotinja;
        }
        public void DodanaDijagnoza(List<Bolest> bolesti)
        {
            var stareBolesti = _view.Bolesti;
            stareBolesti.AddRange(bolesti);
            stareBolesti = stareBolesti.Distinct().ToList();
            _view.Bolesti = stareBolesti;
        }
        public void DodajDijagnozu()
        {
            BolestForm form = new BolestForm();
            BolestiPresenter presenter = new BolestiPresenter(form, new BolestiRepository(), this);
            form.Show();
        }
        public void IzbrisiIzDijagnoze(Bolest bolest)
        {
            var stareBolesti = _view.Bolesti;
            _view.Bolesti = null;
            stareBolesti.Remove(bolest);
            _view.Bolesti = stareBolesti;
        }
    }
}