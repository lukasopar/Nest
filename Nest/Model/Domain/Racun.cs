
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Model.Domain {
    
    public class Racun : EntityClass {

        public Racun() { }
        public Racun(DateTime datum) {
            LijekStavkaRacunas = new HashSet<LijekStavkaRacuna>();
            Postupaks = new HashSet<Postupak>();
            Datum = datum;
        }
        //public virtual System.Guid Id { get; set; }
        [Required]
        public virtual DateTime Datum { get; set; }
        public virtual ISet<LijekStavkaRacuna> LijekStavkaRacunas { get; set; }
        public virtual ISet<Postupak> Postupaks { get; set; }
        public virtual double IzracunajUkupnuCijenu()
        {
            double cijena = 0;
            foreach(var stavka in LijekStavkaRacunas)
            {
                cijena += stavka.Kolicina *stavka.LijekKodVeterinara.Cijena;
            }
            foreach(var postupak in Postupaks)
            {
                cijena += postupak.VrstaPostupka.Cijena;
            }
            return cijena;
        }
    }
}
