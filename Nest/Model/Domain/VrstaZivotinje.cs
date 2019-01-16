
using Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Model.Domain {
    
    public class VrstaZivotinje : EntityClass{
        public VrstaZivotinje() {
            Zivotinjas = new List<Zivotinja>();

        }
        //public virtual System.Guid Id { get; set; }
        public virtual Veterinar Veterinar { get; set; }
        [Required]
        public virtual string Vrsta { get; set; }
        public virtual IList<Zivotinja> Zivotinjas { get; set; }

    }
}
