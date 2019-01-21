using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nest.Model.Domain
{
    public class LijekStavkaRacuna : EntityClass
    {
        public virtual int Kolicina { get; set; }
        public virtual LijekKodVeterinara LijekKodVeterinara { get; set; }
        public virtual Racun Racun { get; set; }
    }
}
