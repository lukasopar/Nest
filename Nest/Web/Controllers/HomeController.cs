using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DatabaseBootstrap.IRepositories;
using DatabaseBootstrap.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        IVlasnikRepository _repository;
        public HomeController(IVlasnikRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            //var userId = User.FindFirst(ClaimTypes.Name).Value;
            //var user = _repository.DohvatiPrekoID(Int32.Parse(userId));
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
