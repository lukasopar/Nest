using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Desktop.Domain {
    
    public class Zivotinja {
        public Zivotinja() {
            Postupaks = new List<Postupak>();
            VrstaZivotinjeKodVeterinaras = new List<VrstaZivotinjeKodVeterinara>();
        }
        public virtual System.Guid Id { get; set; }
        public virtual Vlasnik Vlasnik { get; set; }
        [Required]
        public virtual string Ime { get; set; }
        public virtual DateTime? Datumrod { get; set; }
        public virtual string Napomena { get; set; }
        public virtual IEnumerable<Postupak> Postupaks { get; set; }

        public virtual IEnumerable<VrstaZivotinjeKodVeterinara> VrstaZivotinjeKodVeterinaras { get; set; }

    }
}
