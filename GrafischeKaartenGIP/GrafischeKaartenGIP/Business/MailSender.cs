using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace GrafischeKaartenGIP.Business
{
    public class MailSender
    {
        private string _naam;
        private string _mail;
        private string _onderwerp;
        private string _boodschap;

        public string Naam
        {
            set { _naam = value; }
        }
        public string Mail
        {
            set { _mail = value; }
        }
        public string Onderwerp
        {
            set { _onderwerp = value; }
        }
        public string Boodschap
        {
            set { _boodschap = value; }
        }

        public void StuurMail()
        {
            SmtpClient mijnSMTP = new SmtpClient();
            mijnSMTP.Host = "smtp.gmail.com";
            mijnSMTP.Port = 587;
            mijnSMTP.EnableSsl = true;
            mijnSMTP.Credentials = new System.Net.NetworkCredential("grafischekaartenshop@gmail.com", "Test*?-*");

            MailMessage mijnMail = new MailMessage("grafischekaartenshop@gmail.com",_mail);

            mijnMail.Subject = _onderwerp;
            mijnMail.Body = "Geachte " + _naam + Environment.NewLine + _boodschap;

            mijnSMTP.Send(mijnMail);
        }
    }
}