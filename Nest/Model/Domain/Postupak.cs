

using Model;
using System;
using System.Collections.Generic;

namespace Nest.Model.Domain {
    
    public class Postupak : EntityClass{
        public Postupak() {
            Bolests = new HashSet<Bolest>();
            Lijeks = new HashSet<Lijek>();
        }
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
        public virtual void DodajBolest(Bolest bolest)
        {
            Bolests.Add(bolest);
        }
        public virtual void MakniBolest(Bolest bolest)
        {
            Bolests.Remove(bolest);
        }
        public virtual void DodajLijek(Lijek lijek)
        {
            Lijeks.Add(lijek);
        }
        public virtual void MakniLijek(Lijek lijek)
        {
            Lijeks.Remove(lijek);
        }
    }
}
