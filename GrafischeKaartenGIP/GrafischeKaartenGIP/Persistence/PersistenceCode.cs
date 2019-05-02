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

        public void PasVoorraadAan(int aantal, int Artikelnr)
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

        public bool ControleerWinkelmand(int Artikelnr,int Klantnr)
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
    }
}