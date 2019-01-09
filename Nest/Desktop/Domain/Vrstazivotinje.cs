
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Desktop.Domain {
    
    public class VrstaZivotinje {
        public VrstaZivotinje() {
            VrstaZivotinjeKodVeterinaras = new List<VrstaZivotinjeKodVeterinara>();

        }
        public virtual System.Guid Id { get; set; }
        public virtual Veterinar Veterinar { get; set; }
        [Required]
        public virtual string Vrsta { get; set; }
        public virtual IEnumerable<VrstaZivotinjeKodVeterinara> VrstaZivotinjeKodVeterinaras { get; set; }

    }
}
