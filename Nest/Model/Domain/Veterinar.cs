using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Model.Domain {
    
    public class Veterinar {
        public Veterinar()
        {
            LijekKodVeterinaras = new List<LijekKodVeterinara>();
           // Postupaks = new List<Postupak>();
            VrstaPostupkas = new List<VrstaPostupka>();
            VrstaZivotinjes = new List<VrstaZivotinje>();
           // VrstaZivotinjeKodVeterinaras = new List<VrstaZivotinjeKodVeterinara>();
        }
        public virtual System.Guid Id { get; set; }
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
