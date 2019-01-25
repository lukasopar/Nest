using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class RegistracijaVlasnikaViewModel
    {
        [Required(ErrorMessage ="Ime je obavezno.")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Prezime je obavezno.")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Korisnièko ime je obavezno.")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezna.")]
        public string Lozinka { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezna.")]
        public string PonovljenaLozinka { get; set; }
        public string DatumRodenja { get; set; }
    }
}