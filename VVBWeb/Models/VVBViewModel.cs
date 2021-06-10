using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VVBData.Models;

namespace VVBWeb.Models
{
    public class VVBViewModel
    {
        public Klant Klant { get; set; }
        public IEnumerable<Film> Films { get; set; }
        public List<Verhuring> Verhuringen { get; set; } = new List<Verhuring>();
        public IEnumerable<Genre> Genres { get; set; }
        public Film GehuurdeFilm { get; set; }

    }
}
