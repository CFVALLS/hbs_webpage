using Model.Conexion;
using Model.Contexto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace Model.Querys
{
    public class ConsultasGenerales
    {
        public Int32 PoseePerniso(PermisoUsuario permisoUsuario)
        {
            Int32 val_ = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_PoseePermiso", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@codUsuario", SqlDbType.VarChar, 100).Value = permisoUsuario.codUsuario;
                        cmd.Parameters["@codUsuario"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@idPermiso", SqlDbType.Int).Value = permisoUsuario.idPermiso;
                        cmd.Parameters["@idPermiso"].Direction = ParameterDirection.Input;

                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            val_ = reader.GetInt32(0);

                        }

                        return val_;

                    }
                }
            }
            catch (Exception ex)
            {
                return val_; ;
            }
        }
    }
}
