using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Model.Domain {
    
    public class Bolest {
        public Bolest() {
            Postupaks = new List<Postupak>();
            Lijeks = new List<Lijek>();
        }
        public virtual System.Guid Id { get; set; }
        [Required]
        public virtual string Naziv { get; set; }
        public virtual string Opis { get; set; }
        public virtual IEnumerable<Postupak> Postupaks { get; set; }
        public virtual IEnumerable<Lijek> Lijeks { get; set; }


    }
}
