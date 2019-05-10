using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using GrafischeKaartenGIP.Business;
namespace GrafischeKaartenGIP
{
    public partial class login : System.Web.UI.Page
    {
        Controller _Controller = new Controller();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAanmelden_Click(object sender, EventArgs e)
        {
            if(_Controller.ControleerLoginEnStuurKlantNrTerug(txtGebruikersnaam.Text, txtWachtwoord.Text)==0)
            {
                lblUitvoer.Text = "Ongeldige Login...";
            }
            else
            {
                FormsAuthentication.RedirectFromLoginPage(_Controller.ControleerLoginEnStuurKlantNrTerug(txtGebruikersnaam.Text, txtWachtwoord.Text).ToString(), false);
            }
        }
    }
}