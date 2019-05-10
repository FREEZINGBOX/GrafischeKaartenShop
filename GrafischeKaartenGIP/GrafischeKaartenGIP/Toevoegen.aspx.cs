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
            lblVerkoopprijs.Text = string.Format("{0:c}",_Controller.HaalArtikelOp(ArtNr).Prijs);
            lblVoorraad.Text = _Controller.HaalArtikelOp(ArtNr).Voorraad.ToString();
            imgFoto.ImageUrl = "./Images/" + _Controller.HaalArtikelOp(ArtNr).Foto;
            if (_Controller.ControleerArtikelWinkelmand(Convert.ToInt32(Session["ArtNr"]), Convert.ToInt32(Context.User.Identity.Name)))
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
            if (double.TryParse(txtAantal.Text,out double TestAantal))
            {
                if (int.TryParse(txtAantal.Text,out int Aantal))
                {
                    if (Aantal < 1)
                    {
                        lblFout.Text = "Geef een positief getal boven 0 in.";
                    }
                    else
                    {
                        if (_Controller.ControleerVoorraad(Convert.ToInt32(txtAantal.Text), Convert.ToInt32(Session["ArtNr"])) == false)
                        {
                            lblFout.Text = "Ongeldige voorraad!";
                        }

                        else
                        {
                            _Controller.VoegToeEnPasAan(Convert.ToInt32(txtAantal.Text), Convert.ToInt32(Context.User.Identity.Name), Convert.ToInt32(Session["ArtNr"]));
                            Response.Redirect("Winkelmandje.aspx");
                        }
                    }
                }
                else
                {
                    lblFout.Text = "Geef een geheel getal in.";
                }
            }
            else
            {
                lblFout.Text = "Geef een geldig getal in.";
            }
        }

        protected void btnCatalogus_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}