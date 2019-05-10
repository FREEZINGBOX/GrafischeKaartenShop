using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrafischeKaartenGIP.Business
{
    public class Klant
    {
        public int KlantNr { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        public string gemeente { get; set; }
        public string Mail { get; set; }
        public string Wachtwoord { get; set; }
        public string Gebruikersnaam {get; set; }
    }
}