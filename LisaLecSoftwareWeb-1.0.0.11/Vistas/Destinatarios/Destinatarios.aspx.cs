using Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LisalecWeb.Vistas.Destinatarios
{
    public partial class Destinatarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static String load(String key)
        {
            try
            {
                if (System.Web.HttpContext.Current.Session["usu"] != null)
                {
                    return "<script>" + new ControladorDestinatarios().ListaDestinatarios() + "</script> ";
                }
                else
                {
                    return new ClasesGenerales().msgNoSession();
                }
            }
            catch (Exception ex)
            {
                return "<script> </script>";
            }
        }

        [WebMethod]
        public static String EliminarDestinatario(string key)
        {
            try
            {

                if (new ControladorDestinatarios().EliminarDestinatario(key))
                {
                    return "<script>" + new ControladorDestinatarios().ListaDestinatarios() + "</script>";
                }
                else
                {
                    return "<script>Swal.fire(" +
                                   "'Error del sistema'," +
                                   "'Se ha producido un error en el sistema, favor comunicarse con soporte.'," +
                                   "'error'" +
                                 ")</script>";
                }

            }
            catch (Exception ex)
            {
                return "<script>Swal.fire(" +
                                  "'Error del sistema'," +
                                  "'Se ha producido un error en el sistema, favor comunicarse con soporte.'," +
                                  "'error'" +
                                ")</script>";
            }
        }


        [WebMethod]
        public static String redirectDestinatarios(string u)
        {
            try
            {

                return "<script>window.location.href =\"../Destinatarios/Destinatarios.aspx\"; </script>";

            }
            catch (Exception ex)
            {
                return "<script> </script>";
            }
        }

        [WebMethod]
        public static String logOut(String key)
        {
            try
            {
                System.Web.HttpContext.Current.Session["usu"] = null;
                return new ClasesGenerales().msgNoSession();

            }
            catch (Exception ex)
            {
                System.Web.HttpContext.Current.Session["usu"] = null;
                return new ClasesGenerales().msgNoSession();
            }
        }

        [WebMethod]
        public static String redirectHome(string u)
        {
            try
            {

                return "<script>window.location.href =\"../Dashboard/Dashboard.aspx\"; </script>";

            }
            catch (Exception ex)
            {
                return "<script> </script>";
            }
        }

        [WebMethod]
        public static String redirectEventos(string u)
        {
            try
            {

                return "<script>window.location.href =\"../Eventos/Eventos.aspx\"; </script>";

            }
            catch (Exception ex)
            {
                return "<script> </script>";
            }
        }

        [WebMethod]
        public static String redirectSesion(string u)
        {
            try
            {

                return "<script>window.location.href =\"../Login/Login.aspx\"; </script>";

            }
            catch (Exception ex)
            {
                return "<script> </script>";
            }
        }


        public static String ReseteoCampos()
        {
            try
            {
                return new ControladorDestinatarios().ListaZonas() +  " $('#correo').val('');  $('#nombre').val(''); $('#apellido').val(''); $('#idDestinatarioEdit').val('');  $('#nombreEdit').val(''); $('#apellidoEdit').val(''); ";
            }
            catch (Exception e)
            {
                return "<script></script>";
            }

        }


        [WebMethod]
        public static String GuardarDestinatario(string cor, string nom, string ape)
        {
            try
            {

                if (cor.Trim() != "" && nom.Trim() != "" && ape.Trim() != "")
                {
                    if (IsValidEmail(cor))
                    {
                        if (new ControladorDestinatarios().RegistrarDestinatario(cor, nom, ape))
                        {
                            return "<script>  Swal.fire(" +
                                          "'Destinatario registrado'," +
                                          "'El destinatario ha sido registrado correctamente'," +
                                          "'success'" +
                                        "); </script> <script> $('#msgCorreo').text(''); $('#newDestinatario').modal('hide'); " + ListaDestinatarios() + ReseteoCampos() + " </script>";
                        }
                        else
                        {

                            return "";
                        }

                    }
                    else
                    {
                        return "<script> $('#msgCorreo').text('Correo inválido'); </script>";


                    }
                }
                else
                {

                    return "<script>Swal.fire(" +
                                      "'Destinatario NO registrado'," +
                                      "'Todos los campos son requeridos, favor verificar antes de registrar.'," +
                                      "'error'" +
                                    ")</script>";
                }

                
                    

                
            }
            catch (Exception ex)
            {
                return "<script>Swal.fire(" +
                                  "'Error del sistema'," +
                                  "'Se ha producido un error en el sistema, favor comunicarse con soporte.'," +
                                  "'error'" +
                                ")</script>";
            }
        }


        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        [WebMethod]
        public static String GuardarDestinatarioEdit(string idD, string cor, string nom, string ape, string mq)
        {
            try
            {
                if (cor.Trim() != "" && nom.Trim() != "" && ape.Trim() != "" && mq.Trim() != "") 
                {
                    if (IsValidEmail(cor))
                    {
                        String[] lstMqs = new String[10];

                        if (!mq.Equals(""))
                        {
                            lstMqs = mq.Split(new char[] { ',' });
                        }

                        if (new ControladorDestinatarios().EditarDestinatario(idD, cor, nom, ape, System.Web.HttpContext.Current.Session["usu"].ToString()))
                        {

                            new ControladorDestinatarios().AsignarZona(idD, lstMqs);

                            return "<script>  Swal.fire(" +
                                          "'Destinatario editado'," +
                                          "'El destinatario ha sido editado correctamente'," +
                                          "'success'" +
                                        "); </script> <script> $('#msgCorreoEdit').text(''); $('#editDestinatario').modal('hide'); " + ListaDestinatarios() + ReseteoCampos() + " </script>";
                        }
                        else
                        {

                            return "<script>Swal.fire(" +
                                          "'Destinatario NO editado'," +
                                          "'Se ha encontrado un problema al editar el destinatario, favor consultar a soporte'," +
                                          "'error'" +
                                        ")</script>";
                        }

                    }
                    else
                    {
                        return "<script> $('#msgCorreoEdit').text('Correo inválido'); </script>";


                    }


                }
                else
                {

                    return "<script>Swal.fire(" +
                                      "'Destinatario NO editado'," +
                                      "'Todos los campos son requeridos, favor verificar antes de editar.'," +
                                      "'error'" +
                                    ")</script>";
                }


               

                
            }
            catch (Exception ex)
            {
                return "<script>Swal.fire(" +
                                  "'Error del sistema'," +
                                  "'Se ha producido un error en el sistema, favor comunicarse con soporte.'," +
                                  "'error'" +
                                ")</script>";
            }
        }


        public static String ListaDestinatarios()
        {
            try
            {
                return new ControladorDestinatarios().ListaDestinatarios();
            }
            catch (Exception e)
            {
                return "<script></script>";
            }

        }


        [WebMethod]
        public static String LoadInfoEditar(string key)
        {
            try
            {
                return "<script>" + new ControladorDestinatarios().ListaZonas() + new ControladorDestinatarios().LoadInfoEditar(key) +  "</script>";

            }
            catch (Exception ex)
            {
                return "<script>Swal.fire(" +
                                  "'Error del sistema'," +
                                  "'Se ha producido un error en el sistema, favor comunicarse con soporte.'," +
                                  "'error'" +
                                ")</script>";
            }
        }


        [WebMethod]
        public static String Reset(string u)
        {
            try
            {
                return "<script>" + new ControladorDestinatarios().ListaZonas() + " $('#msgCorreoEdit').text(''); $('#msgCorreo').text(''); $('#correo').val('');  $('#nombre').val(''); $('#apellido').val(''); $('#idDestinatarioEdit').val('');  $('#nombreEdit').val(''); $('#apellidoEdit').val(''); </script>";
            }
            catch (Exception e)
            {
                return "<script></script>";
            }
        }


        [WebMethod]
        public static String ValEmailFormat(string u)
{
            try
            {
                if (IsValidEmail(u))
                {
                    return "<script> $('#msgCorreo').text(''); </script>";
                }
                else
                {
                    return "<script> $('#msgCorreo').text('Correo inválido'); </script>";


                }
            }
            catch (Exception e)
            {
                return "<script></script>";
            }
        }



    }
}