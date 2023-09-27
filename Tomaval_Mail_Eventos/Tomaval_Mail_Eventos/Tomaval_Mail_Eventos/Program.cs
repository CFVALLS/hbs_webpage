using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace Tomaval_Mail_Eventos
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Leer Eventos
                DataSet eventos = DBRequest.ListaEventosAyer();
                if (eventos.Tables[0].Rows.Count == 0) return;
                //Leer Destinatarios
                DataSet destinatarios = DBRequest.ListaDestinatarios();
                if (destinatarios.Tables[0].Rows.Count == 0) return;
                //Leer HTML
                string htmltext = File.ReadAllText("mail_eventos.html");
                string pdftext = File.ReadAllText("pdf_adjunto.html");
                //Formatear plantilla (para cada destinatario las maquinas que tenga asignadas)
                int iddestActual = 0;
                string mailDestinatario = "";
                string bodyHtml = htmltext;
                string bodypdf = pdftext;
                string tableRows = "";
                foreach (DataRow destinatario in destinatarios.Tables[0].Rows)
                {
                    if (iddestActual == 0)
                    {

                        bodyHtml = bodyHtml.Replace("$nombre$", destinatario["nombre"].ToString() + " " + destinatario["apellido"].ToString());
                        bodyHtml = bodyHtml.Replace("$dia$", DateTime.Today.AddDays(-1).ToShortDateString());

                        bodypdf = bodypdf.Replace("$nombre$", destinatario["nombre"].ToString() + " " + destinatario["apellido"].ToString());
                        bodypdf = bodypdf.Replace("$dia$", DateTime.Today.AddDays(-1).ToShortDateString());

                        foreach (DataRow evento in eventos.Tables[0].Rows)
                        {
                            if (destinatario["id_maquina"].ToString() == evento["id_maquina"].ToString())
                            {
                                tableRows += "<tr><td>" + evento["creacion"].ToString() + "</td>";
                                tableRows += "<td>" + evento["nomZona"].ToString() + "</td>";
                                tableRows += "<td>" + evento["nomCentro"].ToString() + "</td>";
                                tableRows += "<td>" + evento["nomMaquina"].ToString() + "</td>";
                                tableRows += "<td>" + evento["nomTipoEvento"].ToString() + "</td>";
                                tableRows += "<td>" + evento["descripcion"].ToString() + "</td></tr>";
                            }
                        }
                        iddestActual = int.Parse(destinatario["id_destinatario"].ToString());
                        mailDestinatario = destinatario["mail"].ToString();
                    }
                    else if (iddestActual == int.Parse(destinatario["id_destinatario"].ToString()))
                    {
                        foreach (DataRow evento in eventos.Tables[0].Rows)
                        {
                            if (destinatario["id_maquina"].ToString() == evento["id_maquina"].ToString())
                            {
                                tableRows += "<tr><td>" + evento["creacion"].ToString() + "</td>";
                                tableRows += "<td>" + evento["nomZona"].ToString() + "</td>";
                                tableRows += "<td>" + evento["nomCentro"].ToString() + "</td>";
                                tableRows += "<td>" + evento["nomMaquina"].ToString() + "</td>";
                                tableRows += "<td>" + evento["nomTipoEvento"].ToString() + "</td>";
                                tableRows += "<td>" + evento["descripcion"].ToString() + "</td></tr>";
                            }
                        }
                    }
                    else
                    {
                        //aca cambio de destinatario-> limpiar variables
                        if (!"".Equals(tableRows))
                        {
                            bodyHtml = bodyHtml.Replace("$REGISTROS$", tableRows);
                            bodypdf = bodypdf.Replace("$REGISTROS$", tableRows);
                            //Enviar Correo
                            if (File.Exists("reporte.pdf"))
                            {
                                File.Delete("reporte.pdf");
                            }
                            CrearPdfDesdeHtml("reporte.pdf", bodypdf);

                            FileStream stream2 = System.IO.File.OpenRead("reporte.pdf");
                            byte[] fileBytes2 = new byte[stream2.Length];

                            stream2.Read(fileBytes2, 0, fileBytes2.Length);
                            stream2.Close();

                            EnviarMail(mailDestinatario, bodyHtml, fileBytes2);
                        }
                        tableRows = "";
                        bodyHtml = htmltext;
                        bodypdf = pdftext;
                        bodyHtml = bodyHtml.Replace("$nombre$", destinatario["nombre"].ToString() + " " + destinatario["apellido"].ToString());
                        bodyHtml = bodyHtml.Replace("$dia$", DateTime.Today.AddDays(-1).ToShortDateString());

                        bodypdf = bodypdf.Replace("$nombre$", destinatario["nombre"].ToString() + " " + destinatario["apellido"].ToString());
                        bodypdf = bodypdf.Replace("$dia$", DateTime.Today.AddDays(-1).ToShortDateString());

                        foreach (DataRow evento in eventos.Tables[0].Rows)
                        {
                            if (destinatario["id_maquina"].ToString() == evento["id_maquina"].ToString())
                            {
                                tableRows += "<tr><td>" + evento["creacion"].ToString() + "</td>";
                                tableRows += "<td>" + evento["nomZona"].ToString() + "</td>";
                                tableRows += "<td>" + evento["nomCentro"].ToString() + "</td>";
                                tableRows += "<td>" + evento["nomMaquina"].ToString() + "</td>";
                                tableRows += "<td>" + evento["nomTipoEvento"].ToString() + "</td>";
                                tableRows += "<td>" + evento["descripcion"].ToString() + "</td></tr>";
                            }
                        }

                        iddestActual = int.Parse(destinatario["id_destinatario"].ToString());
                        mailDestinatario = destinatario["mail"].ToString();
                    }


                }
                //aca envio el ultimo de la lista
                if (!"".Equals(tableRows))
                {
                    bodyHtml = bodyHtml.Replace("$REGISTROS$", tableRows);
                    bodypdf = bodypdf.Replace("$REGISTROS$", tableRows);

                    if (File.Exists("reporte.pdf"))
                    {
                        File.Delete("reporte.pdf");
                    }
                    CrearPdfDesdeHtml("reporte.pdf", bodypdf);

                    FileStream stream = System.IO.File.OpenRead("reporte.pdf");
                    byte[] fileBytes = new byte[stream.Length];

                    stream.Read(fileBytes, 0, fileBytes.Length);
                    stream.Close();

                    EnviarMail(mailDestinatario, bodyHtml, fileBytes);
                }
            }
            catch (Exception ex)
            {
                Tools.writeLog("Main - Reportes", ex.Message, ex.StackTrace);
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }

        private static void EnviarMail(string mailDestinatario, string bodyHtml, byte[] reporte)
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

                MemoryStream ms = new MemoryStream(reporte);
                ms.Position = 0;
                Attachment attach = new Attachment(ms, "reporte", "application/pdf");

                email.Attachments.Add(attach);

                //    Host = "Mail.aguasaurora.cl",

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
                Tools.writeLog("EnviarMail - Reportes", ex.Message, ex.StackTrace);
            }
        }

        public static void CrearPdfDesdeHtml(string path, string html)
        {
            // Crea un documento PDF.
            Document doc = new Document(PageSize.A4, 10, 10, 10, 10);
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();

            // Agrega el HTML al documento PDF.
            //HTMLWorker htmlWorker = new HTMLWorker(doc);
            //htmlWorker.Parse(new StringReader(html));

            //Read string contents using stream reader and convert html to parsed conent 
            var parsedHtmlElements = HTMLWorker.ParseToList(new StringReader(html), null);

            //Get each array values from parsed elements and add to the PDF document
            foreach (var htmlElement in parsedHtmlElements)
                doc.Add(htmlElement as IElement);

            // Cierra el documento PDF.
            doc.Close();
        }


    }
}
