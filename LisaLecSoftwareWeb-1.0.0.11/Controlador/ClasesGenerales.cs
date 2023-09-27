using Model.Contexto;
using Model.Querys;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ClasesGenerales
    {

        /*** SESION ***/

        public String msgNoSession()
        {
            String html = "";

            html +=  "<script>window.location.href =\"../Login/Login.aspx\"; </script>";


            return html;

        }

        public bool PoseePermiso(PermisoUsuario permisoUsuario)
        {
            try
            {
                if (new ConsultasGenerales().PoseePerniso(permisoUsuario)==1)
                {
                    return true;

                }
                else {

                    return false;
                
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
