

using Model;
using System;
using System.Collections.Generic;

namespace Nest.Model.Domain {
    
    public class Postupak : EntityClass{
        public Postupak() { }
        public Postupak(Zivotinja zivotinja, VrstaPostupka vrsta, string opaska, DateTime? datum, Racun racun) {
            Bolests = new HashSet<Bolest>();
            Lijeks = new HashSet<Lijek>();
            Zivotinja = zivotinja;
            VrstaPostupka = vrsta;
            Opaska = opaska;
            Datum = datum;
            Racun = racun;

            //PostupakNaRacunus = new List<PostupakNaRacunu>();
        }
        //public virtual System.Guid Id { get; set; }
        //public virtual Veterinar Veterinar { get; set; }
        public virtual Zivotinja Zivotinja { get; set; }
        public virtual VrstaPostupka VrstaPostupka { get; set; }
        public virtual string Opaska { get; set; }
        public virtual DateTime? Datum { get; set; }
        public virtual ISet<Bolest> Bolests { get; set; }
        public virtual ISet<Lijek> Lijeks { get; set; }
        public virtual Racun Racun { get; set; }
        //public virtual IEnumerable<PostupakNaRacunu> PostupakNaRacunus { get; set; }

    }
}
