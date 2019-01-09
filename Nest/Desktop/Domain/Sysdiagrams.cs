using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Nest.Desktop.Domain {
    
    public class Sysdiagrams {
        public virtual int DiagramId { get; set; }
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual int PrincipalId { get; set; }
        public virtual int? Version { get; set; }
        public virtual byte[] Definition { get; set; }
    }
}
