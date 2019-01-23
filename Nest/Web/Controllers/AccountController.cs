using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DatabaseBootstrap.IRepositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nest.Model.Domain;
using Web.Models;

namespace Web.Controllers
{
    public class AccountController : Controller
    {
        IVlasnikRepository _repository;
        public AccountController(IVlasnikRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Password()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            //return (new EmptyResult());
            if (ModelState.IsValid)
            {
                // dohvati usera
                var user = _repository.DohvatiVlasnikaPrijava(model.KorisnickoIme, model.Password);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id+""),
                        new Claim(ClaimTypes.Name, user.Ime + " " + user.Prezime)
                    };
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                     var authProperties = new AuthenticationProperties
                        {
                        AllowRefresh = true,
                        // Refreshing the authentication session should be allowed.

                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. Required when setting the 
                        // ExpireTimeSpan option of CookieAuthenticationOptions 
                        // set with AddCookie. Also required when setting 
                        // ExpiresUtc.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = returnUrl
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };
                     await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(userIdentity),
                            authProperties);
                    return RedirectToAction("Index", "Home");
               // return ;
                }
                else
                {
                    TempData["NeuspjeliLogin"] = "Niste se uspjeli prijaviti. Pokušajte ponovno.";
                    
                    return View(model);
                }
            }
            else
                return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistracijaVlasnikaViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!model.Lozinka.Equals(model.PonovljenaLozinka))
                {
                    ModelState.AddModelError("Lozinka", "Lozinke nisu iste");
                    return View(model);
                }
                if(_repository.DohvatiVlasnikaKorisnickoIme(model.KorisnickoIme) != null)
                {
                    ModelState.AddModelError("KorisnickoIme", "Korisnik s ovim korisničkim imenom već postoji.");
                    return View(model);
                }
                Vlasnik vlasnik = new Vlasnik()
                {
                    Ime = model.Ime,
                    KorisnickoIme = model.KorisnickoIme,
                    Prezime = model.Prezime,
                    Lozinka = model.Lozinka,
                    DatumRod = DateTime.Parse(model.DatumRodenja)
                };
                _repository.Stvori(vlasnik);

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, vlasnik.Id+""),
                        new Claim(ClaimTypes.Name, vlasnik.Ime + " " + vlasnik.Prezime)
                    };
                ClaimsIdentity userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                
                    IsPersistent = true,
                    
                };
                await HttpContext.SignInAsync(
                       CookieAuthenticationDefaults.AuthenticationScheme,
                       new ClaimsPrincipal(userIdentity),
                       authProperties);
                return RedirectToAction("Index", "Home");

            }
            else
                return View(model);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Password(PasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var id = Int32.Parse( User.FindFirst(ClaimTypes.NameIdentifier).Value);

                var user = _repository.DohvatiPrekoID(id);

                if (!user.Lozinka.Equals(model.StaraLoz))
                {
                    ModelState.AddModelError("StaraLoz", "Pogrešna lozinka.");
                    return View(model);
                }
                if (!model.NovaLoz.Equals(model.NovaLozPon))
                {
                    ModelState.AddModelError("NovaLoz", "Lozinke nisu iste.");
                    return View(model);
                }
                user.Lozinka = model.NovaLoz;
                _repository.Azuriraj(user);
               
                return RedirectToAction("Index", "Home");

            }
            else
                return View(model);
        }
    }

    
}
