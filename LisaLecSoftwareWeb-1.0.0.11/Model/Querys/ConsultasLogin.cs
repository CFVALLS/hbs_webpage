using Model.Conexion;
using Model.Contexto;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model.Querys
{
    public class ConsultasLogin
    {

        public Boolean ValidarInicioSesion(Usuario modUsu) {

            Boolean _val = false;

            try
			{                
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {

                        connection.Open();
                        
                        SqlCommand command = new SqlCommand("SELECT usuario FROM Usuario where usuario = '"+ modUsu.usuario.Trim() + "' and clave='"+ modUsu.clave.Trim() +"'", connection);
                        
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                _val = true;
                            }
                        }

                        reader.Close();

                        return _val;                   
                }
            }
			catch (Exception ex)
			{
                return _val;
			}
        }

    }
}
