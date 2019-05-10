using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrafischeKaartenGIP.Business
{
    public class Winkelmand
    {
        public string Foto { get; set; }
        public int ArtikelNr { get; set; }
        public string Naam { get; set; }
        public int Aantal { get; set; }
        public double Prijs { get; set; }
        public double Totaal { get; set; }
    }
}