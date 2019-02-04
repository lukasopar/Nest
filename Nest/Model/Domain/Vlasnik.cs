
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Model.Domain {
    
    public class Vlasnik : EntityClass{
        public Vlasnik() { }
        public Vlasnik(string korisnickoIme, string lozinka, string ime, string prezime, DateTime? datumRod) {
            Zivotinjas = new List<Zivotinja>();
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            Ime = ime;
            Prezime = prezime;
            DatumRod = datumRod;
        }
//        public virtual System.Guid Id { get; set; }
        [Required]
        public virtual string KorisnickoIme { get; set; }
        [Required]
        public virtual string Lozinka { get; set; }
        [Required]
        public virtual string Ime { get; set; }
        [Required]
        public virtual string Prezime { get; set; }

        public virtual DateTime? DatumRod { get; set; }
        public virtual IList<Zivotinja> Zivotinjas { get; set; }

        public virtual void DodajZivotinju(Zivotinja zivotinja)
        {
            this.Zivotinjas.Add(zivotinja);
        }

    }
}
