using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VVBData.Models;

namespace VVBData.Repositories
{
    public interface IVideoRepository
    {
        Klant GetKlant(string naam, string postcode);
        IEnumerable<Genre> GetGenres();
        IEnumerable<Film> GetFilms(int id);
        Film GetFilm(int id);

        void UpdateVoorraad(int filmId);
        void AddVerhuring(Verhuring verhuring);
    }
}
