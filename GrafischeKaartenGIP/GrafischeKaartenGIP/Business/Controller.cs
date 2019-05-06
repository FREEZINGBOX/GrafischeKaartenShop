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
            _PersistenceCode.PasVoorraadAanBijToevoegen(aantal, Artikelnr);
        }

        public bool ControleerVoorraad(int aantal, int Artikelnr)
        {
            return _PersistenceCode.ControleerVoorraad(Artikelnr, aantal);
        }

        public Artikel HaalArtikelOp(int Artikelnr)
        {
            return _PersistenceCode.HaalArtikelOp(Artikelnr);
        }

        public bool ControleerArtikelWinkelmand(int Artikelnr, int Klantnr)
        {
            return _PersistenceCode.ControleerArtikelWinkelmand(Artikelnr, Klantnr);
        }

        public bool ControleerBestaanWinkelmand(int klantnr)
        {
            return _PersistenceCode.ControleerBestaanWinkelmand(klantnr);
        }

        public List<Winkelmand> HaalWinkelmandOp(int Klantnr)
        {
            return _PersistenceCode.HaalWinkelmandOp(Klantnr);
        }

        public Klant HaalKlantOp(int KlantNr)
        {
            return _PersistenceCode.HaalKlantOp(KlantNr);
        }

        public Winkelmand HaalTotalenOp(int KlantNr)
        {
            return _PersistenceCode.HaalTotalenOp(KlantNr);
        }

        public void ProductUitWinkelmandVerwijderenEnPasAan(int KlantNr, int ArtikelNr)
        {
            _PersistenceCode.PasVoorraadAanBijVerwijderen(KlantNr, ArtikelNr);
            _PersistenceCode.ProductUitWinkelmandVerwijderen(KlantNr, ArtikelNr);
        }

        public void BestelItemsEnVerwijderVanWinkelmand(int KlantNr)
        {
            List<Winkelmand> lijst = _PersistenceCode.HaalWinkelmandOp(KlantNr);
            int Aantal = 0;
            int ArtikelNr = 0;
            
            for (int i = 0; i < lijst.Count(); i++)
            {
                Aantal = lijst[i].Aantal;
                ArtikelNr = lijst[i].ArtikelNr;
                _PersistenceCode.SlaOrderItemOpVanWinkelmand(KlantNr, ArtikelNr, Aantal);
            }
            
        
        }
    }
}