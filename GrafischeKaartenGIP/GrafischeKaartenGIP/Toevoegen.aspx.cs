using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrafischeKaartenGIP.Business;

namespace GrafischeKaartenGIP
{
    public partial class Toevoegen : System.Web.UI.Page
    {
        Controller _Controller = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            int ArtNr = Convert.ToInt32(Session["ArtNr"]);
            lblArtNr.Text = _Controller.HaalArtikelOp(ArtNr).ArtikelNR.ToString();
            lblNaam.Text = _Controller.HaalArtikelOp(ArtNr).Naam;
            lblVerkoopprijs.Text = "€"+_Controller.HaalArtikelOp(ArtNr).Prijs.ToString();
            lblVoorraad.Text = _Controller.HaalArtikelOp(ArtNr).Voorraad.ToString();
            imgFoto.ImageUrl = "./Images/" + _Controller.HaalArtikelOp(ArtNr).Foto;
            if (_Controller.ControleerArtikelWinkelmand(Convert.ToInt32(Session["ArtNr"]), 1))
            {
                lblFout.Text = "Dit product zit al in het mandje. ALs u het aantal wil wijzigen, verwijder het dan uit het mandje en voeg het correcte toe.";
                lblAantal.Visible = false;
                txtAantal.Visible = false;
                btnVoegToe.Visible = false;
                btnCatalogus.Visible = true;
            }
        }

        protected void btnVoegToe_Click(object sender, EventArgs e)
        {
            if(_Controller.ControleerVoorraad(Convert.ToInt32(txtAantal.Text), Convert.ToInt32(Session["ArtNr"])) == false)
            {
                lblFout.Text = "Ongeldige voorraad!";
            }
           
            else
            {
                _Controller.VoegToeEnPasAan(Convert.ToInt32(txtAantal.Text), 1, Convert.ToInt32(Session["ArtNr"]));
                Response.Redirect("Winkelmandje.aspx");
            }
        }

        protected void btnCatalogus_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}