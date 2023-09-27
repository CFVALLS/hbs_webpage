using Model.Conexion;
using Model.Contexto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Querys
{
    public  class ConsultasDashboard
    {
        public Lectura ObtenerUltimaLecturaMaquina(Lectura modLec)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ObtUltimaLecturaMaquina", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_maquina", SqlDbType.Int).Value = modLec.id_maquina;
                        cmd.Parameters["@id_maquina"].Direction = ParameterDirection.Input;

                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            modLec = new Lectura(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), 
                                                    reader.GetString(3), reader.GetString(4), reader.GetString(5),
                                                    reader.GetString(6), reader.GetString(7), reader.GetString(8),
                                                    reader.GetString(9), reader.GetDateTime(10).AddHours(-4).ToString(), reader.GetString(11));

                        }

                        return modLec;

                    }
                }
            }
            catch (Exception ex)
            {
                // Utils.Tools.writeLog("crearCliente", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return modLec;
            }
        }

        public List<Lectura> ObtenerUltima10LecturaMaquina(Lectura modLec)
        {
            List<Lectura> lstLecturas = new List<Lectura>();
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Obtener10LecturasPorMaquina", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_maquina", SqlDbType.Int).Value = modLec.id_maquina;
                        cmd.Parameters["@id_maquina"].Direction = ParameterDirection.Input;

                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            modLec = new Lectura(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2),
                                                    reader.GetString(3), "", reader.GetString(4),
                                                    reader.GetString(5), "", "",
                                                    "", "", "");
                            lstLecturas.Add(modLec);
                        }

                        return lstLecturas;

                    }
                }
            }
            catch (Exception ex)
            {
                // Utils.Tools.writeLog("crearCliente", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return lstLecturas;
            }
        }


    }
}
