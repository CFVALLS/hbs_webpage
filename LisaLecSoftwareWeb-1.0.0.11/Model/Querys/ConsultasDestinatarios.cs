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
    public class ConsultasDestinatarios
    {

        public bool RegistrarDestinatario(Destinatario modDes)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_RegDestinatario", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@mail", SqlDbType.VarChar, 50).Value = modDes.mail;
                        cmd.Parameters["@mail"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = modDes.nombre;
                        cmd.Parameters["@nombre"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = modDes.apellido;
                        cmd.Parameters["@apellido"].Direction = ParameterDirection.Input;

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

        public bool EditarDestinatario(Destinatario modDes)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_EditarDestinatario", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_destinatario", SqlDbType.Int).Value = modDes.id_destinatario;
                        cmd.Parameters["@id_destinatario"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@mail", SqlDbType.VarChar, 50).Value = modDes.mail;
                        cmd.Parameters["@mail"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = modDes.nombre;
                        cmd.Parameters["@nombre"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = modDes.apellido;
                        cmd.Parameters["@apellido"].Direction = ParameterDirection.Input;

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

        public List<Destinatario> ListaDestinatarios()
        {
            List<Destinatario> listaDest = new List<Destinatario>();
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListaDestinatarios", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            Destinatario modDes = new Destinatario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2).ToString(),
                                                        reader.GetString(3), reader.GetBoolean(4), reader.GetDateTime(5).ToString());
                            listaDest.Add(modDes);
                        }

                        return listaDest;

                    }
                }
            }
            catch (Exception ex)
            {
                // Utils.Tools.writeLog("crearCliente", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return listaDest;
            }
        }

        public Destinatario ObtenerDestinatario(Destinatario modDes)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ObtenerDestinatario", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_destinatario", SqlDbType.Int).Value = modDes.id_destinatario;
                        cmd.Parameters["@id_destinatario"].Direction = ParameterDirection.Input;

                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            modDes = new Destinatario(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));

                        }

                        return modDes;

                    }
                }
            }
            catch (Exception ex)
            {
                // Utils.Tools.writeLog("crearCliente", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return modDes;
            }
        }

        public List<Maquina> ListaMaquinas()
        {
            List<Maquina> lstMaquina = new List<Maquina>();
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListaMaquinas", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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

        public void EliminarAsignacionMaquinas(DestMaquina modDestMaq)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_EliminarMaquinasDestinatario", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_destinatario", SqlDbType.Int).Value = modDestMaq.id_destinatario;
                        cmd.Parameters["@id_destinatario"].Direction = ParameterDirection.Input;


                        connection.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public void RegistrarAsignacionMaquina(DestMaquina modDesMaq)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_RegistrarAsignacionMaquina", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_destinatario", SqlDbType.Int).Value = modDesMaq.id_destinatario;
                        cmd.Parameters["@id_destinatario"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@id_maquina", SqlDbType.Int).Value = modDesMaq.id_maquina;
                        cmd.Parameters["@id_maquina"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@activo", SqlDbType.Int).Value = modDesMaq.activo;
                        cmd.Parameters["@activo"].Direction = ParameterDirection.Input;

                        connection.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public List<DestMaquina> ObtenerMaquinasAsignadas(DestMaquina modDestMaq)
        {
            List<DestMaquina> listaDest = new List<DestMaquina>();
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListaMaquinasAsignadas", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_destinatario", SqlDbType.Int).Value = modDestMaq.id_destinatario;
                        cmd.Parameters["@id_destinatario"].Direction = ParameterDirection.Input;

                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            DestMaquina modDes = new DestMaquina(reader.GetInt32(0), reader.GetInt32(1), reader.GetBoolean(2),"");
                            listaDest.Add(modDes);
                        }

                        return listaDest;

                    }
                }
            }
            catch (Exception ex)
            {
                // Utils.Tools.writeLog("crearCliente", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return listaDest;
            }
        }

        public List<DestMaquina> ObtenerMaquinasAsignadasDet(DestMaquina modDestMaq)
        {
            List<DestMaquina> listaDest = new List<DestMaquina>();
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListaMaquinasAsignadasDetalle", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_destinatario", SqlDbType.Int).Value = modDestMaq.id_destinatario;
                        cmd.Parameters["@id_destinatario"].Direction = ParameterDirection.Input;

                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            DestMaquina modDes = new DestMaquina(reader.GetInt32(0), reader.GetInt32(1), reader.GetBoolean(2), reader.GetString(3));
                            listaDest.Add(modDes);
                        }

                        return listaDest;

                    }
                }
            }
            catch (Exception ex)
            {
                // Utils.Tools.writeLog("crearCliente", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return listaDest;
            }
        }

        public bool EliminarDestinatario(Destinatario modDes)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_EliminarDestinatario", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_destinatario", SqlDbType.Int).Value = modDes.id_destinatario;
                        cmd.Parameters["@id_destinatario"].Direction = ParameterDirection.Input;

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                // Utils.Tools.writeLog("crearCliente", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return false; ;
            }

        }


        /*  ZONAS  */

        public List<Zona> ListaZonas()
        {
            List<Zona> lstZonas = new List<Zona>();
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListaZonas", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            Zona modZon = new Zona(reader.GetInt32(0), reader.GetString(1),
                                                            reader.GetBoolean(2) );
                            lstZonas.Add(modZon);

                        }

                        return lstZonas;
                    }
                }
            }
            catch (Exception ex)
            {
                return lstZonas;
            }

        }

        public List<DestZona> ObtenerZonasAsignadasDet(DestZona modDesZon)
        {
            List<DestZona> lstDestZonas = new List<DestZona>();
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListaZonasAsignadasDetalle", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_destinatario", SqlDbType.Int).Value = modDesZon.id_destinatario;
                        cmd.Parameters["@id_destinatario"].Direction = ParameterDirection.Input;

                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            DestZona modDes = new DestZona(reader.GetInt32(0), reader.GetInt32(1), reader.GetBoolean(2), reader.GetString(3));
                            lstDestZonas.Add(modDes);
                        }

                        return lstDestZonas;

                    }
                }
            }
            catch (Exception ex)
            {
                // Utils.Tools.writeLog("crearCliente", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return lstDestZonas;
            }
        }

        public void EliminarAsignacionZonas(DestZona modDesZon)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_EliminarZonasDestinatario", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_destinatario", SqlDbType.Int).Value = modDesZon.id_destinatario;
                        cmd.Parameters["@id_destinatario"].Direction = ParameterDirection.Input;


                        connection.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void RegistrarAsignacionZona(DestZona modDesZon)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_RegistrarAsignacionZona", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_destinatario", SqlDbType.Int).Value = modDesZon.id_destinatario;
                        cmd.Parameters["@id_destinatario"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@id_zona", SqlDbType.Int).Value = modDesZon.id_zona;
                        cmd.Parameters["@id_zona"].Direction = ParameterDirection.Input;

                        cmd.Parameters.Add("@activo", SqlDbType.Int).Value = modDesZon.activo;
                        cmd.Parameters["@activo"].Direction = ParameterDirection.Input;

                        connection.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public List<DestZona> ObtenerZonasAsignadas(DestZona modDesZon)
        {
            List<DestZona> listaDest = new List<DestZona>();
            try
            {
                using (SqlConnection connection = new SqlConnection(new Conectar().CadenaCon("PROD")))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_ListaZonasAsignadas", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@id_destinatario", SqlDbType.Int).Value = modDesZon.id_destinatario;
                        cmd.Parameters["@id_destinatario"].Direction = ParameterDirection.Input;

                        connection.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            DestZona modDes = new DestZona(reader.GetInt32(0), reader.GetInt32(1), reader.GetBoolean(2), "");
                            listaDest.Add(modDes);
                        }

                        return listaDest;

                    }
                }
            }
            catch (Exception ex)
            {
                // Utils.Tools.writeLog("crearCliente", "Error Request: " + ex.Message + ".", ex.StackTrace);
                return listaDest;
            }
        }

    }




}
