using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrafischeKaartenGIP.Business;

namespace GrafischeKaartenGIP
{
    public partial class Winkelmandje : System.Web.UI.Page
    {
        Controller _Controller = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblKlantnummer.Text = _Controller.HaalKlantOp(1).KlantNr.ToString();
            lblNaam.Text = _Controller.HaalKlantOp(1).Naam + " " + _Controller.HaalKlantOp(1).Voornaam;
            lblAdres.Text = _Controller.HaalKlantOp(1).Adres;
            lblGemeente.Text = _Controller.HaalKlantOp(1).Postcode + " " + _Controller.HaalKlantOp(1).gemeente;
            lblBesteldatum.Text = Convert.ToString(DateTime.Now.ToLongDateString());

            gvArtikelen.DataSource = _Controller.HaalWinkelmandOp(1);
            gvArtikelen.DataBind();

            lblTotaalIncl.Text = _Controller.HaalTotalenOp(1).TotaalIncl.ToString();
            lblTotaalExcl.Text = _Controller.HaalTotalenOp(1).TotaalExcl.ToString();
            lblBTW.Text = _Controller.HaalTotalenOp(1).BTW.ToString();
        }

        protected void gvArtikelen_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Controller.ProductUitWinkelmandVerwijderenEnPasAan(1, Convert.ToInt32(gvArtikelen.SelectedRow.Cells[2].Text));
            if (_Controller.ControleerBestaanWinkelmand(1))
            {
                Response.Redirect("Winkelmandje.aspx");
            }
            else
            {
                Response.Redirect("WinkelmandjeLeeg.aspx");
            }
        }

        protected void btnCatalogus_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}