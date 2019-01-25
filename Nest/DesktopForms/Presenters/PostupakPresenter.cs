using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseBootstrap;
using DatabaseBootstrap.IRepositories;
using DatabaseBootstrap.Repositories;
using DesktopForms.Views;
using DesktopForms.ViewInterfaces;
using Nest.Model.Domain;

namespace DesktopForms.Presenters
{
    public class PostupakPresenter
    {
        IPostupakView _view;
        IPostupakRepository _repository;
        IVeterinarRepository _repositoryVeterinar;
        ILijekoviRepository _repositoryLijekovi;
        public PostupakPresenter(IPostupakView view, IPostupakRepository repository, IVeterinarRepository veterinarRepository, ILijekoviRepository lijekoviRepository)
        {
            _view = view;
            view.Presenter = this;
            _repository = repository;
            _repositoryVeterinar = veterinarRepository;
            _repositoryLijekovi = lijekoviRepository;
            NapuniView();
        }

        private void NapuniView()
        {
            _view.Zivotinja = null;
            _view.VrstePostupaka = _repositoryVeterinar.DohvatiSvePostupke(NHibernateService.PrijavljeniVeterinar.Id);
            _view.Bolesti = new List<Bolest>();
            _view.Lijekovi = new List<Lijek>();
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
            //_view.Bolesti = stareBolesti.Remove(bolest;
            stareBolesti.Remove(bolest);
            _view.Bolesti = stareBolesti.Distinct().ToList();
        }
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
        private string SloziInterakcijuUpozorenje(List<Lijek> lijekovi)
        {
            string upozorenje = "";

            foreach (var lijek in lijekovi)
            {
                var lijekSInterakcijama = _repositoryLijekovi.DohvatiLijekPoId(lijek.Id);
                foreach(var interakcija in lijekSInterakcijama.InterakcijaLijekovas1)
                {
                    if (lijekovi.Contains(interakcija.Lijek2))
                        upozorenje += interakcija.Lijek1.Naziv + " i " + interakcija.Lijek2.Naziv + " reagiraju. Opis: " + interakcija.Opis + "\n";
                    //if (interakcija.Lijek2 == lijek && lijekovi.Contains(interakcija.Lijek1))
                      //  upozorenje += interakcija.Lijek1.Naziv + " i " + interakcija.Lijek2.Naziv + " reagiraju. Opis: " + interakcija.Opis + "\n";

                }
                /*foreach (var interakcija in lijekSInterakcijama.InterakcijaLijekovas2)
                {
                    if (lijekovi.Contains(interakcija.Lijek1))
                        upozorenje += interakcija.Lijek1.Naziv + " i " + interakcija.Lijek2.Naziv + " reagiraju. Opis: " + interakcija.Opis + "\n";
                    
                }*/
            }
            return upozorenje;
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
        public void PovijestZivotinje(Zivotinja zivotinja)
        {
            var lista = _repository.DohvatiSDetaljimaPostupkeZivotinja(zivotinja.Id);
            PovijestPregledaForm form = new PovijestPregledaForm();
            form.Postupci = lista;
            form.Presenter = null;
            form.Dodavanje = false;
            form.Izvjestaj = false;
            form.Show();
        }
    }
}