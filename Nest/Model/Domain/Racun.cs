
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Model.Domain {
    
    public class Racun : EntityClass {
        public Racun() {
            LijekStavkaRacunas = new List<LijekStavkaRacuna>();
            Postupaks = new List<Postupak>();
        }
        //public virtual System.Guid Id { get; set; }
        [Required]
        public virtual DateTime Datum { get; set; }
        public virtual IEnumerable<LijekStavkaRacuna> LijekStavkaRacunas { get; set; }
        public virtual IEnumerable<Postupak> Postupaks { get; set; }
    }
}
