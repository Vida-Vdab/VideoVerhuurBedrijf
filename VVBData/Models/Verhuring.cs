using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VVBData.Models
{
    public class Verhuring
    {
        [Key]
        public int VerhuurId { get; set; }
        public int KlantId { get; set; }
        public int FilmId { get; set; }
        public DateTime VerhuurDatum { get; set; }
        public Klant Klant { get; set; }
        public Film Film { get; set; }
    }
}
