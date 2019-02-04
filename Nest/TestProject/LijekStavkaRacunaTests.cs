using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace TestProject
{
    public class LijekStavkaRacunaTests
    {
        [Fact]
        public void Racun_PovecajKolicinu_Uspjesno()
        {
            var stavka = new LijekStavkaRacuna { Kolicina = 5 };
            stavka.PovecajKolicinu(6);
            
            Assert.Equal(11, stavka.Kolicina);
        }
        [Fact]
        public void Racun_SmanjiKolicinu_Uspjesno()
        {
            var stavka = new LijekStavkaRacuna { Kolicina = 5 };
            stavka.SmanjiKolicinu(4);

            Assert.Equal(1, stavka.Kolicina);
        }
        [Fact]
        public void Racun_PovecajKolicinu_NegativniBroj()
        {
            var stavka = new LijekStavkaRacuna { Kolicina = 5 };
            Assert.Throws<ArgumentException>(() => stavka.PovecajKolicinu(-4));

        }
        [Fact]
        public void Racun_SmanjiKolicinu_NegativniBroj()
        {
            var stavka = new LijekStavkaRacuna { Kolicina = 5 };

            Assert.Throws<ArgumentException>(()=> stavka.SmanjiKolicinu(-4));
        }
        [Fact]
        public void Racun_SmanjiKolicinu_Previse()
        {
            var stavka = new LijekStavkaRacuna { Kolicina = 5 };

            Assert.Throws<ArgumentException>(() => stavka.SmanjiKolicinu(10));
        }
    }
}
