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

        public Bedragen HaalTotalenOp(int KlantNr)
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
            _PersistenceCode.MaakBestellingAan(KlantNr);
            List<Winkelmand> lijst = _PersistenceCode.HaalWinkelmandOp(KlantNr);
            int Aantal = 0;
            int ArtikelNr = 0;
            
            for (int i = 0; i < lijst.Count(); i++)
            {
                Aantal = lijst[i].Aantal;
                ArtikelNr = lijst[i].ArtikelNr;
                _PersistenceCode.SlaOrderItemOpVanWinkelmand(KlantNr, ArtikelNr, Aantal);
            }
            _PersistenceCode.MaakWinkelmandLeeg(KlantNr);
        }

        public double HaalOrderPrijsOp(int KlantNr)
        {
            return _PersistenceCode.HaalOrderPrijsOp(KlantNr);
        }

        public void StuurMail(int KlantNr)
        {
            MailSender _MailSender = new MailSender();
            _MailSender.Naam = _PersistenceCode.HaalMailGegevensOp(KlantNr).Voornaam + " " + _PersistenceCode.HaalMailGegevensOp(KlantNr).Naam;
            _MailSender.Mail = _PersistenceCode.HaalMailGegevensOp(KlantNr).Mail;
            _MailSender.Onderwerp = "Bestelbevestiging ordernr: " + _PersistenceCode.HaalLaatsteOrderNrOp(KlantNr);
            _MailSender.Boodschap = "Uw bestelling met ordernr " + _PersistenceCode.HaalLaatsteOrderNrOp(KlantNr) + " werd goed door ons ontvangen." + Environment.NewLine + "Na betaling van " + string.Format("{0:c}",_PersistenceCode.HaalOrderPrijsOp(KlantNr)) +  " op rekeningnummer BE36 1030 5325 4381 zullen wij overgaan tot verzending van de grafische kaarten." + Environment.NewLine + "Gelieve het ordernummer als betalingsreferentie mee te geven." + Environment.NewLine + "Bedant voor uw vertrouwen!";
            _MailSender.StuurMail();
        }

        public int ControleerLoginEnStuurKlantNrTerug(string Gebruikersnaam, string Wachtwoord)
        {
            Klant _Klant = new Klant();
            _Klant.Gebruikersnaam = Gebruikersnaam;
            _Klant.Wachtwoord = Wachtwoord;
            return _PersistenceCode.ControleerLoginEnStuurKlantNrTerug(_Klant);
        }

        public int HaalLaatsteOrderNrOp(int KlantNr)
        {
            return _PersistenceCode.HaalLaatsteOrderNrOp(KlantNr);
        }
    }
}