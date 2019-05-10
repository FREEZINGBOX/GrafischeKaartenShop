using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrafischeKaartenGIP.Business;
using System.Globalization;

namespace GrafischeKaartenGIP
{
    public partial class Winkelmandje : System.Web.UI.Page
    {
        Controller _Controller = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblKlantnummer.Text = _Controller.HaalKlantOp(Convert.ToInt32(Context.User.Identity.Name)).KlantNr.ToString();
            lblNaam.Text = _Controller.HaalKlantOp(Convert.ToInt32(Context.User.Identity.Name)).Naam + " " + _Controller.HaalKlantOp(Convert.ToInt32(Context.User.Identity.Name)).Voornaam;
            lblAdres.Text = _Controller.HaalKlantOp(Convert.ToInt32(Context.User.Identity.Name)).Adres;
            lblGemeente.Text = _Controller.HaalKlantOp(Convert.ToInt32(Context.User.Identity.Name)).Postcode + " " + _Controller.HaalKlantOp(Convert.ToInt32(Context.User.Identity.Name)).gemeente;
            lblBesteldatum.Text = Convert.ToString(DateTime.Now.ToLongDateString());

            gvArtikelen.DataSource = _Controller.HaalWinkelmandOp(Convert.ToInt32(Context.User.Identity.Name));
            gvArtikelen.DataBind();

            lblTotaalIncl.Text = string.Format("{0:c}", _Controller.HaalTotalenOp(Convert.ToInt32(Context.User.Identity.Name)).TotaalIncl);
            lblTotaalExcl.Text = string.Format("{0:c}", _Controller.HaalTotalenOp(Convert.ToInt32(Context.User.Identity.Name)).TotaalExcl);
            lblBTW.Text = string.Format("{0:c}", _Controller.HaalTotalenOp(Convert.ToInt32(Context.User.Identity.Name)).BTW);
        }

        protected void gvArtikelen_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Controller.ProductUitWinkelmandVerwijderenEnPasAan(Convert.ToInt32(Context.User.Identity.Name), Convert.ToInt32(gvArtikelen.SelectedRow.Cells[2].Text));
            if (_Controller.ControleerBestaanWinkelmand(Convert.ToInt32(Context.User.Identity.Name)))
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

        protected void btnBestellen_Click(object sender, EventArgs e)
        {
            _Controller.BestelItemsEnVerwijderVanWinkelmand(Convert.ToInt32(Context.User.Identity.Name));
            _Controller.StuurMail(Convert.ToInt32(Context.User.Identity.Name));            
            Response.Redirect("Bestelbevestiging.aspx");
        }
    }
}