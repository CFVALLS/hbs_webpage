using Model.Conexion;
using Model.Contexto;
using Model.Querys;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class ControladorDestinatarios
    {
        public String ListaDestinatarios()
        {
            try
            {

                List<Destinatario> listaDest = (List<Destinatario>)new ConsultasDestinatarios().ListaDestinatarios();
                
                String valHTML = " var tabla = $('#tblDestinatarios').DataTable(); tabla.clear().draw();";

                int cont = 1;

                foreach (Destinatario modDes in listaDest)
                {
                    DestZona modDestZon = new DestZona(modDes.id_destinatario, 0, false,"");
                    List<DestZona> listaDestZon= (List<DestZona>)new ConsultasDestinatarios().ObtenerZonasAsignadasDet(modDestZon);
                    String valHTML_lst = "";
                    foreach (DestZona modDesZonDet in listaDestZon)
                    {
                        valHTML_lst += " " + modDesZonDet.nombre + " -";
                    }
                    valHTML += " tabla.row.add(['',' <strong>" + modDes.mail + "</strong>' , '" + modDes.nombre.ToString() +" " + modDes.apellido.ToString() + "','" + valHTML_lst.TrimEnd('-') + "', '<button type=\"button\" name=\"" + modDes.id_destinatario.ToString() + "\" class=\"btn btn-secondary details-Editar btnEditar\"><i class=\"fas fa-edit\"></i></button> <button type=\"button\" name=\"" + modDes.id_destinatario.ToString() + "\" class=\"btn btn-danger details-Eliminar btnEliminar\"><i class=\"fas fa-trash-alt\"></i></button>']).draw(false); ";

                }
                return valHTML;
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public String ListaMaquinas()
        {
            try
            {
                List<Maquina> lstMaquinas = (List<Maquina>)new ConsultasDestinatarios().ListaMaquinas();

                String valHTML = " $('#lstAsigMaqEdit').html(''); ";

                foreach (Maquina modMaq in lstMaquinas)
                {
                    valHTML += " $('#lstAsigMaqEdit').append($('<option>', { " +
                                    "value: '" + modMaq.id_maquina.ToString() + "'," +
                                    "text: '" + modMaq.nombre + "'" +
                                "})).selectpicker('refresh');  ";
                   
                }
                return valHTML;
            }
            catch (Exception e)
            {
                return "";
            }

        }

        public bool RegistrarDestinatario(String cor, String nom, String ape)
        {
            try
            {

                if (new ConsultasDestinatarios().RegistrarDestinatario(
                                                        new Destinatario(0,
                                                             cor,
                                                             nom,
                                                             ape,                                                         
                                                             true,
                                                             "")
                                                          ))
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public bool EditarDestinatario(String idD, String cor, String nom, String ape, String usu)
        {
            try
            {

                if (new ConsultasDestinatarios().EditarDestinatario(
                                                        new Destinatario(Convert.ToInt32(idD),
                                                             cor,
                                                             nom,
                                                             ape,
                                                             true,
                                                             "")
                                                          ))
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public string LoadInfoEditar(string key)
        {
            Destinatario modDes = new Destinatario(Int32.Parse(key),"","","");
            DestZona modDestZon = new DestZona(Convert.ToInt32(key), 0, false, "");

            try
            {

                modDes = new ConsultasDestinatarios().ObtenerDestinatario(modDes);

                List<DestZona> listaDest = (List<DestZona>)new ConsultasDestinatarios().ObtenerZonasAsignadas(modDestZon);

                String valHTML_lst = "";
                foreach (DestZona modDesZona in listaDest)
                {
                    valHTML_lst += "'"+ modDesZona.id_zona.ToString() + "',";
                }
               
                String valHTML =" $('#idDestinatarioEdit').val('" + key + "');  $('#correoEdit').val('" + modDes.mail + "'); $('#nombreEdit').val('" + modDes.nombre + "'); $('#apellidoEdit').val('" + modDes.apellido + "');";

                valHTML += " $('#lstAsigMaqEdit').selectpicker('val', [" + valHTML_lst.TrimEnd(',') + "]); ";


                return valHTML;
            }
            catch (Exception e)
            {
                return "";
            }

        }        

        public bool EliminarDestinatario(String idDestinatario)
        {
            try
            {

                if (new ConsultasDestinatarios().EliminarDestinatario( new Destinatario(
                                                                    Int32.Parse(idDestinatario), 
                                                                    "", 
                                                                    "", 
                                                                    "")))
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        /*    ZONAS      */

        public String ListaZonas()
        {
            try
            {
                List<Zona> lstZonas = (List<Zona>)new ConsultasDestinatarios().ListaZonas();

                String valHTML = " $('#lstAsigMaqEdit').html(''); ";

                foreach (Zona modZon in lstZonas)
                {
                    valHTML += " $('#lstAsigMaqEdit').append($('<option>', { " +
                                    "value: '" + modZon.id_zona.ToString() + "'," +
                                    "text: '" + modZon.nombre + "'" +
                                "})).selectpicker('refresh');  ";

                }
                return valHTML;
            }
            catch (Exception e)
            {
                return "";
            }

        }

        public void AsignarZona(string idD, string[] lstMqs)
        {
            try
            {
                DestZona modDestZon = new DestZona(Convert.ToInt32(idD), 0, false, "");

                new ConsultasDestinatarios().EliminarAsignacionZonas(modDestZon);

                for (int i = 0; i < lstMqs.Length; i++)
                {
                    new ConsultasDestinatarios().RegistrarAsignacionZona(new DestZona(Convert.ToInt32(idD),
                                                                                Convert.ToInt32(lstMqs[i]),
                                                                                true, ""
                                                                            ));
                }

            }
            catch (Exception es)
            {

                throw;
            }
        }












    }
}
