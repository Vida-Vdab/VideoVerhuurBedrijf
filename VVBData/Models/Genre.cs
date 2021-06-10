using System;
using System.Collections.Generic;
using System.Text;

namespace VVBData.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string GenreNaam { get; set; }
        public IEnumerable<Film> Films { get; set; }
    }
}
