using System.ComponentModel.DataAnnotations;


namespace Nest.Desktop.Domain {
    
    public class LijekNaRacunu {
        public virtual System.Guid Id { get; set; }
        public virtual Racun Racun { get; set; }
        public virtual LijekKodVeterinara LijekKodVeterinara { get; set; }
        [Required]
        public virtual int Kolicina { get; set; }
    }
}
