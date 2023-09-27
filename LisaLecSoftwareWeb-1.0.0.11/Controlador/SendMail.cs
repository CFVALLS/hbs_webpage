using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    class SendMail : Configs
    {
        public void EnviarMail(string mailDestinatario, string bodyHtml/*, byte[] reporte*/)
        {
            try
            {

                //string sender = "hbs.energia@cloudconnection.cl";
                //string pass = "ux6aq-vfWR?[";

                string sender = "cmg.gbscorp@gmail.com";
                //string pass = "Gbscorp2020";
                string pass = "obpbabnsgtbvxmac";


                 //////////
                MailMessage email = new MailMessage(sender, mailDestinatario);

                email.Subject = "Reporte Eventos";
                email.Body = bodyHtml;
                email.BodyEncoding = System.Text.Encoding.UTF8;
                email.IsBodyHtml = true;

                //MemoryStream ms = new MemoryStream(reporte);
                //ms.Position = 0;
                //Attachment attach = new Attachment(ms, "reporte", "application/pdf");
                //email.Attachments.Add(attach);


                //SmtpClient smtp = new SmtpClient
                //{
                //    Host = "mail.cloudconnection.cl",
                //    Port = 587,
                //    EnableSsl = false,
                //    UseDefaultCredentials = false,
                //    Credentials = new NetworkCredential(sender, pass)
                //};

                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(sender, pass)
                };

                smtp.Send(email);

            }
            catch (Exception ex)
            {
                writelog("EnviarMail", ex.Message, ex.StackTrace);
                //Tools.writeLog("EnviarMail - Reportes", ex.Message, ex.StackTrace);
            }
        }
    }
}
