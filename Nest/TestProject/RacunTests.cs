using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace TestProject
{
    public class RacunTests
    {
        [Fact]
        public void Racun_IzracunajUkupnuCijenu_Test()
        {
            var stavke = new HashSet<LijekStavkaRacuna>()
            {
                new LijekStavkaRacuna(){Id = 1, Kolicina = 2, LijekKodVeterinara = new LijekKodVeterinara(){Cijena = 30}},
                new LijekStavkaRacuna(){Id = 2, Kolicina = 1, LijekKodVeterinara = new LijekKodVeterinara(){Cijena = 40}}

            };
            var postupci = new HashSet<Postupak>()
            {
                new Postupak(){VrstaPostupka = new VrstaPostupka(){Cijena = 50}}
            };
            Racun racun = new Racun()
            {
                Id = 1,
                LijekStavkaRacunas = stavke,
                Postupaks = postupci
            };

            var result = racun.IzracunajUkupnuCijenu();
            Assert.Equal(150, result);
        }
    }
}
