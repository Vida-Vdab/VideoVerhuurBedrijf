using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVBData.Models;

namespace VVBData.Repositories
{
    public class SQLVideoRepository : IVideoRepository
    {
        private VVBDbContext context;
        public SQLVideoRepository(VVBDbContext context)
        {
            this.context = context;
        }

        public void AddVerhuring(Verhuring verhuring)
        {
            context.Verhuringen.Add(verhuring);
            context.SaveChanges();
        }

        public Film GetFilm(int id)
        {
            return context.Films.Find(id);
        }

        public IEnumerable<Film> GetFilms(int id)
        {
            return context.Films.Include("Genre").Where(r => r.GenreId == id).ToList();
        }

        public IEnumerable<Genre> GetGenres()
        {
            return context.Genres;
        }

        public Klant GetKlant(string naam, string postcode)
        {
            return context.Klanten.Where(r => r.Naam == naam && r.PostCode == postcode).FirstOrDefault();
        }

        public void UpdateVoorraad(int filmId)
        {
            Film film = GetFilm(filmId);
            film.InVoorraad -= 1;
            film.UitVoorraad += 1;
            context.SaveChanges();
        }
    }
}
