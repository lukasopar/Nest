﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DatabaseBootstrap.IRepositories;
using DatabaseBootstrap.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nest.Model.Domain;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly IVlasnikRepository _repository;
        private readonly IZivotinjaRepository _repositoryZivotinja;
        private readonly IBolestiRepository _repositoryBolest;
        private readonly ILijekoviRepository _repositroyLijekovi;
        private readonly IVeterinarRepository _repositoryVeterinar;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;

            _repository = unitOfWork.VlasnikRepository;
            _repositoryZivotinja = unitOfWork.ZivotinjaRepository;
            _repositoryBolest = unitOfWork.BolestiRepository;
            _repositoryVeterinar = unitOfWork.VeterinarRepository;
            _repositroyLijekovi = unitOfWork.LijekoviRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            
            var userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var zivotinje = _repository.DohvatiVlasnikaSaZivotinjom(userId);
            //var user = _repository.DohvatiPrekoID(Int32.Parse(userId));
            var model = new IndexViewModel() { Zivotinje = zivotinje };
            return View(model);
        }
        [HttpGet]
        public IActionResult NovaZivotinja()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NovaZivotinja(RegistracijaZivotinjeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var vlasnik = _repository.DohvatiPrekoID(userId);
                Zivotinja zivotinja = new Zivotinja()
                {
                    Ime = model.Ime,
                    Napomena = model.Napomena,
                    Vlasnik = vlasnik
                };
                if (model.DatumRodenja != null)
                    zivotinja.DatumRod = DateTime.Parse(model.DatumRodenja);

                _repositoryZivotinja.Stvori(zivotinja);

               
                return RedirectToAction("Index", "Home");

            }
            else
                return View(model);
        }

        [HttpGet]
        [Route("Zivotinja/{id}")]
        public IActionResult Zivotinja(int id)
        {
            var zivotinja = _repositoryZivotinja.DohvatiPrekoID(id);
            if (zivotinja == null)
                return RedirectToAction("Nema");
            var userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var zivotinje = _repository.DohvatiVlasnikaSaZivotinjom(userId);
            if (!zivotinje.Contains(zivotinja))
                return RedirectToAction("Zabranjeno");

            zivotinja.Postupaks = _repositoryZivotinja.DohvatiZivotinjaPostupke(id);
            return View(zivotinja);
        }
        [HttpGet]
        [Route("Bolest/{id}")]
        public IActionResult Bolest(int id)
        {
            var bolest = _repositoryBolest.DohvatiPrekoIDSLijekovima(id);
            if (bolest == null)
                return RedirectToAction("Nema");
            return View(bolest);
        }
        [HttpGet]
        [Route("Lijek/{id}")]
        public IActionResult Lijek(int id)
        {
            var lijek = _repositroyLijekovi.DohvatiLijekPoId(id);
            if (lijek == null)
                return RedirectToAction("Nema");
            return View(lijek);
        }
        [HttpGet]
        [Route("Veterinar/{id}")]
        public IActionResult Veterinar(int id)
        {
            var veterinar = _repositoryVeterinar.DohvatiPrekoID(id);
            if (veterinar == null)
                return RedirectToAction("Nema");
            veterinar.VrstaZivotinjes = _repositoryVeterinar.DohvatiSveVrsteVeterinar(id);
            veterinar.VrstaPostupkas = _repositoryVeterinar.DohvatiSvePostupke(id);
            veterinar.LijekKodVeterinaras = _repositoryVeterinar.DohvatiSveLijekoveKodVeterinara(id);
            return View(veterinar);
        }
        [HttpGet]
        public IActionResult Nema()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Zabranjeno()
        {
            return View();
        }
    }
}
