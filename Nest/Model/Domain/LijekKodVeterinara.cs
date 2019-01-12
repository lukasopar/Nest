using Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Model.Domain {
    
    public class LijekKodVeterinara : EntityClass {
        public LijekKodVeterinara() {
            Racuns = new List<Racun>();
        }
        //public virtual System.Guid Id { get; set; }
        public virtual Lijek Lijek { get; set; }
        public virtual Veterinar Veterinar { get; set; }
        [Required]
        public virtual decimal Cijena { get; set; }
        public virtual string Napomena { get; set; }
       
        public virtual IEnumerable<Racun> Racuns { get; set; }
    }
}
