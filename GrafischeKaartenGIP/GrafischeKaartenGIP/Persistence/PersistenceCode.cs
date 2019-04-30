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

        public List<Artikel> HaalArtiekelenOp()
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
    }
}