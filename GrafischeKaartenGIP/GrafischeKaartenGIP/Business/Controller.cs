using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrafischeKaartenGIP.Persistence;

namespace GrafischeKaartenGIP.Business
{
    public class Controller
    {
        PersistenceCode _PersistenceCode = new PersistenceCode();

        public List<Artikel> HaalArtikelenOp()
        {
            return _PersistenceCode.HaalArtikelenOp();
        }

        public void VoegToeEnPasAan(int aantal, int Klantnr, int Artikelnr)
        {
            _PersistenceCode.VoegToeAanWinkelmanje(aantal, Artikelnr, Klantnr);
            _PersistenceCode.PasVoorraadAan(aantal, Artikelnr);
        }

        public bool ControleerVoorraad(int aantal, int Artikelnr)
        {
            return _PersistenceCode.ControleerVoorraad(Artikelnr, aantal);
        }

        public Artikel HaalArtikelOp(int Artikelnr)
        {
            return _PersistenceCode.HaalArtikelOp(Artikelnr);
        }

        public bool ControleerWinkelmand(int Artikelnr, int Klantnr)
        {
            return _PersistenceCode.ControleerWinkelmand(Artikelnr, Klantnr);
        }
    }
}