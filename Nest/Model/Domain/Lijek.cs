using Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Nest.Model.Domain {
    
    public class Lijek : EntityClass{
        public Lijek() {
            InterakcijaLijekovas1 = new List<InterakcijaLijekova>();
            InterakcijaLijekovas2 = new List<InterakcijaLijekova>();
            LijekKodVeterinaras = new List<LijekKodVeterinara>();
            Bolests = new List<Bolest>();
            Postupaks = new List<Postupak>();
        }
        //public virtual System.Guid Id { get; set; }
        [Required]
        public virtual string Naziv { get; set; }
        public virtual string Opis { get; set; }
        public virtual IEnumerable<InterakcijaLijekova> InterakcijaLijekovas1 { get; set; }
        public virtual IEnumerable<InterakcijaLijekova> InterakcijaLijekovas2 { get; set; }
        public virtual IEnumerable<LijekKodVeterinara> LijekKodVeterinaras { get; set; }
        public virtual IEnumerable<Bolest> Bolests { get; set; }
        public virtual IEnumerable<Postupak> Postupaks { get; set; }
    }
}
