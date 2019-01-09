
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Desktop.Domain {
    
    public class Racun {
        public Racun() {
            LijekNaRacunus = new List<LijekNaRacunu>();
            PostupakNaRacunus = new List<PostupakNaRacunu>();
        }
        public virtual System.Guid Id { get; set; }
        [Required]
        public virtual DateTime Datum { get; set; }
        public virtual IEnumerable<LijekNaRacunu> LijekNaRacunus { get; set; }
        public virtual IEnumerable<PostupakNaRacunu> PostupakNaRacunus { get; set; }
    }
}
