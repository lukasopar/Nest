
using Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Model.Domain {
    
    public class VrstaZivotinje : EntityClass{
        public VrstaZivotinje() { }
        public VrstaZivotinje(Veterinar veterinar, string vrsta, bool aktivno) {
            Zivotinjas = new List<Zivotinja>();
            Veterinar = veterinar;
            Vrsta = vrsta;
            Aktivno = aktivno;
        }
        //public virtual System.Guid Id { get; set; }
        public virtual Veterinar Veterinar { get; set; }
        [Required]
        public virtual string Vrsta { get; set; }
        public virtual bool Aktivno { get; set; }
        public virtual IList<Zivotinja> Zivotinjas { get; set; }

    }
}
