
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Model.Domain {
    
    public class Vlasnik {
        public Vlasnik() {
            Zivotinjas = new List<Zivotinja>();
        }
        public virtual System.Guid Id { get; set; }
        [Required]
        public virtual string KorisnickoIme { get; set; }
        [Required]
        public virtual string Lozinka { get; set; }
        [Required]
        public virtual string Ime { get; set; }
        [Required]
        public virtual string Prezime { get; set; }

        public virtual DateTime? DatumRod { get; set; }
        public virtual IEnumerable<Zivotinja> Zivotinjas { get; set; }

    }
}
