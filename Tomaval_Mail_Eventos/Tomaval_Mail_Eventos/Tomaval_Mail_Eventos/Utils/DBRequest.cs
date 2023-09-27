using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Tomaval_Mail_Eventos
{
    public class DBRequest
    {
        public static string conString = Tools.base64ToText(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);

        public static DataSet Maquinalistar()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("maquina_listar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        con.Open();
                        SqlDataAdapter daAdaptador = new SqlDataAdapter(cmd);
                        DataSet dtDatos = new DataSet();
                        daAdaptador.Fill(dtDatos);

                        return dtDatos;
                    }
                }
            }
            catch (Exception ex)
            {
                Tools.writeLog("Maquinalistar", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return null;
            }

        }


        public static DataSet crearLectura(int idmaquina, string potencia, string partidas, string parada_asig1, string parada_asig2, string parada_asig3)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("lectura_crear", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_maquina", SqlDbType.Int).Value = idmaquina;
                        cmd.Parameters["@id_maquina"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@potencia", SqlDbType.VarChar, 50).Value = potencia;
                        cmd.Parameters["@potencia"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@partidas", SqlDbType.VarChar, 50).Value = partidas;
                        cmd.Parameters["@partidas"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@parada_asig_1", SqlDbType.VarChar, 50).Value = parada_asig1;
                        cmd.Parameters["@parada_asig_1"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@parada_asig_2", SqlDbType.VarChar, 50).Value = parada_asig2;
                        cmd.Parameters["@parada_asig_2"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@parada_asig_3", SqlDbType.VarChar, 50).Value = parada_asig3;
                        cmd.Parameters["@parada_asig_3"].Direction = ParameterDirection.Input;


                        con.Open();
                        SqlDataAdapter daAdaptador = new SqlDataAdapter(cmd);
                        DataSet dtDatos = new DataSet();
                        daAdaptador.Fill(dtDatos);

                        return dtDatos;
                    }
                }
            }
            catch (Exception ex)
            {
                Tools.writeLog("crearLectura", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return null;
            }

        }

        public static DataSet ListaEventosAyer()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_listaEventosAyer", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        con.Open();
                        SqlDataAdapter daAdaptador = new SqlDataAdapter(cmd);
                        DataSet dtDatos = new DataSet();
                        daAdaptador.Fill(dtDatos);

                        return dtDatos;
                    }
                }
            }
            catch (Exception ex)
            {
                Tools.writeLog("ListaEventosAyer", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return null;
            }
        }

        public static DataSet ListaDestinatarios()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListaDestinatariosMaquina", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        con.Open();
                        SqlDataAdapter daAdaptador = new SqlDataAdapter(cmd);
                        DataSet dtDatos = new DataSet();
                        daAdaptador.Fill(dtDatos);

                        return dtDatos;
                    }
                }
            }
            catch (Exception ex)
            {
                Tools.writeLog("ListaDestinatarios", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return null;
            }
        }

    }
}