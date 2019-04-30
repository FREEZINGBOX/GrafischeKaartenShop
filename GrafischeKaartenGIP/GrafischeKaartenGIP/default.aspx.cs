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
            gvArtikelen.DataSource = _Controller.HaalArtiekelenOp();
            gvArtikelen.DataBind();
        }
    }
}