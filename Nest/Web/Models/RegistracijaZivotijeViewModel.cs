using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class RegistracijaZivotinjeViewModel
    {
        [Required(ErrorMessage ="Ime je obavezno.")]
        public string Ime { get; set; }
        
        public string Napomena { get; set; }
       
        public string DatumRodenja { get; set; }
    }
}