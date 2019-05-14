using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrafischeKaartenGIP.Business;
using MySql.Data.MySqlClient;

namespace GrafischeKaartenGIP.Persistence
{
    public class PersistenceCode
    {
        string ConnSTR = "server=localhost;user id=root;database=dbgrafischekaarten;password=Test123";

        /// <summary>
        /// Haal een lijst op met alle artikelen.
        /// </summary>
        /// <returns></returns>
        public List<Artikel> HaalArtikelenOp()
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "select * from tblartikelen";
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            MySqlDataReader DTR = CMD.ExecuteReader();
            List<Artikel> Lijst = new List<Artikel>();
            while(DTR.Read())
            {
                Artikel _Artikel = new Artikel();
                _Artikel.ArtikelNR = Convert.ToInt32(DTR["artikelnr"]);
                _Artikel.Naam = Convert.ToString(DTR["naam"]);
                _Artikel.Voorraad = Convert.ToInt32(DTR["voorraad"]);
                _Artikel.Prijs = Convert.ToDouble(DTR["prijs"]);
                _Artikel.Foto = Convert.ToString(DTR["foto"]);
                Lijst.Add(_Artikel);
            }
            Conn.Close();
            return Lijst;
        }

        /// <summary>
        /// Voeg een artikel toe aan het winkelmandje.
        /// </summary>
        /// <param name="aantal"></param>
        /// <param name="Artikelnr"></param>
        /// <param name="Klantnr"></param>
        public void VoegToeAanWinkelmanje(int aantal, int Artikelnr, int Klantnr)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "insert into tblwinkelmanden (klantnr, artikelnr, aantal) values (" + Klantnr + ", " + Artikelnr + ", " + aantal + ")";
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            CMD.ExecuteNonQuery();
            Conn.Close();
        }

        /// <summary>
        /// Pas voorraad aan in tblartikelen als er een artikel wordt toegevoegd aan het winkelmandje.
        /// </summary>
        /// <param name="aantal"></param>
        /// <param name="Artikelnr"></param>
        public void PasVoorraadAanBijToevoegen(int aantal, int Artikelnr)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "update tblartikelen set voorraad = voorraad-" + aantal + " where artikelnr = " + Artikelnr;
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            CMD.ExecuteNonQuery();
            Conn.Close();
        }

        /// <summary>
        /// Controleren of er nog genoeg voorraad is van een bepaald artikel.
        /// </summary>
        /// <param name="Artikelnr"></param>
        /// <param name="aantal"></param>
        /// <returns></returns>
        public bool ControleerVoorraad(int Artikelnr, int aantal)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "select voorraad from tblartikelen where (artikelnr =" + Artikelnr + ")and voorraad >= " + aantal;
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            MySqlDataReader DTR = CMD.ExecuteReader();
            bool Uitvoer = false;
            if (DTR.HasRows)
            {
                Uitvoer = true;
            }
            Conn.Close();
            return Uitvoer;
        }

        /// <summary>
        /// Haal één artikel op op basis van het artikelnummer.
        /// </summary>
        /// <param name="Artikelnr"></param>
        /// <returns></returns>
        public Artikel HaalArtikelOp(int Artikelnr)
        {
            Artikel _Artikel = new Artikel();
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "select * from tblartikelen where artikelnr = " + Artikelnr;
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            MySqlDataReader DTR = CMD.ExecuteReader();
            while (DTR.Read())
            {
                _Artikel.ArtikelNR = Convert.ToInt32(DTR["artikelnr"]);
                _Artikel.Naam = Convert.ToString(DTR["naam"]);
                _Artikel.Prijs = Convert.ToDouble(DTR["prijs"]);
                _Artikel.Voorraad = Convert.ToInt32(DTR["voorraad"]);
                _Artikel.Foto = Convert.ToString(DTR["foto"]);
            }
            Conn.Close();
            return _Artikel;            
        }

        /// <summary>
        /// Controleer of een artikel al in de winkelmand zit.
        /// </summary>
        /// <param name="Artikelnr"></param>
        /// <param name="Klantnr"></param>
        /// <returns></returns>
        public bool ControleerArtikelWinkelmand(int Artikelnr,int Klantnr)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "select * from tblwinkelmanden where (artikelnr = " + Artikelnr +") and klantnr = " + Klantnr;
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            MySqlDataReader DTR = CMD.ExecuteReader();
            bool Uitvoer=false;
            if (DTR.HasRows)
            {
                Uitvoer = true;
            }
            Conn.Close();
            return Uitvoer;
        }

        /// <summary>
        /// Controleer of een klant al een winkelmand heeft.
        /// </summary>
        /// <param name="Klantnr"></param>
        /// <returns></returns>
        public bool ControleerBestaanWinkelmand(int Klantnr)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "select * from tblwinkelmanden where klantnr = " + Klantnr;
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            MySqlDataReader DTR = CMD.ExecuteReader();
            bool Uitvoer = false;
            if (DTR.HasRows)
            {
                Uitvoer = true;
            }
            Conn.Close();
            return Uitvoer;
        }

        /// <summary>
        /// Haal een lijst met de inhoud van de winkelmand.
        /// </summary>
        /// <param name="Klantnr"></param>
        /// <returns></returns>
        public List<Winkelmand> HaalWinkelmandOp(int Klantnr)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "select foto,tblwinkelmanden.artikelnr,naam,aantal,prijs,(aantal * prijs) as totaal from tblartikelen inner join tblwinkelmanden on tblartikelen.artikelnr = tblwinkelmanden.artikelnr where tblwinkelmanden.klantnr = " + Klantnr;
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            MySqlDataReader DTR = CMD.ExecuteReader();
            List<Winkelmand> Lijst = new List<Winkelmand>();
            while (DTR.Read())
            {
                Winkelmand _Winkelmand = new Winkelmand();
                _Winkelmand.Foto = Convert.ToString(DTR["foto"]);
                _Winkelmand.ArtikelNr = Convert.ToInt32(DTR["artikelnr"]);
                _Winkelmand.Naam = Convert.ToString(DTR["naam"]);
                _Winkelmand.Aantal = Convert.ToInt32(DTR["aantal"]);
                _Winkelmand.Prijs = Convert.ToDouble(DTR["prijs"]);
                _Winkelmand.Totaal = Convert.ToDouble(DTR["totaal"]);
                Lijst.Add(_Winkelmand);
            }
            Conn.Close();
            return Lijst;
        }
        
        /// <summary>
        /// Haal de gegevens van een bepaalde klant op.
        /// </summary>
        /// <param name="KlantNr"></param>
        /// <returns></returns>
        public Klant HaalKlantOp(int KlantNr)
        {
            Klant _Klant = new Klant();
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "select klantnr,naam,voornaam,adres,postcode,gemeente from tblklanten where klantnr = " + KlantNr;
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            MySqlDataReader DTR = CMD.ExecuteReader();
            while (DTR.Read())
            {
                _Klant.KlantNr = Convert.ToInt32(DTR["klantnr"]);
                _Klant.Naam = Convert.ToString(DTR["naam"]);
                _Klant.Voornaam = Convert.ToString(DTR["voornaam"]);
                _Klant.Adres = Convert.ToString(DTR["adres"]);
                _Klant.Postcode = Convert.ToString(DTR["postcode"]);
                _Klant.gemeente = Convert.ToString(DTR["gemeente"]);
            }
            Conn.Close();
            return _Klant;
        }

        /// <summary>
        /// Bereken en haal de totaalprijs op van de artikelen binnen een winkelmand.
        /// </summary>
        /// <param name="KlantNr"></param>
        /// <returns></returns>
        public Bedragen HaalTotalenOp(int KlantNr)
        {
            Bedragen _Bedragen = new Bedragen();
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "select sum(aantal*prijs) as totaalexcl, (sum(aantal*prijs) * 0.21) as btw, ((sum(aantal*prijs) * 0.21)+sum(aantal*prijs)) as totaalincl from tblartikelen inner join tblwinkelmanden on tblartikelen.artikelnr = tblwinkelmanden.artikelnr where tblwinkelmanden.klantnr = " + KlantNr;
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            MySqlDataReader DTR = CMD.ExecuteReader();
            while (DTR.Read())
            {
                _Bedragen.TotaalExcl = Convert.ToDouble(DTR["totaalexcl"]);
                _Bedragen.TotaalIncl = Convert.ToDouble(DTR["totaalincl"]);
                _Bedragen.BTW = Convert.ToDouble(DTR["btw"]);
            }
            Conn.Close();
            return _Bedragen;
        }

        /// <summary>
        /// Verwijder een artikel uit de winkelmand.
        /// </summary>
        /// <param name="KlantNr"></param>
        /// <param name="ArtikelNr"></param>
        public void ProductUitWinkelmandVerwijderen(int KlantNr, int ArtikelNr)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "delete from tblwinkelmanden where klantnr = " + KlantNr + " and artikelnr = " + ArtikelNr;
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            CMD.ExecuteNonQuery();
            Conn.Close();
        }

        /// <summary>
        /// Pas de voorraad aan bij het verwijderen van een artikel binnen een winkelmand.
        /// </summary>
        /// <param name="KlantNr"></param>
        /// <param name="ArtikelNr"></param>
        public void PasVoorraadAanBijVerwijderen(int KlantNr, int ArtikelNr)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "update tblartikelen set voorraad = (voorraad + (select aantal from tblwinkelmanden where klantnr =" +  KlantNr + " and artikelnr = " + ArtikelNr + ")) where artikelnr = " + ArtikelNr;
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            CMD.ExecuteNonQuery();
            Conn.Close();
        }

        /// <summary>
        /// Maak een lijn met gegevens aan binnen tblbestellingen.
        /// </summary>
        /// <param name="KlantNr"></param>
        public void MaakBestellingAan(int KlantNr)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "insert into tblbestellingen (orderdatum, klantnr) values (now(), " + KlantNr + ")";
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            CMD.ExecuteNonQuery();
            Conn.Close();
        }

        /// <summary>
        /// Haal laatste ordernummer op van een klant.
        /// </summary>
        /// <param name="KlantNr"></param>
        /// <returns></returns>
        public int HaalLaatsteOrderNrOp(int KlantNr)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "select ordernr from tblbestellingen where klantnr =" + KlantNr + " order by ordernr desc limit 1";
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            MySqlDataReader DTR = CMD.ExecuteReader();
            int Getal = 0;
            while (DTR.Read())
            {
                Getal = Convert.ToInt32(DTR["ordernr"]);
            }
            Conn.Close();
            return Getal;
        }

        /// <summary>
        /// Sla één orderitem op van de winkelmand in tblbestellijnen.
        /// </summary>
        /// <param name="KlantNr"></param>
        /// <param name="ArtikelNr"></param>
        /// <param name="Aantal"></param>
        public void SlaOrderItemOpVanWinkelmand(int KlantNr, int ArtikelNr, int Aantal)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "insert into tblbestellijnen (ordernr, artikelnr, aantal, prijs) values (" + HaalLaatsteOrderNrOp(KlantNr) + ", " + ArtikelNr + ", " + Aantal + ", (select prijs from tblartikelen where artikelnr =" + ArtikelNr +"))";
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            CMD.ExecuteNonQuery();
            Conn.Close();
        }

        /// <summary>
        /// Maak winkelmand leeg van een bepaalde klant.
        /// </summary>
        /// <param name="KlantNr"></param>
        public void MaakWinkelmandLeeg(int KlantNr)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "delete from tblwinkelmanden where klantnr = " + KlantNr;
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            CMD.ExecuteNonQuery();
            Conn.Close();
        }

        /// <summary>
        /// Haal totaalprijs van laatste order op.
        /// </summary>
        /// <param name="KlantNr"></param>
        /// <returns></returns>
        public double HaalOrderPrijsOp(int KlantNr)
        {
            double Uitvoer=0;            
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "select sum(prijs * aantal * 1.21) as prijs from tblbestellijnen where ordernr = " + HaalLaatsteOrderNrOp(KlantNr);
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            MySqlDataReader DTR = CMD.ExecuteReader();
            while (DTR.Read())
            {
                Uitvoer = Convert.ToDouble(DTR["prijs"]);
            }
            Conn.Close();
            return Uitvoer;
        }

        /// <summary>
        /// Haal de gegevens voor het maken van een mail op.
        /// </summary>
        /// <param name="KlantNr"></param>
        /// <returns></returns>
        public Klant HaalMailGegevensOp(int KlantNr)
        {
            Klant _Klant = new Klant();
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "select naam, voornaam, mail from tblklanten where klantnr = " + KlantNr;
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            MySqlDataReader DTR = CMD.ExecuteReader();
            while (DTR.Read())
            {
                _Klant.Naam = Convert.ToString(DTR["naam"]);
                _Klant.Voornaam = Convert.ToString(DTR["voornaam"]);
                _Klant.Mail = Convert.ToString(DTR["mail"]);
            }
            Conn.Close();
            return _Klant;
        }

        /// <summary>
        /// Controleer of de logingegevens kloppen en stuur het klantnummer terug.
        /// </summary>
        /// <param name="_Klant"></param>
        /// <returns></returns>
        public int ControleerLoginEnStuurKlantNrTerug(Klant _Klant)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "select klantnr from tblklanten where gebruikersnaam='" + _Klant.Gebruikersnaam + "' and binary wachtwoord ='" + _Klant.Wachtwoord + "'";
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            MySqlDataReader DTR = CMD.ExecuteReader();
            int Uitvoer = 0;
            while (DTR.Read())
            {
                Uitvoer = Convert.ToInt32(DTR["klantnr"]);
            }
            Conn.Close();
            return Uitvoer;
        }
    }
}