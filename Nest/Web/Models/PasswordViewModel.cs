using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class PasswordViewModel
    {
        [Required(ErrorMessage = "Unesite svoju lozinku.")]
        public string StaraLoz { get; set; }
        [Required(ErrorMessage = "Unesite novu lozinku.")]
        public string NovaLoz { get; set; }
        [Required(ErrorMessage = "Ponovite novu lozinku.")]
        public string NovaLozPon { get; set; }

    }
}
