using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Model.Domain {

    public class Veterinar : EntityClass {
        public Veterinar() { }
        public Veterinar(string korisnickoIme, string lozinka, string ime, string prezime, DateTime? datumRod, DateTime? datumLicence)
        {
            LijekKodVeterinaras = new List<LijekKodVeterinara>();
           // Postupaks = new List<Postupak>();
            VrstaPostupkas = new List<VrstaPostupka>();
            VrstaZivotinjes = new List<VrstaZivotinje>();
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            Ime = ime;
            Prezime = prezime;
            DatumRod = datumRod;
            DatumLicence = datumLicence;
           // VrstaZivotinjeKodVeterinaras = new List<VrstaZivotinjeKodVeterinara>();
        }
     //   public virtual System.Guid Id { get; set; }
        public virtual string KorisnickoIme { get; set; }
        public virtual string Lozinka { get; set; }
        [Required]
        public virtual string Ime { get; set; }
        [Required]
        public virtual string Prezime { get; set; }
        public virtual DateTime? DatumRod { get; set; }
        public virtual DateTime? DatumLicence { get; set; }
        
        public virtual IEnumerable<LijekKodVeterinara> LijekKodVeterinaras { get; set; }
        //public virtual IEnumerable<Postupak> Postupaks { get; set; }
        public virtual IEnumerable<VrstaPostupka> VrstaPostupkas { get; set; }
        public virtual IEnumerable<VrstaZivotinje> VrstaZivotinjes { get; set; }
        //public virtual IEnumerable<VrstaZivotinjeKodVeterinara> VrstaZivotinjeKodVeterinaras { get; set; }

    }
}
