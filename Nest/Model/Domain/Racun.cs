
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Model.Domain {
    
    public class Racun {
        public Racun() {
            LijekKodVeterinaras = new List<LijekKodVeterinara>();
            Postupaks = new List<Postupak>();
        }
        public virtual System.Guid Id { get; set; }
        [Required]
        public virtual DateTime Datum { get; set; }
        public virtual IEnumerable<LijekKodVeterinara> LijekKodVeterinaras { get; set; }
        public virtual IEnumerable<Postupak> Postupaks { get; set; }
    }
}
