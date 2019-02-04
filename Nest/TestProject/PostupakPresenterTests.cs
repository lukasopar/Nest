using DatabaseBootstrap;
using DatabaseBootstrap.IRepositories;
using DatabaseBootstrap.Repositories;
using DesktopForms.Presenters;
using DesktopForms.ViewInterfaces;
using Moq;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace TestProject
{
    public class PostupakPresenterTests
    {
        private Zivotinja zivotinja1 = new Zivotinja { Id=1, Ime = "Jura" };
        private Zivotinja zivotinja2 = new Zivotinja { Id = 2, Ime = "Krešo" };
        private Lijek lijek1 = new Lijek { Id = 1, Naziv = "Lijek1", InterakcijaLijekovas1 = new HashSet<InterakcijaLijekova>(), InterakcijaLijekovas2 = new HashSet<InterakcijaLijekova>() };
        private Lijek lijek2 = new Lijek { Id = 2, Naziv = "Lijek2", InterakcijaLijekovas1 = new HashSet<InterakcijaLijekova>(), InterakcijaLijekovas2 = new HashSet<InterakcijaLijekova>() };

        private readonly List<VrstaPostupka> stubList = new List<VrstaPostupka> {
                new VrstaPostupka {Id = 1,Naziv = "Pregled"},
                new VrstaPostupka {Id = 2,Naziv = "Zahvat"},
        };

        private readonly IPostupakView mockPostupakView;
        private readonly Mock<IPostupakRepository> mockPostupakRepository;
        private readonly Mock<IVeterinarRepository> mockVeterinarRepository;
        private readonly Mock<ILijekoviRepository> mockLijekoviRepository;
        private readonly PostupakPresenter presenter;
        private readonly Mock<IUnitOfWork> mockUOW;

        public PostupakPresenterTests()
        {
            mockUOW = new Mock<IUnitOfWork>();

            mockPostupakView = Mock.Of<IPostupakView>(view =>
                view.VrstePostupaka == new List<VrstaPostupka>() && view.Lijekovi == new List<Lijek>() && view.Bolesti == new List<Bolest>() );
            mockPostupakRepository = new Mock<IPostupakRepository>();
            mockVeterinarRepository = new Mock<IVeterinarRepository>();
            mockLijekoviRepository = new Mock<ILijekoviRepository>();
            mockVeterinarRepository.Setup(x => x.DohvatiSvePostupke(1)).Returns(stubList);
            NHibernateService.PrijavljeniVeterinar = new Veterinar { Id = 1 };

            mockLijekoviRepository.Setup(x => x.DohvatiLijekPoId(1)).Returns(lijek1);
            mockLijekoviRepository.Setup(x => x.DohvatiLijekPoId(2)).Returns(lijek2);

            mockUOW.Setup(x => x.LijekoviRepository).Returns(mockLijekoviRepository.Object);
            mockUOW.Setup(x => x.VeterinarRepository).Returns(mockVeterinarRepository.Object);
            mockUOW.Setup(x => x.PostupakRepository).Returns(mockPostupakRepository.Object);

            presenter = new PostupakPresenter(mockPostupakView, mockUOW.Object);
        }
        [Fact]
        public void PostupakPresenter_constructor_TrebaNapunitiListu()
        {
            Assert.Equal<IList<VrstaPostupka>>(mockPostupakView.VrstePostupaka, stubList);
        }
        [Fact]
        public void PostupakPresenter_OdabranaZivotinja_PromjenaZivotinje()
        {
            presenter.OdabranaZivotinja(zivotinja2);
            Assert.Equal<Zivotinja>(mockPostupakView.Zivotinja, zivotinja2);
        }
        [Fact]
        public void PostupakPresenter_DodanaDijagnoza_DodaneBolesti()
        {
            var lista = new List<Bolest> {
                new Bolest {Id = 1,Naziv = "Bolest1"},
                new Bolest {Id = 2,Naziv = "Bolest2"},
            };
            presenter.DodanaDijagnoza(lista);
            Assert.Equal<IList<Bolest>>(mockPostupakView.Bolesti, lista);
        }
        [Fact]
        public void PostupakPresenter_DodanaDijagnoza_DodaneBolestiVisePuta()
        {
            var lista = new List<Bolest> {
                new Bolest {Id = 1,Naziv = "Bolest1"},
                new Bolest {Id = 2,Naziv = "Bolest2"},
            };
            presenter.DodanaDijagnoza(lista);
            presenter.DodanaDijagnoza(lista);

            Assert.Equal<IList<Bolest>>(mockPostupakView.Bolesti, lista);
        }
        [Fact]
        public void PostupakPresenter_IzbrisiIzDijagnoze_IzbrisiBolest()
        {
            var lista = new List<Bolest> {
                new Bolest {Id = 1,Naziv = "Bolest1"},
                new Bolest {Id = 2,Naziv = "Bolest2"},
            };
            presenter.DodanaDijagnoza(lista);
            presenter.IzbrisiIzDijagnoze(new Bolest { Id = 2 });

            Assert.Equal<IList<Bolest>>(mockPostupakView.Bolesti, lista.Where(x => x.Id==1).ToList());
        }
        [Fact]
        public void PostupakPresenter_DodanaTerapija_DodaniLijekovi()
        {
            var lista = new List<Lijek> {
                lijek1,
                lijek2
            };
            presenter.DodanaTerapija(lista);
            Assert.Equal<IList<Lijek>>(mockPostupakView.Lijekovi, lista);
        }
        [Fact]
        public void PostupakPresenter_DodanaTerapija_DodaniLijekoviVisePuta()
        {
            var lista = new List<Lijek> {
                new Lijek {Id = 1,Naziv = "Lijek1"},
                new Lijek {Id = 2,Naziv = "Lijek2"},
            };
            presenter.DodanaTerapija(lista);
            presenter.DodanaTerapija(lista);

            Assert.Equal<IList<Lijek>>(mockPostupakView.Lijekovi, lista);
        }
        [Fact]
        public void PostupakPresenter_IzbrisiIzTerapije_IzbrisiLijek()
        {
            var lista = new List<Lijek> {
                new Lijek {Id = 1,Naziv = "Lijek1", InterakcijaLijekovas1 = new HashSet<InterakcijaLijekova>(), InterakcijaLijekovas2 = new HashSet<InterakcijaLijekova>()},
                new Lijek {Id = 2,Naziv = "Lijek2", InterakcijaLijekovas1 = new HashSet<InterakcijaLijekova>(), InterakcijaLijekovas2 = new HashSet<InterakcijaLijekova>()},
            };
            presenter.DodanaTerapija(lista);
            presenter.IzbrisiIzTerapije(new Lijek { Id = 2 });

            Assert.Equal<IList<Lijek>>(mockPostupakView.Lijekovi, lista.Where(x => x.Id == 1).ToList());
        }
        [Fact]
        public void PostupakPresenter_DodanaTerapija_ImaInterakcije()
        {
            lijek1.InterakcijaLijekovas1.Add(new InterakcijaLijekova { Lijek2 = lijek2, Lijek1 = lijek1 });
            lijek2.InterakcijaLijekovas2.Add(new InterakcijaLijekova { Lijek1 = lijek2, Lijek2 = lijek1 });
            var lista = new List<Lijek> {
                lijek1,
                lijek2
            };
           
            presenter.DodanaTerapija(lista);
            Assert.Equal<IList<Lijek>>(mockPostupakView.Lijekovi, lista);
            Assert.Equal("Lijek1 i Lijek2 reagiraju. Opis: " + '\n', mockPostupakView.InterakcijaUpozorenje);
        }
    }
}
