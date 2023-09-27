using Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LisalecWeb.Vistas.Eventos
{
    public partial class Eventos : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs e)
        {
            //LoadInfoEditar
        }

        [WebMethod]
        public static String load(String key)
        {
            try
            {
                if (System.Web.HttpContext.Current.Session["usu"] != null)
                {
                    return "<script>" + new ControladorEventos().ListaEventos() + " " + ReseteoCampos() + "</script> ";
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
                if (new ControladorDashboard().PoseePermiso(1, System.Web.HttpContext.Current.Session["usu"].ToString()))
                {
                    return "<script>window.location.href =\"../Eventos/Eventos.aspx\"; </script>";
                }
                else
                {

                    if (new ControladorDashboard().PoseePermiso(2, System.Web.HttpContext.Current.Session["usu"].ToString()))
                    {
                        return "<script>window.location.href =\"../Eventos/Eventos.aspx\"; </script>";
                    }
                    else
                    {

                        if (new ControladorDashboard().PoseePermiso(3, System.Web.HttpContext.Current.Session["usu"].ToString()))
                        {
                            return "<script>Swal.fire(" +
                                     "'Permiso denegado.'," +
                                     "'Usted no posee permisos para acceder a este módulo, favor consultar al Administrador'," +
                                     "'warning'" +
                                   ")</script>";
                        }
                    }

                }
                return "<script>Swal.fire(" +
                                      "'Permiso denegado.'," +
                                      "'Usted no posee permisos para acceder a este módulo, favor consultar al Administrador'," +
                                      "'warning'" +
                                    ")</script>";

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

        [WebMethod]
        public static String redirectDestinatarios(string u)
        {
            try
            {
                if (new ControladorDashboard().PoseePermiso(1, System.Web.HttpContext.Current.Session["usu"].ToString()))
                {
                    return "<script>window.location.href =\"../Destinatarios/Destinatarios.aspx\"; </script>";
                }
                else
                {

                    if (new ControladorDashboard().PoseePermiso(2, System.Web.HttpContext.Current.Session["usu"].ToString()))
                    {
                        return "<script>Swal.fire(" +
                                     "'Permiso denegado.'," +
                                     "'Usted no posee permisos para acceder a este módulo, favor consultar al Administrador'," +
                                     "'warning'" +
                                   ")</script>";
                    }
                    else
                    {

                        if (new ControladorDashboard().PoseePermiso(3, System.Web.HttpContext.Current.Session["usu"].ToString()))
                        {
                            return "<script>Swal.fire(" +
                                     "'Permiso denegado.'," +
                                     "'Usted no posee permisos para acceder a este módulo, favor consultar al Administrador'," +
                                     "'warning'" +
                                   ")</script>";
                        }
                    }

                }
                return "<script>Swal.fire(" +
                                      "'Permiso denegado.'," +
                                      "'Usted no posee permisos para acceder a este módulo, favor consultar al Administrador'," +
                                      "'warning'" +
                                    ")</script>";

            }
            catch (Exception ex)
            {
                return "<script> </script>";
            }
        }

        [WebMethod]
        public static String SaveEvent(string det, string idMaq, string idEv, string fecha, string usu, string hora)
        {
            try
            {
                if (det.Trim() != "" && idMaq.Trim() != "" && idEv.Trim() != "" && usu.Trim() !="" && hora.Trim() != "")
                {

                    fecha = DateTime.Parse(fecha).ToString("yyyy-dd-MM") + " " + hora.Trim();


                    if (new ControladorEventos().RegistrarEvento(det, idMaq, System.Web.HttpContext.Current.Session["usu"].ToString(), idEv, fecha, usu))
                    {
                        return "<script>Swal.fire(" +
                                      "'Evento registrado'," +
                                      "'El evento ha sido registrado correctamente'," +
                                      "'success'" +
                                    "); </script> <script> " + ListaEventos() + " $('#newEvent').modal('hide'); </script>";
                    }
                    else
                    {

                        return "<script>Swal.fire(" +
                                      "'Evento NO registrado'," +
                                      "'Se ha encontrado un problema al registrar evento, favor consultar a soporte'," +
                                      "'error'" +
                                    ")</script>";
                    }

                }
                else
                {

                    return "<script>Swal.fire(" +
                                      "'Evento NO registrado'," +
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

        [WebMethod]
        public static String SaveEventEdit(string idE, string det, string idMaq, string idEv, string fecha, string usu, string hora)
        {
            try
            {

                if (det.Trim() != "" && idMaq.Trim() != "" && idEv.Trim() != "" && usu.Trim() != "" && hora.Trim() != "")
                {

                    fecha = DateTime.Parse(fecha).ToString("yyyy-dd-MM") + " " + hora.Trim();

                    if (new ControladorEventos().EditarEvento(idE, det, idMaq, System.Web.HttpContext.Current.Session["usu"].ToString(), idEv, fecha, usu))
                    {
                        return "<script>Swal.fire(" +
                                      "'Evento editado'," +
                                      "'El evento ha sido editado correctamente'," +
                                      "'success'" +
                                    "); </script> <script> " + ListaEventos() + " $('#editEvent').modal('hide'); </script>";
                    }
                    else
                    {

                        return "<script>Swal.fire(" +
                                      "'Evento NO editado'," +
                                      "'Se ha encontrado un problema al editar evento, favor consultar a soporte'," +
                                      "'error'" +
                                    ")</script>";
                    }
                }
                else
                {

                    return "<script>Swal.fire(" +
                                      "'Evento NO editado'," +
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

        [WebMethod]
        public static String LoadInfoEditar(string key)
        {
            try
            {
               return "<script>"+ new ControladorEventos().LoadInfoEditar(key) + "</script>" ;
                
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
        public static String EliminarEvento(string key)
        {
            try
            {

                if (new ControladorEventos().EliminarEvento(key))
                {                    
                    return "<script>" + new ControladorEventos().ListaEventos() + "</script>";
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

        public static String ListaEventos() {
            try
            {
                return new ControladorEventos().ListaEventos();
            }
            catch (Exception e)
            {
                return "<script></script>";
            }
        
        }

        public static String ReseteoCampos()
        {
            try
            {
                return new ControladorEventos().ListaTipoEventos() + " " +new ControladorEventos().ListaMaquinas(System.Web.HttpContext.Current.Session["usu"].ToString()) + " $('#fechaActual').val('" + DateTime.Now.ToString("dd/MM/yyyy").Replace("-","/") + "'); $('#detalleEdit').text(''); $('#detalle').text(''); $('#idEventEdit').val('');";
            }
            catch (Exception e)
            {
                return "<script></script>";
            }

        }

        [WebMethod]
        public static String Reset(string u)
        {
            try
            {
                string response = "<script>" + new ControladorEventos().ListaTipoEventos() + " " + new ControladorEventos().ListaMaquinas(System.Web.HttpContext.Current.Session["usu"].ToString()) + " $('#fechaActualEdit').val('" + DateTime.Now.ToString("dd/MM/yyyy") + "'); $('#detalleEdit').val(''); $('#detalle').val(''); $('#idEventEdit').val(''); </script>";
                return response;
            }
            catch (Exception e)
            {
                return "<script></script>";
            }
        }
    }
}