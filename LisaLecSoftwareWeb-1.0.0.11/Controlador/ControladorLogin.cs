using Model.Contexto;
using Model.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ControladorLogin
    {
        public String ValidarInicioSesion(string usu, string pass)
        {
            String _val = "";
			try
			{

                if (new ConsultasLogin().ValidarInicioSesion(new Usuario
                                                                {
                                                                    usuario = usu,
                                                                    clave = pass.Trim()
                                                                })
                    )
                {

                    _val = "S";

                }
                else {
                    _val = "N";
                }
                
                return _val;
			}
			catch (Exception e)
			{
                _val = "E";
                return _val;
			}

        }
    }
}
