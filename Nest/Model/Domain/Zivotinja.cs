using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Model.Domain {
    
    public class Zivotinja :EntityClass{
        public Zivotinja() {
            Postupaks = new List<Postupak>();
            VrstaZivotinjes = new List<VrstaZivotinje>();
        }
        //public virtual System.Guid Id { get; set; }
        public virtual Vlasnik Vlasnik { get; set; }
        [Required]
        public virtual string Ime { get; set; }
        public virtual DateTime? DatumRod { get; set; }
        public virtual string Napomena { get; set; }
        public virtual IEnumerable<Postupak> Postupaks { get; set; }

        public virtual IList<VrstaZivotinje> VrstaZivotinjes { get; set; }

        public virtual void PridruziVrstuZivotinjeKodVeterinara(VrstaZivotinje vrsta)
        {
            VrstaZivotinjes.Add(vrsta);
        }
    }
}
