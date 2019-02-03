
using Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Model.Domain {
    
    public class VrstaPostupka : EntityClass {
        public VrstaPostupka() { }
        public VrstaPostupka(Veterinar veterinar, string naziv, string opis, double cijena, bool aktivno) {
            Postupaks = new List<Postupak>();
            Veterinar = Veterinar;
            Naziv = naziv;
            Opis = opis;
            Cijena = cijena;
            Aktivno = aktivno;
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
