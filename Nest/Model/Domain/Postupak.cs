

using Model;
using System;
using System.Collections.Generic;

namespace Nest.Model.Domain {
    
    public class Postupak : EntityClass{
        public Postupak() {
            Bolests = new List<Bolest>();
            Lijeks = new List<Lijek>();
            //PostupakNaRacunus = new List<PostupakNaRacunu>();
        }
        //public virtual System.Guid Id { get; set; }
        //public virtual Veterinar Veterinar { get; set; }
        public virtual Zivotinja Zivotinja { get; set; }
        public virtual VrstaPostupka VrstaPostupka { get; set; }
        public virtual string Opaska { get; set; }
        public virtual DateTime? Datum { get; set; }
        public virtual IEnumerable<Bolest> Bolests { get; set; }
        public virtual IEnumerable<Lijek> Lijeks { get; set; }
        public virtual Racun Racun { get; set; }
        //public virtual IEnumerable<PostupakNaRacunu> PostupakNaRacunus { get; set; }

    }
}
