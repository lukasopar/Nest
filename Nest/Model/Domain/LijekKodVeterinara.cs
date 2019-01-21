using Model;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Model.Domain {
    
    public class LijekKodVeterinara : EntityClass {
        public LijekKodVeterinara() {
            Stavkas = new List<LijekStavkaRacuna>();
        }
        //public virtual System.Guid Id { get; set; }
        public virtual Lijek Lijek { get; set; }
        public virtual Veterinar Veterinar { get; set; }
        [Required]
        public virtual double Cijena { get; set; }
        public virtual string Napomena { get; set; }
        public virtual bool Aktivno { get; set; }
       
        public virtual IEnumerable<LijekStavkaRacuna> Stavkas { get; set; }
    }
}
