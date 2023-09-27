using Controlador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LisalecWeb.Vistas.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        [WebMethod]
        public static String login(String usu, String pass)
        {
            String valHTML = "";
            usu = usu.Trim();
            pass = pass.Trim();
            try
            {


                if (!usu.Equals("") && !pass.Equals(""))
                {
                    String _val = new ControladorLogin().ValidarInicioSesion(usu, pass);
                    if (_val.Equals("S"))
                    {
                        System.Web.HttpContext.Current.Session["usu"] = usu;
                        valHTML += "<script>window.location.href =\"../Dashboard/Dashboard.aspx\"; </script>";
                    }
                    else if (_val.Equals("N"))
                    {
                        valHTML += "<script>Swal.fire(" +
                                  "'Credenciales incorrectas'," +
                                  "'Debe ingresar usuario y contraseña otorgados por el administrador'," +
                                  "'info'" +
                                ")</script>";
                    }
                    else {
                        valHTML += "<script>Swal.fire(" +
                                  "'Error al tratar de iniciar sesión'," +
                                  "'Debe ingresar usuario y contraseña'," +
                                  "'warning'" +
                                ")</script>";
                    }

                    return valHTML;
                }
                else
                {
                    valHTML += "<script>Swal.fire(" +
                                  "'Error al tratar de iniciar sesión'," +
                                  "'Debe ingresar usuario y contraseña'," +
                                  "'warning'" +
                                ")</script>";
                    return valHTML;
                }
               
            }
            catch (Exception ex)
            {

                return valHTML;
            }
        }


        [WebMethod]
        public static String load(String key)
        {
           
            System.Web.HttpContext.Current.Session["usu"]= null;
            return "<script> </script>";

        }
    }
}