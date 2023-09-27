using Model.Contexto;
using Model.Querys;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Controlador
{
	public class ControladorEventos : Configs
	{
		public String ListaEventos()
		{
			try
			{
				List<Evento> listaEventos = (List<Evento>)new ConsultasEventos().ListaEventos();

				String valHTML = " var tabla = $('#tblEventos').DataTable(); tabla.clear().draw();";

				int cont = 1;

				foreach (Evento modEv in listaEventos)
				{
					valHTML += " tabla.row.add(['',' <strong>"+ DateTime.Parse(modEv.creacion).ToString("yyyy-MM-dd hh:mm:ss") + "</strong>' , '" + modEv.id_maquina.ToString() + " | " + modEv.nomMaquina + "', '" + modEv.descripcion + "', '" + modEv.nomTipoEvento + "', '<button type=\"button\" name=\"" + modEv.id_evento.ToString() + "\" class=\"btn btn-secondary details-Editar btnEditar\"><i class=\"fas fa-edit\"></i></button> <button type=\"button\" name=\""+ modEv.id_evento.ToString() +"\" class=\"btn btn-danger details-Eliminar btnEliminar\"><i class=\"fas fa-trash-alt\"></i></button>']).draw(false); ";

				}
				return valHTML;
			}
			catch (Exception e)
			{
				return "";
			}

		}

		public String ListaEventosPorMaquina(Int32 idMaquina)
		{
			try
			{
				List<Evento> listaEventos = (List<Evento>)new ConsultasEventos().ListaEventosPorMaquina(idMaquina);

				String valHTML = " var tabla = $('#tblMaq"+ idMaquina + "').DataTable(); tabla.clear().draw();";

				int cont = 1;

				foreach (Evento modEv in listaEventos)
				{
					valHTML += " tabla.row.add(['',' <strong>" + modEv.creacion + "</strong>' , '" + modEv.nomTipoEvento + "',  '" + modEv.descripcion + "']).draw(false); ";

				}
				return valHTML;
			}
			catch (Exception e)
			{
				return "";
			}

		}

		public String ListaMaquinas(String idUsuario)
		{
			try
			{
				List<Maquina> lstMaquinas = (List<Maquina>)new ConsultasEventos().ListaMaquinas(idUsuario);

				String valHTML = " $('#lstMaq').html(''); $('#lstMaqEdit').html(''); ";

				foreach (Maquina modMaq in lstMaquinas)
				{                    
					valHTML += " $('#lstMaq').append($('<option>', { " +
									"value: '" + modMaq.id_maquina.ToString() + "'," +
									"text: '" + modMaq.nombre + "'" +
								"})).selectpicker('refresh');  ";

					valHTML += " $('#lstMaqEdit').append($('<option>', { " +
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

		public string LoadInfoEditar(string key)
		{
			Evento modEv = new Evento(Int32.Parse(key),0,"",0, "","",""); 
			try
			{
				modEv = new ConsultasEventos().ObtenerEvento(modEv);

				DateTime creacion = DateTime.Parse(modEv.creacion);

				String valHTML = " $('#codUsuarioEdit').val('" + modEv.usuEvento + "'); $('#horaEdit').val('" + modEv.hora + "'); $('#idEventEdit').val('" + key + "'); $('#lstTipoEdit').selectpicker('val', " + modEv.id_tipo_evento.ToString() + "); $('#lstMaqEdit').selectpicker('val', " + modEv.id_maquina.ToString() + "); $('#fechaActualEdit').val('" + creacion.ToString("dd-MM-yyyy") + "'); $('#detalleEdit').val('" + modEv.descripcion + "'); $('#horaEdit').val('" + creacion.ToString("hh:mm") + "')";

				return valHTML;
			}
			catch (Exception e)
			{
				return "";
			}

		}


		public bool RegistrarEvento(String det, String idMaq, String usu, String idEv, String fecha, String usuEvento) {
			try
			{
				Evento evt = new Evento(0,
										0,
										det,
										fecha,
										usu,
										Int32.Parse(idMaq),
										"",
										Int32.Parse(idEv),
										"",
										"",
										usuEvento);

				if (new ConsultasEventos().RegistrarEvento(evt))
				{
					string destinatarios = obtenerDestinatarios();
					string html = generahtml(evt.id_evento);
					new SendMail().EnviarMail(destinatarios, html);
					return true;
				}
				else {
					writelog("registrar evento fallo.", "","");
					return false;
				}
			}
			catch (Exception ex)
			{
				writelog("RegistrarEvento", ex.Message, ex.StackTrace);
				return false;
			}

		
		}

		private string obtenerDestinatarios()
		{
			List<Usuario> lstUsuarios = (List<Usuario>)new ConsultaUsuarios().ListaUsuarios();
			string maillist = "";

			foreach (Usuario usr in lstUsuarios)
			{
				if (usr.id_tipo_usuario == 1)
				{
					maillist += "".Equals(maillist) ? usr.email : "," + usr.email;
				}
			}

			return maillist;
		}

		private string generahtml(int id_evento)
		{
			Evento evt = new ConsultasEventos().ObtenerEventoDet(new Evento(id_evento,0,null, 0, null, null, null));

			string htmltext = File.ReadAllText("mail_reg_evento.html");

			htmltext = htmltext.Replace("$fecha$", evt.creacion);
			htmltext = htmltext.Replace("$unidad$", evt.nomMaquina);
			htmltext = htmltext.Replace("$usrReg$", evt.usuEvento);
			htmltext = htmltext.Replace("$tipo$", evt.nomTipoEvento);
			htmltext = htmltext.Replace("$desc$", evt.descripcion);

			return htmltext;
		}

		public bool EditarEvento(String idEvent, String det, String idMaq, String usu, String idEv, String fecha, String usuEvento)
		{
			try
			{

				if (new ConsultasEventos().EditarEvento(
														new Evento(
															 Int32.Parse(idEvent),
															 0,
															 det,
															 fecha,
															 usu,
															 Int32.Parse(idMaq),
															 "",
															 Int32.Parse(idEv),
															 "",
															 "",
															 usuEvento)
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

		public bool EliminarEvento(String idEvent)
		{
			try
			{

				if (new ConsultasEventos().EliminarEvento(
														new Evento(
															 Int32.Parse(idEvent),
															 0,
															 "",
															 "",
															 "",
															 0,
															 "",
															 0,
															 "",
															 "",""
														  )))
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

		public string ListaTipoEventos()
		{
			try
			{
				List<TipoEvento> lstTiposEventos = (List<TipoEvento>)new ConsultasEventos().ListaTipoEventos();

				String valHTML = " $('#lstTipo').html(''); $('#lstTipoEdit').html(''); ";

				foreach (TipoEvento modTip in lstTiposEventos)
				{
					valHTML += " $('#lstTipo').append($('<option>', { " +
									"value: '" + modTip.id_tipo_evento.ToString() + "'," +
									"text: '" + modTip.nombre + "'" +
								"})).selectpicker('refresh');  ";
					
					valHTML += " $('#lstTipoEdit').append($('<option>', { " +
									"value: '" + modTip.id_tipo_evento.ToString() + "'," +
									"text: '" + modTip.nombre + "'" +
								"})).selectpicker('refresh');  ";
					
				}
				return valHTML;
			}
			catch (Exception e)
			{
				return "";
			}
		}
	}
}
