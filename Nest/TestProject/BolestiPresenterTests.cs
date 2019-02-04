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
    public class BolestiPresenterTests
    {
        private readonly List<Bolest> stubList = new List<Bolest> {
                new Bolest {Id = 1,Naziv = "Malarija", Opis = "Bolest1"},
                new Bolest {Id = 2, Naziv = "Upala grla", Opis = "Bolest2"},
                new Bolest {Id = 3,Naziv = "Upala pluæa", Opis = "Bolest3"}
        };

        private readonly IBolestiView mockBolestiView;
        private readonly Mock<IBolestiRepository> mockBolestiRepository;
        private readonly BolestiPresenter presenter;
        private readonly Mock<IUnitOfWork> mockUOW;

        public BolestiPresenterTests()
        {
            mockUOW = new Mock<IUnitOfWork>();
            mockBolestiView = Mock.Of<IBolestiView>(view =>
                view.Bolesti == new List<Bolest>());
            mockBolestiRepository = new Mock<IBolestiRepository>();
            mockBolestiRepository.Setup(x => x.DohvatiSve()).Returns(stubList);
            mockUOW.Setup(x => x.BolestiRepository).Returns(mockBolestiRepository.Object);

            presenter = new BolestiPresenter(mockBolestiView, mockUOW.Object, null);
        }

        [Fact]
        public void BolestiPresenter_constructor_TrebaNapunitiListu()
        {          
            Assert.Equal<IList<Bolest>>(mockBolestiView.Bolesti, stubList);
        }

        [Fact]
        public void BolestiPresenter_UpdateBolestiListView_BezUpita()
        {
            presenter.UpdateBolestiListView();
            Assert.Equal<IList<Bolest>>(mockBolestiView.Bolesti, stubList);
        }
        [Fact]
        public void BolestiPresenter_UpdateBolestiListView_SaUpitom()
        {
            presenter.UpdateBolestiListView("upAla");
            Assert.Equal<IList<Bolest>>(mockBolestiView.Bolesti, stubList.Where(x => x.Naziv.ToLower().Contains("upala")).ToList());
        }
    }
}
