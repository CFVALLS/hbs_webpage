using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Tomaval_Lectura.Utils
{
    public class DBRequest
    {
        public static string conString = Utils.Tools.base64ToText(ConfigurationManager.ConnectionStrings["conString"].ConnectionString);

        public static DataSet Maquinalistar ()
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
                Utils.Tools.writeLog("Maquinalistar", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return null;
            }

        }

        
        public static DataSet crearLectura(Models.Lectura lectura)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("lectura_crear", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_maquina", SqlDbType.Int).Value = lectura.Id_maquina;
                        cmd.Parameters["@id_maquina"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@last_update", SqlDbType.VarChar, 50).Value = (object)lectura.Last_update ?? DBNull.Value;
                        cmd.Parameters["@last_update"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@communication_state", SqlDbType.VarChar, 50).Value = (object)lectura.Communication_state ?? DBNull.Value;
                        cmd.Parameters["@communication_state"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@unit_state", SqlDbType.VarChar, 50).Value = (object)lectura.Unit_state ?? DBNull.Value;
                        cmd.Parameters["@unit_state"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@kwh_import", SqlDbType.VarChar, 50).Value = (object)lectura.Kwh_import ?? DBNull.Value;
                        cmd.Parameters["@kwh_import"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@act_power", SqlDbType.VarChar, 50).Value = (object)lectura.Act_power ?? DBNull.Value;
                        cmd.Parameters["@act_power"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@act_power_req", SqlDbType.VarChar, 50).Value = (object)lectura.Act_power_req ?? DBNull.Value;
                        cmd.Parameters["@act_power_req"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@run_hours", SqlDbType.VarChar, 50).Value = (object)lectura.Run_hours ?? DBNull.Value;
                        cmd.Parameters["@run_hours"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@nomin_power", SqlDbType.VarChar, 50).Value = (object)lectura.Nomin_power ?? DBNull.Value;
                        cmd.Parameters["@nomin_power"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@engine_state", SqlDbType.VarChar, 50).Value = (object)lectura.Engine_state ?? DBNull.Value;
                        cmd.Parameters["@engine_state"].Direction = ParameterDirection.Input;


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
                Utils.Tools.writeLog("crearCliente", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return null;
            }

        }

        public static DataSet ValidaToken()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ValidaToken", con))
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
                Utils.Tools.writeLog("ValidaToken", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return null;
            }

        }

        public static Boolean ActualizaToken(string token)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ActualizaToken", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@token", SqlDbType.VarChar).Value = token;
                        cmd.Parameters["@token"].Direction = ParameterDirection.Input;

                        con.Open();
                        SqlDataAdapter daAdaptador = new SqlDataAdapter(cmd);
                        DataSet dtDatos = new DataSet();
                        daAdaptador.Fill(dtDatos);

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.Tools.writeLog("ActualizaToken", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return false;
            }

        }

    }
}