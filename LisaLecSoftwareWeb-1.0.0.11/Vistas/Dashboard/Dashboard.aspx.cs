using Controlador;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LisalecWeb.Vistas.Dashboard
{
    public partial class Dashboard : System.Web.UI.Page
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
                    String _html = "";

                    _html += "<script>" + LoadMaquinas() + "</script> ";
                    return _html;
                }
                else
                {
                    return new ClasesGenerales().msgNoSession();
                }
            }
            catch (Exception ex)
            {
                return new ClasesGenerales().msgNoSession();
            }
        }

        [WebMethod]
        public static String load_3(String key)
        {
            try
            {
                if (System.Web.HttpContext.Current.Session["usu"] != null)
                {
                    String _html = "";

                    _html += "<script>" + LoadMaquinas_3() + "</script> ";

                    return _html;
                }
                else
                {
                    return new ClasesGenerales().msgNoSession();
                }
            }
            catch (Exception ex)
            {
                return new ClasesGenerales().msgNoSession();
            }
        }

        [WebMethod]
        public static String load_4(String key)
        {
            try
            {
                if (System.Web.HttpContext.Current.Session["usu"] != null)
                {
                    String _html = "";

                    _html += "<script>" + LoadMaquinas_4() + "</script> ";

                    return _html;
                }
                else
                {
                    return new ClasesGenerales().msgNoSession();
                }
            }
            catch (Exception ex)
            {
                return new ClasesGenerales().msgNoSession();
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
        public static String redirectMaquinas(string u)
        {
            try
            {

                return "<script>window.location.href =\"../Maquinas/Maquinas.aspx\"; </script>";

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
        public static String LoadMaquinas()
        {

            try
            {
                String html = "";

                html += " " + new ControladorDashboard().ObtenerUltimaLecturaMaquina_1();

                return "" + html + "";

            }
            catch (Exception e)
            {
                return "<script></strong>";
            }


        }

        [WebMethod]
        public static String LoadMaquinas_3()
        {

            try
            {
                String html = "";

                html += " " + new ControladorDashboard().ObtenerUltimaLecturaMaquina_3();

                return "" + html + "";

            }
            catch (Exception e)
            {
                return "<script></strong>";
            }


        }

        [WebMethod]
        public static String LoadMaquinas_4()
        {

            try
            {
                String html = "";

                html += " " + new ControladorDashboard().ObtenerUltimaLecturaMaquina_4();

                return "" + html + "";

            }
            catch (Exception e)
            {
                return "<script></strong>";
            }


        }

    }
}