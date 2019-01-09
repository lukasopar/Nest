
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Desktop.Domain {
    
    public class VrstaPostupka {
        public VrstaPostupka() {
            Postupaks = new List<Postupak>();

        }
        public virtual System.Guid Id { get; set; }
        public virtual Veterinar Veterinar { get; set; }
        [Required]
        public virtual string Naziv { get; set; }
        public virtual string Opis { get; set; }
        [Required]
        public virtual decimal Cijena { get; set; }
        public virtual IEnumerable<Postupak> Postupaks { get; set; }


    }
}
