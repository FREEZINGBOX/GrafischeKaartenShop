using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrafischeKaartenGIP.Business;

namespace GrafischeKaartenGIP
{
    public partial class _default : System.Web.UI.Page
    {
        Controller _Controller = new Controller();

        protected void Page_Load(object sender, EventArgs e)
        {
            gvArtikelen.DataSource = _Controller.HaalArtikelenOp();
            gvArtikelen.DataBind();
            for (int i = 0; i < gvArtikelen.Rows.Count; i++)
            {
                if (Convert.ToInt32(gvArtikelen.Rows[i].Cells[4].Text) == 0)
                {
                    gvArtikelen.Rows[i].Cells[5].Text = "Niet op voorraad";
                }
            }
        }

        protected void gvArtikelen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ArtNr"] = gvArtikelen.SelectedRow.Cells[0].Text;
            Response.Redirect("Toevoegen.aspx");
            
        }

        protected void btnGaWinkelmand_Click(object sender, EventArgs e)
        {
            if (_Controller.ControleerBestaanWinkelmand(Convert.ToInt32(Context.User.Identity.Name)))
            {
                Response.Redirect("Winkelmandje.aspx");
            }
            else
            {
                Response.Redirect("WinkelmandjeLeeg.aspx");
            }
        }
    }
}