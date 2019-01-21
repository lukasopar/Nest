
using Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Model.Domain {
    
    public class VrstaPostupka : EntityClass {
        public VrstaPostupka() {
            Postupaks = new List<Postupak>();

        }
        //public virtual System.Guid Id { get; set; }
        public virtual Veterinar Veterinar { get; set; }
        [Required]
        public virtual string Naziv { get; set; }
        public virtual string Opis { get; set; }
        [Required]
        public virtual double Cijena { get; set; }
        public virtual bool Aktivno { get; set; }
        public virtual IEnumerable<Postupak> Postupaks { get; set; }


    }
}
