

using System;
using System.Collections.Generic;

namespace Nest.Desktop.Domain {
    
    public class Postupak {
        public Postupak() {
            BolestNaPostupkus = new List<BolestNaPostupku>();
            LijekNaPostupkus = new List<LijekNaPostupku>();
            PostupakNaRacunus = new List<PostupakNaRacunu>();
        }
        public virtual System.Guid Id { get; set; }
        public virtual Veterinar Veterinar { get; set; }
        public virtual Zivotinja Zivotinja { get; set; }
        public virtual VrstaPostupka VrstaPostupka { get; set; }
        public virtual string Opaska { get; set; }
        public virtual DateTime? Datum { get; set; }
        public virtual IEnumerable<BolestNaPostupku> BolestNaPostupkus { get; set; }
        public virtual IEnumerable<LijekNaPostupku> LijekNaPostupkus { get; set; }
        public virtual IEnumerable<PostupakNaRacunu> PostupakNaRacunus { get; set; }

    }
}
