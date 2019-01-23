using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Korisničko ime je obavezno.")]
        public string KorisnickoIme { get; set; }
        [Required(ErrorMessage = "Lozinka je obavezna.")]
        public string Password { get; set; }
    }
}
