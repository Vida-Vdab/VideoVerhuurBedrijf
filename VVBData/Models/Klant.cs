using System;
using System.Collections.Generic;
using System.Text;

namespace VVBData.Models
{
    public class Klant
    { 
        public int KlantId { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Straat_Nr { get; set; }
        public string PostCode { get; set; }
        public string Gemeente { get; set; }
        public string KlantStat { get; set; }
        public int HuurAantal { get; set; }
        public DateTime DatumLid { get; set; }
        public bool Lidgeld { get; set; }
        public IEnumerable<Verhuring> Verhuringen { get; set; }
    }
}
