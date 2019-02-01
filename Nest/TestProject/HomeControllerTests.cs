using DatabaseBootstrap.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Nest.Model.Domain;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Web.Controllers;
using Web.Models;
using Xunit;

namespace TestProject
{
    public class HomeControllerTests
    {
        private readonly Mock<IBolestiRepository> mockBolestiRepository;
        private readonly Mock<IVlasnikRepository> mockVlasnikRepository;
        private readonly Mock<IZivotinjaRepository> mockZivotinjaRepository;
        private readonly Mock<ILijekoviRepository> mockLijekoviRepository;
        private readonly Mock<IVeterinarRepository> mockVeterinarRepository;

        private readonly HomeController controller;
        public HomeControllerTests()
        {

            mockBolestiRepository = new Mock<IBolestiRepository>();
            mockVlasnikRepository = new Mock<IVlasnikRepository>();
            mockLijekoviRepository = new Mock<ILijekoviRepository>();
            mockZivotinjaRepository = new Mock<IZivotinjaRepository>();
            mockVeterinarRepository = new Mock<IVeterinarRepository>();

            //mockBolestiRepository.Setup(x => x.DohvatiSve()).Returns(stubList);
            var cp = new Mock<ClaimsPrincipal>();
            cp.Setup(m => m.FindFirst(ClaimTypes.NameIdentifier)).Returns(new Claim(ClaimTypes.NameIdentifier, "1"));
            

            controller = new HomeController(mockVlasnikRepository.Object, mockZivotinjaRepository.Object, mockBolestiRepository.Object, mockLijekoviRepository.Object, mockVeterinarRepository.Object);
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            controller.ControllerContext.HttpContext.User = cp.Object;
        }
        [Fact]
        public void HomeController_Index_TrebaNapunitiListu()
        {
            var lista = new List<Zivotinja>() { new Zivotinja() { Id = 1, Ime = "Jura" } };
            mockVlasnikRepository.Setup(x => x.DohvatiVlasnikaSaZivotinjom(1)).Returns( lista);
            var result = controller.Index() as ViewResult;
            var model = (IndexViewModel)result.ViewData.Model;
            Assert.Equal<IList<Zivotinja>>(model.Zivotinje, lista);
        }
        [Fact]
        public void HomeController_NovaZivotinja_InvalidniModel()
        {
            var model = new RegistracijaZivotinjeViewModel()
            {
                DatumRodenja = null,
                Ime = null,
                Napomena = "Napomena"
            };
            controller.ModelState.AddModelError("Ime", "Invalid");
            var result = controller.NovaZivotinja(model) as ViewResult;
            Assert.Equal(model, result.Model);
        }
        [Fact]
        public void HomeController_NovaZivotinja_validniModel()
        {
            var model = new RegistracijaZivotinjeViewModel()
            {
                DatumRodenja = null,
                Ime = "Jurica",
                Napomena = "Napomena"
            };
            var result = controller.NovaZivotinja(model) ;

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
        [Fact]
        public void HomeController_Zivotinja_Nepostojeca()
        {
            mockZivotinjaRepository.Setup(x => x.DohvatiPrekoID(2)).Returns((Zivotinja)null);
            var result = controller.Zivotinja(2);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Nema", redirectToActionResult.ActionName);
        }
        [Fact]
        public void HomeController_Zivotinja_NijeVlasnikova()
        {
            var zivotinja = new Zivotinja { Id = 1, Ime = "Jurica" };
            mockZivotinjaRepository.Setup(x => x.DohvatiPrekoID(2)).Returns(zivotinja);
            mockVlasnikRepository.Setup(x => x.DohvatiVlasnikaSaZivotinjom(1)).Returns(new List<Zivotinja>());

            var result = controller.Zivotinja(2);
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Zabranjeno", redirectToActionResult.ActionName);
        }
        [Fact]
        public void HomeController_Zivotinja_Prolazi()
        {
            var zivotinja = new Zivotinja { Id = 1, Ime = "Jurica" };
            mockZivotinjaRepository.Setup(x => x.DohvatiPrekoID(2)).Returns(zivotinja);
            mockVlasnikRepository.Setup(x => x.DohvatiVlasnikaSaZivotinjom(1)).Returns(new List<Zivotinja>() { zivotinja});

            var result = controller.Zivotinja(2);
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(zivotinja, viewResult.Model);
        }
    }
}
