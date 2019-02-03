using System;
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
    public class PostupakPresenter
    {
        private IPostupakView _view;
        private UnitOfWork _unit;
        public PostupakPresenter(IPostupakView view, UnitOfWork unit)
        {
            _view = view;
            view.Presenter = this;
            _unit = unit;
            NapuniView();
        }

        private void NapuniView()
        {
            _view.Zivotinja = null;
            _view.VrstePostupaka = _unit.VeterinarRepository.DohvatiSvePostupke(NHibernateService.PrijavljeniVeterinar.Id);
            _view.Bolesti = new List<Bolest>();
            _view.Lijekovi = new List<Lijek>();
        }
        public void OdaberiZivotinju()
        {
            PridruziZivotinjuForm form = new PridruziZivotinjuForm();
            PridruziZivotinjuPresenter presenter = new PridruziZivotinjuPresenter(form, new UnitOfWork(), this);
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
            BolestiPresenter presenter = new BolestiPresenter(form, _unit, this);
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
            LijekoviPresenter presenter = new LijekoviPresenter(form,_unit, this);
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
            var s = SloziInterakcijuUpozorenje(_view.Lijekovi);
            _view.InterakcijaUpozorenje = s;
        }
        private string SloziInterakcijuUpozorenje(List<Lijek> lijekovi)
        {
            string upozorenje = "";

            foreach (var lijek in lijekovi)
            {
                var lijekSInterakcijama = _unit.LijekoviRepository.DohvatiLijekPoId(lijek.Id);
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
            Postupak novi = ModelFactory.CreatePostupak(zivotinja, vrsta, napomena, DateTime.Now, null);
            _unit.PostupakRepository.Stvori(novi);
        }
        public void PovijestZivotinje(Zivotinja zivotinja)
        {
            var lista = _unit.PostupakRepository.DohvatiSDetaljimaPostupkeZivotinja(zivotinja.Id);
            PovijestPregledaForm form = new PovijestPregledaForm();
            form.Postupci = lista;
            form.Presenter = null;
            form.Dodavanje = false;
            form.Izvjestaj = false;
            form.Show();
        }

        public void CloseUnitOfWork()
        {
            this._unit.Dispose();
        }
    }
}