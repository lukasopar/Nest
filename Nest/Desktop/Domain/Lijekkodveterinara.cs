using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Desktop.Domain {
    
    public class LijekKodVeterinara {
        public LijekKodVeterinara() {
            LijekNaPostupkus = new List<LijekNaPostupku>();
            LijekNaRacunus = new List<LijekNaRacunu>();
        }
        public virtual System.Guid Id { get; set; }
        public virtual Lijek Lijek { get; set; }
        public virtual Veterinar Veterinar { get; set; }
        [Required]
        public virtual decimal Cijena { get; set; }
        public virtual string Napomena { get; set; }
        public virtual IEnumerable<LijekNaPostupku> LijekNaPostupkus { get; set; }
        public virtual IEnumerable<LijekNaRacunu> LijekNaRacunus { get; set; }
    }
}
