using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Desktop.Domain {
    
    public class Lijek {
        public Lijek() {
            InterakcijaLijekovas1 = new List<InterakcijaLijekova>();
            InterakcijaLijekovas2 = new List<InterakcijaLijekova>();
            LijekKodVeterinaras = new List<LijekKodVeterinara>();
            LijekZaBolests = new List<LijekZaBolest>();
        }
        public virtual System.Guid Id { get; set; }
        [Required]
        public virtual string Naziv { get; set; }
        public virtual string Opis { get; set; }
        public virtual IEnumerable<InterakcijaLijekova> InterakcijaLijekovas1 { get; set; }
        public virtual IEnumerable<InterakcijaLijekova> InterakcijaLijekovas2 { get; set; }
        public virtual IEnumerable<LijekKodVeterinara> LijekKodVeterinaras { get; set; }
        public virtual IEnumerable<LijekZaBolest> LijekZaBolests { get; set; }
    }
}
