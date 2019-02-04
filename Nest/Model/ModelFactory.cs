using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ModelFactory
    {
        public static Bolest CreateBolest(string naziv, string opis)
        {
            return new Bolest(naziv, opis);
        }

        public static InterakcijaLijekova CreateInterakcijaLijekova(Lijek lijek1, Lijek lijek2, string opis)
        {
            return new InterakcijaLijekova(lijek1, lijek2, opis);
        }
        public static Lijek CreateLijek(string naziv, string opis)
        {
            return new Lijek(naziv, opis);
        }
        public static LijekKodVeterinara CreateLijekKodVeterinara(Lijek lijek, Veterinar veterinar, double cijena, bool aktivno, string napomena)
        {
            return new LijekKodVeterinara(lijek, veterinar, cijena, aktivno, napomena);
        }
        public static LijekStavkaRacuna CreateLijekStavkaRacuna(int kolicina, LijekKodVeterinara lijek, Racun racun)
        {
            return new LijekStavkaRacuna(kolicina, lijek, racun);
        }
        public static Postupak CreatePostupak(Zivotinja zivotinja, VrstaPostupka vrsta, string opaska, DateTime? datum, Racun racun)
        {
            return new Postupak(zivotinja, vrsta, opaska, datum, racun);
        }
        public static Racun CreateRacun(DateTime datum)
        {
            return new Racun(datum);
        }
        public static Veterinar CreateVeterinar(string korisnickoIme, string lozinka, string ime, string prezime, DateTime? datumRod, DateTime? datumLicence)
        {
            return new Veterinar(korisnickoIme, lozinka, ime, prezime, datumRod, datumLicence);
        }
        public static Vlasnik CreateVlasnik(string korisnickoIme, string lozinka, string ime, string prezime, DateTime? datumRod)
        {
            return new Vlasnik(korisnickoIme, lozinka, ime, prezime, datumRod);
        }
        public static VrstaZivotinje CreateVrstaZivotinje(Veterinar veterinar, string vrsta, bool aktivno)
        {
            return new VrstaZivotinje(veterinar, vrsta, aktivno);
        }
        public static VrstaPostupka CreateVrstaPostupka(Veterinar veterinar, string naziv, string opis, double cijena, bool aktivno)
        {
            return new VrstaPostupka(veterinar, naziv, opis, cijena, aktivno);
        }
        public static Zivotinja CreateZivotinja(Vlasnik vlasnik, string ime, DateTime? datumRod, string napomena)
        {
            return new Zivotinja(vlasnik, ime, datumRod, napomena);
        }

    }
}
