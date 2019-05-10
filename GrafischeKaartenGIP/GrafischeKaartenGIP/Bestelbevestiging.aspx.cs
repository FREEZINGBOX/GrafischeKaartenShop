﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrafischeKaartenGIP.Business;

namespace GrafischeKaartenGIP
{
    public partial class Bestelbevestiging : System.Web.UI.Page
    {
        Controller _Controller = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblBedrag.Text = string.Format("{0:c}",_Controller.HaalOrderOp(Convert.ToInt32(Context.User.Identity.Name)).Prijs);
            lblOrdernr.Text = _Controller.HaalOrderOp(Convert.ToInt32(Context.User.Identity.Name)).OrderNr.ToString();
        }

        protected void btnCatalogus_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}