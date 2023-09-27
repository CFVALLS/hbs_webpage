using Model.Conexion;
using Model.Contexto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Querys
{
    public class ConsultaUsuarios
    {
        public List<Usuario> ListaUsuarios()
        {
            List<Usuario> listaUsers = new List<Usuario>();
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListaUsuarios", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            Usuario modUsu = new Usuario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2).ToString(),
                                                        reader.GetBoolean(3), reader.GetDateTime(4).ToString(), reader.GetString(5), reader.GetString(6), reader.GetInt32(7));
                            listaUsers.Add(modUsu);
                        }

                        return listaUsers;

                    }
                }
            }
            catch (Exception ex)
            {
                // Utils.Tools.writeLog("crearCliente", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return listaUsers;
            }
        }
    }
}
