using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Desktop.Domain {
    
    public class Bolest {
        public Bolest() {
            BolestNaPostupkus = new List<BolestNaPostupku>();
            LijekZaBolests = new List<LijekZaBolest>();
        }
        public virtual System.Guid Id { get; set; }
        [Required]
        public virtual string Naziv { get; set; }
        public virtual string Opis { get; set; }
        public virtual IEnumerable<BolestNaPostupku> BolestNaPostupkus { get; set; }
        public virtual IEnumerable<LijekZaBolest> LijekZaBolests { get; set; }


    }
}
