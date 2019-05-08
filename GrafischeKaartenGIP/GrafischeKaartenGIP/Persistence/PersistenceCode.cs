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

        public void VoegToeAanWinkelmanje(int aantal, int Artikelnr, int Klantnr)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "insert into tblwinkelmanden (klantnr, artikelnr, aantal) values (" + Klantnr + ", " + Artikelnr + ", " + aantal + ")";
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            CMD.ExecuteNonQuery();
            Conn.Close();
        }

        public void PasVoorraadAanBijToevoegen(int aantal, int Artikelnr)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "update tblartikelen set voorraad = voorraad-" + aantal + " where artikelnr = " + Artikelnr;
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            CMD.ExecuteNonQuery();
            Conn.Close();
        }

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

        public Winkelmand HaalTotalenOp(int KlantNr)
        {
            Winkelmand _Winkelmand = new Winkelmand();
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "select sum(aantal*prijs) as totaalexcl, (sum(aantal*prijs) * 0.21) as btw, ((sum(aantal*prijs) * 0.21)+sum(aantal*prijs)) as totaalincl from tblartikelen inner join tblwinkelmanden on tblartikelen.artikelnr = tblwinkelmanden.artikelnr where tblwinkelmanden.klantnr = " + KlantNr;
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            MySqlDataReader DTR = CMD.ExecuteReader();
            while (DTR.Read())
            {
                _Winkelmand.TotaalExcl = Convert.ToDouble(DTR["totaalexcl"]);
                _Winkelmand.TotaalIncl = Convert.ToDouble(DTR["totaalincl"]);
                _Winkelmand.BTW = Convert.ToDouble(DTR["btw"]);
            }
            Conn.Close();
            return _Winkelmand;
        }

        public void ProductUitWinkelmandVerwijderen(int KlantNr, int ArtikelNr)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "delete from tblwinkelmanden where klantnr = " + KlantNr + " and artikelnr = " + ArtikelNr;
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            CMD.ExecuteNonQuery();
            Conn.Close();
        }

        public void PasVoorraadAanBijVerwijderen(int KlantNr, int ArtikelNr)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "update tblartikelen set voorraad = (voorraad + (select aantal from tblwinkelmanden where klantnr =" +  KlantNr + " and artikelnr = " + ArtikelNr + ")) where artikelnr = " + ArtikelNr;
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            CMD.ExecuteNonQuery();
            Conn.Close();
        }

        public void MaakBestellingAan(int KlantNr)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "insert into tblbestellingen (orderdatum, klantnr) values (now(), " + KlantNr + ")";
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            CMD.ExecuteNonQuery();
            Conn.Close();
        }

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

        public void SlaOrderItemOpVanWinkelmand(int KlantNr, int ArtikelNr, int Aantal)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "insert into tblbestellijnen (ordernr, artikelnr, aantal, prijs) values (" + HaalLaatsteOrderNrOp(KlantNr) + ", " + ArtikelNr + ", " + Aantal + ", (select prijs from tblartikelen where artikelnr =" + ArtikelNr +"))";
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            CMD.ExecuteNonQuery();
            Conn.Close();
        }

        public void MaakWinkelmandLeeg(int KlantNr)
        {
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "delete from tblwinkelmanden where klantnr = " + KlantNr;
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            CMD.ExecuteNonQuery();
            Conn.Close();
        }

        public Order HaalOrderOp(int KlantNr)
        {
            Order _Order = new Order();
            _Order.OrderNr = HaalLaatsteOrderNrOp(KlantNr);
            MySqlConnection Conn = new MySqlConnection(ConnSTR);
            Conn.Open();
            string QRY = "select sum(prijs * aantal * 1.21) as prijs from tblbestellijnen where ordernr = " + HaalLaatsteOrderNrOp(KlantNr);
            MySqlCommand CMD = new MySqlCommand(QRY, Conn);
            MySqlDataReader DTR = CMD.ExecuteReader();
            while (DTR.Read())
            {
                _Order.Prijs = Convert.ToDouble(DTR["prijs"]);
            }
            Conn.Close();
            return _Order;
        }

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
    }
}