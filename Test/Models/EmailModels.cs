using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Web.Helpers;
using System.Net.Mail;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class EmailModel
    {
        [Required(ErrorMessage = "Campo requerido")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string FromAdress { get; set; }
        public string ToAdress { get; set; }
        [Required( ErrorMessage = "Campo requerido")]
        public string Subject { get; set; }
        [Required( ErrorMessage = "Campo requerido")]
        public string Body { get; set; }
    }

    public class Email
    {
        public static void Send(string from, string subject, string body)
        { 
            WebMail.SmtpServer = "smtp.gmail.com";
            WebMail.SmtpPort = 25;
            WebMail.UserName = "efraindx@gmail.com";
            WebMail.Password = "losreyes";
            WebMail.From = from;
            string toEmail = System.Configuration.ConfigurationManager.AppSettings.Get("ToAdress");

            // Send email
            WebMail.Send(to: toEmail,
                subject: subject,
                body: body
            );
        }
    }


}