
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Desktop.Domain {
    
    public class Vlasnik {
        public Vlasnik() {
            Zivotinjas = new List<Zivotinja>();
        }
        public virtual System.Guid Id { get; set; }
        [Required]
        public virtual string Ime { get; set; }
        [Required]
        public virtual string Prezime { get; set; }
        [Required]
        public virtual System.Guid Idprijava { get; set; }
        public virtual DateTime? Datumrod { get; set; }
        public virtual IEnumerable<Zivotinja> Zivotinjas { get; set; }

    }
}
