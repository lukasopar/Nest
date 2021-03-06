﻿using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nest.Model.Domain
{
    public class LijekStavkaRacuna : EntityClass
    {
        public LijekStavkaRacuna() { }
        public LijekStavkaRacuna(int kolicina, LijekKodVeterinara lijek, Racun racun)
        {
            Kolicina = kolicina;
            LijekKodVeterinara = lijek;
            Racun = racun;
        }

        public virtual int Kolicina { get; set; }
        public virtual LijekKodVeterinara LijekKodVeterinara { get; set; }
        public virtual Racun Racun { get; set; }
        public virtual void PovecajKolicinu(int kolicina)
        {
            if (kolicina <= 0)
                throw new ArgumentException("Kolicina ne moze biti negativna");

            Kolicina += kolicina;
        }
        public virtual void SmanjiKolicinu(int kolicina)
        {
            if(kolicina <= 0)
                throw new ArgumentException("Kolicina ne moze biti negativna");

            if (Kolicina - kolicina <= 0)
                throw new ArgumentException("Kolicina ne moze biti negativna");
            Kolicina -= kolicina;
        }
    }
}
