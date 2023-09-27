using Model.Contexto;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Conexion;
using System.Reflection;
using System.Runtime.Remoting.Messaging;


namespace Model.Querys
{
    public class ConsultasEventos : Configs
    {

        

        public List<Maquina> ListaMaquinas(String usuario)
        {
            List<Maquina> lstMaquina = new List<Maquina>();
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListaMaquinas", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = usuario;
                        cmd.Parameters["@usuario"].Direction = ParameterDirection.Input;

                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            Maquina modMaq = new Maquina(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                                                            reader.GetString(3), reader.GetBoolean(4));
                            lstMaquina.Add(modMaq);

                        }

                       return lstMaquina;
                    }
                }
            }
            catch (Exception ex)
            {
                return lstMaquina; 
            }

        }

        public List<Evento> ListaEventos()
        {
            List<Evento> listaEventos = new List<Evento>();
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListaEventos", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            Evento modEv = new Evento(reader.GetInt32(0), 0, reader.GetString(1), reader.GetDateTime(2).ToString(),
                                                        reader.GetString(3), reader.GetInt32(4), reader.GetString(5), reader.GetInt32(6), reader.GetString(7), reader.GetString(8),"");
                            listaEventos.Add(modEv);
                        }

                        return listaEventos;

                    }
                }
            }
            catch (Exception ex)
            {
                // Utils.Tools.writeLog("crearCliente", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return listaEventos;
            }
        }

        public List<Evento> ListaEventosPorMaquina(Int32 idMaquina)
        {
            List<Evento> listaEventos = new List<Evento>();
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListaEventosPorMaquina", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@id_maquina", SqlDbType.Int).Value = idMaquina;
                        cmd.Parameters["@id_maquina"].Direction = ParameterDirection.Input;


                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            Evento modEv = new Evento(reader.GetInt32(0), 0, reader.GetString(1), reader.GetDateTime(2).ToString(),
                                                        reader.GetString(3), reader.GetInt32(4), reader.GetString(5), 
                                                        reader.GetInt32(6), reader.GetString(7), reader.GetString(8),"");
                            listaEventos.Add(modEv);
                        }

                        return listaEventos;

                    }
                }
            }
            catch (Exception ex)
            {
                // Utils.Tools.writeLog("crearCliente", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return listaEventos;
            }
        }

        public bool RegistrarEvento(Evento modEve)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_RegistrarEvento", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 2000).Value = modEve.descripcion;
                        cmd.Parameters["@descripcion"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = modEve.usuario;
                        cmd.Parameters["@usuario"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@id_maquina", SqlDbType.Int).Value = modEve.id_maquina;
                        cmd.Parameters["@id_maquina"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@id_tipo_evento", SqlDbType.Int).Value = modEve.id_tipo_evento;
                        cmd.Parameters["@id_tipo_evento"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@hora", SqlDbType.VarChar, 50).Value = modEve.hora;
                        cmd.Parameters["@hora"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@usr_registra ", SqlDbType.VarChar, 50).Value = modEve.usuEvento;
                        cmd.Parameters["@usr_registra "].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@creacion ", SqlDbType.DateTime).Value = modEve.creacion;
                        cmd.Parameters["@creacion "].Direction = ParameterDirection.Input;

                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            modEve.id_evento = reader.GetInt32(0);
                            return true;
                        }                            

                            return false;
                    }
                }
            }
            catch (Exception ex)
            {
                writelog("RegistrarEvento", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return false; 
            }

        }

        public bool EditarEvento(Evento modEve)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_EditarEvento", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_evento", SqlDbType.Int).Value = modEve.id_evento;
                        cmd.Parameters["@id_evento"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 2000).Value = modEve.descripcion;
                        cmd.Parameters["@descripcion"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = modEve.usuario;
                        cmd.Parameters["@usuario"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@id_maquina", SqlDbType.Int).Value = modEve.id_maquina;
                        cmd.Parameters["@id_maquina"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@id_tipo_evento", SqlDbType.Int).Value = modEve.id_tipo_evento;
                        cmd.Parameters["@id_tipo_evento"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@hora", SqlDbType.VarChar, 50).Value = modEve.hora;
                        cmd.Parameters["@hora"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@usr_registra ", SqlDbType.VarChar, 50).Value = modEve.usuEvento;
                        cmd.Parameters["@usr_registra "].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@creacion ", SqlDbType.DateTime).Value = modEve.creacion;
                        cmd.Parameters["@creacion "].Direction = ParameterDirection.Input;

                        connection.Open();
                        ;
                        if (cmd.ExecuteNonQuery() == 1)
                        {

                            return true;

                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Utils.Tools.writeLog("crearCliente", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return false; ;
            }

        }

        public bool EliminarEvento(Evento modEve)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_EliminarEvento", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_evento", SqlDbType.Int).Value = modEve.id_evento;
                        cmd.Parameters["@id_evento"].Direction = ParameterDirection.Input;

                        connection.Open();
                        ;
                        if (cmd.ExecuteNonQuery() == 1)
                        {

                            return true;

                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Utils.Tools.writeLog("crearCliente", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return false; ;
            }

        }

        public Evento ObtenerEvento(Evento modEv)
        {            
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ObtenerEvento", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_evento", SqlDbType.Int).Value = modEv.id_evento;
                        cmd.Parameters["@id_evento"].Direction = ParameterDirection.Input;

                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            modEv = new Evento(reader.GetInt32(0), reader.GetInt32(5), reader.GetString(2), reader.GetInt32(6), reader.GetString(7), reader.GetString(8), reader.GetDateTime(3).ToString());
                           
                        }

                        return modEv;

                    }
                }
            }
            catch (Exception ex)
            {
                // Utils.Tools.writeLog("crearCliente", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return modEv;
            }
        }

        public Evento ObtenerEventoDet(Evento modEv)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ObtenerEvento", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_evento", SqlDbType.Int).Value = modEv.id_evento;
                        cmd.Parameters["@id_evento"].Direction = ParameterDirection.Input;

                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            modEv = new Evento(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetDateTime(3).ToString(), reader.GetString(4), reader.GetInt32(5), reader.GetString(10).ToString(), reader.GetInt32(6), reader.GetString(9),"",reader.GetString(8));

                        }

                        return modEv;

                    }
                }
            }
            catch (Exception ex)
            {
                // Utils.Tools.writeLog("crearCliente", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return modEv;
            }
        }

        public List<TipoEvento> ListaTipoEventos()
        {
            List<TipoEvento> lstTiposEventos = new List<TipoEvento>();
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListaTiposEventos", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            TipoEvento modTip = new TipoEvento(reader.GetInt32(0), reader.GetString(1), reader.GetBoolean(2));
                            lstTiposEventos.Add(modTip);

                        }

                        return lstTiposEventos;
                    }
                }
            }
            catch (Exception ex)
            {
                return lstTiposEventos;
            }
        }
    }
}
