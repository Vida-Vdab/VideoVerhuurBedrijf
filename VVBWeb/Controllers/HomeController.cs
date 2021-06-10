using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VVBData.Models;
using VVBData.Repositories;
using VVBWeb.Models;

namespace VVBWeb.Controllers
{
    public class HomeController : Controller
    {
        private IVideoRepository videoRepository;
        private static VVBViewModel model = new VVBViewModel();

        public HomeController(IVideoRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("klant") != null && HttpContext.Session.GetString("klant") == "onbekend")
            {
                ViewBag.ErrorMessage = "Onbekende klant, probeer opnieuw.";
            }
            return View();
        }

        [HttpPost]
        public IActionResult Aanmelden(Klant k)
        {

            if (this.ModelState.IsValid)
            {
                var klant = videoRepository.GetKlant(k.Naam, k.PostCode);
                if (klant == null)
                {
                    HttpContext.Session.SetString("klant", "onbekend");
                    return RedirectToAction("Index");
                }
                else
                {
                    HttpContext.Session.SetString("Voornaam", klant.Voornaam);
                    HttpContext.Session.SetString("Naam", klant.Naam);
                    model.Klant = klant;
                    return RedirectToAction("GetAllGenres");
                }

            }
            else
                return RedirectToAction("Index");
        }

        public IActionResult GetAllGenres()
        {
            model.Genres = videoRepository.GetGenres();
            return View(videoRepository.GetGenres());
        }

        public IActionResult FindFilmsByGenre(Genre genre)
        {
            model.Films = videoRepository.GetFilms(genre.GenreId);
            ViewBag.Naam = genre.GenreNaam;
            return View(model);
           
        }

        public IActionResult ToevoegenFilmNaarMandje(Film film)
        {
            Verhuring verhuring = new Verhuring();
            verhuring.Film = film;
            verhuring.FilmId = film.FilmId;
            verhuring.Klant = model.Klant;
            verhuring.KlantId = model.Klant.KlantId;
            model.Verhuringen.Add(verhuring);
          
            return RedirectToAction("Winkelmandje");
        }

        public IActionResult Winkelmandje()
        {
            return View(model);
        }

        public IActionResult VerwijderenFilmUitMandje(Film film)
        {
            model.GehuurdeFilm = film;
            return View(model);
        }

        public IActionResult BevestigenVanVerwijder()
        {
            int FilmId = model.GehuurdeFilm.FilmId;
            int KlantId = model.Klant.KlantId;
            Verhuring verhuring = model.Verhuringen.Where(i => i.KlantId == KlantId && i.FilmId == FilmId).FirstOrDefault();
            model.Verhuringen.Remove(verhuring);
            return RedirectToAction("Winkelmandje");

        }

        public IActionResult Afrekenen()
        {
            foreach (var verhuring in model.Verhuringen)
            {

                Verhuring verhuringen = new Verhuring();
              
                verhuringen.FilmId = verhuring.FilmId;
                
                verhuringen.KlantId = verhuring.KlantId;

                verhuringen.VerhuurDatum = DateTime.Now;

                videoRepository.AddVerhuring(verhuringen);
                videoRepository.UpdateVoorraad(verhuring.FilmId);
            }

            ViewBag.TotaalPrijs = model.Verhuringen.Sum(r => r.Film.Prijs);
            return View(model);
        }

        public IActionResult ClearModelEnSession()
        {
            model = new VVBViewModel();
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
