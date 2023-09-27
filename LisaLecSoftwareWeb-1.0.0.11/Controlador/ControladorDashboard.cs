using Model.Contexto;
using Model.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
	public class ControladorDashboard
	{
		public String ObtenerUltimaLecturaMaquina_1()
		{
			String valHTML = "";

			try
			{
				String pReal = " ";
				String pNominal = " ";
				String pRealTag = " ";

				Lectura modLec = new ConsultasDashboard().ObtenerUltimaLecturaMaquina(new Lectura(0, 1, "", "", "", "", "", "", "", "", "", ""));

				valHTML += " $('#nomMaq1').html('" + modLec.nombre + "');  $('#actPower1').val('" + modLec.act_power + "'); $('#actPpowerReq1').val('" + modLec.act_power_req + "'); $('#norminPower1').val('" + modLec.nomin_power + "'); ";

				if (modLec.engine_state.ToUpper().Equals("RUNNING") || modLec.engine_state.ToUpper().Equals("LOADED") || modLec.engine_state.ToUpper().Equals("READY"))
				{
					valHTML += " $('#engineState').addClass('badge-success'); $('#engineStateLabel1').html('" + modLec.engine_state.ToUpper() + "');";
				}
				else
				{
					if (modLec.engine_state.ToUpper().Equals("STOP") || modLec.engine_state.ToUpper().Equals("NOTREADY"))
					{
						valHTML += " $('#engineState').addClass('badge-danger'); $('#engineStateLabel1').html('" + modLec.engine_state.ToUpper() + "');";
					}
					else
					{
						valHTML += " $('#engineState').addClass('badge-warning'); $('#engineStateLabel1').html('" + modLec.engine_state.ToUpper() + "');";
					}

				}

				if (modLec.unit_state.ToUpper().Equals("READY") || modLec.unit_state.ToUpper().Equals("OPERATIONAL") || modLec.unit_state.ToUpper().Equals("LOADED"))
				{
					valHTML += " $('#unitState').addClass('badge-success'); $('#unitStateLabel1').html('" + modLec.unit_state.ToUpper() + "');";
				}
				else
				{
					if (modLec.unit_state.ToUpper().Equals("SHUTDOWN") || modLec.unit_state.ToUpper().Equals("NOCOMMUNICATION"))
					{
						valHTML += " $('#unitState').addClass('badge-danger'); $('#unitStateLabel1').html('" + modLec.unit_state.ToUpper() + "');";
					}
					else
					{
						valHTML += " $('#unitState').addClass('badge-warning'); $('#unitStateLabel1').html('" + modLec.unit_state.ToUpper() + "');";
					}

				}

				if (modLec.comunication_state.ToUpper().Equals("ONLINE"))
				{
					valHTML += " $('#comState').addClass('badge-success');  $('#comStateLabel1').html('" + modLec.comunication_state.ToUpper() + "');";
				}
				else
				{
					if (modLec.comunication_state.ToUpper().Equals("ERROR"))
					{
						valHTML += " $('#comState').addClass('badge-danger');  $('#comStateLabel1').html('" + modLec.comunication_state.ToUpper() + "');";
					}
					else
					{
						valHTML += " $('#comState').addClass('badge-warning');  $('#comStateLabel1').html('" + modLec.comunication_state.ToUpper() + "');";
					}

				}

				valHTML += " $('#Kwh1').val('" + modLec.kwh_import + "');  $('#runHours1').val('" + modLec.run_hours + "'); $('#lastUpdate1').val('" + modLec.last_update + "');  ";

				valHTML += " $('#nomMaq1Modal').html('" + modLec.nombre + "'); $('#pr1Modal').val('" + modLec.act_power + "'); $('#pn1Modal').val('" + modLec.nomin_power + "'); ";

				valHTML += new ControladorEventos().ListaEventosPorMaquina(1);

				List<Lectura> lstLecturas = (List<Lectura>)new ConsultasDashboard().ObtenerUltima10LecturaMaquina(new Lectura(0, 1, "", "", "", "", "", "", "", "", "", ""));


				foreach (Lectura modEv in lstLecturas)
				{
					pReal += modEv.act_power + ", ";
					pRealTag += " '',";
					pNominal += modEv.nomin_power + ", ";
				}

				pNominal = pNominal.TrimEnd(' ');
				pNominal = pNominal.TrimEnd(',');

				pReal = pReal.TrimEnd(' ');
				pReal = pReal.TrimEnd(',');
				pRealTag = pRealTag.TrimEnd(' ');
				pRealTag = pRealTag.TrimEnd(',');
				valHTML += " var ctx = document.getElementById('myChart').getContext('2d'); var myChart_ = new Chart(ctx, { type: 'line', data: { labels: [" + pRealTag + "],   datasets: [{ data: [" + pReal + "], label: 'Real', borderColor: '#5DDC4B', backgroundColor: 'rgba(255, 99, 132, 0.2)', fill: false }, { data: [" + pNominal + "], label: 'Nominal', borderColor: '#4B6ADC', fill: false }]},  options: {    title: {    display: true,      text: ''   }  }}); ";


				pReal = " ";
				pNominal = " ";
				pRealTag = " ";

				return valHTML;

			}
			catch (Exception eee)
			{
				return valHTML;
			}
		}


		public String ObtenerUltimaLecturaMaquina_3()
		{
			String valHTML = "";

			try
			{
				String pReal = " ";
				String pNominal = " ";
				String pRealTag = " ";
				String pNominalTag = " ";


				Lectura modLec = new ConsultasDashboard().ObtenerUltimaLecturaMaquina(new Lectura(0, 3, "", "", "", "", "", "", "", "", "", ""));

				valHTML += " $('#nomMaq2').html('" + modLec.nombre + "');  $('#actPower2').val('" + modLec.act_power + "'); $('#actPpowerReq2').val('" + modLec.act_power_req + "'); $('#norminPower2').val('" + modLec.nomin_power + "'); ";

				if (modLec.engine_state.ToUpper().Equals("RUNNING") || modLec.engine_state.ToUpper().Equals("LOADED") || modLec.engine_state.ToUpper().Equals("READY"))
				{
					valHTML += " $('#engineState2').addClass('badge-success');   $('#engineState2Label1').html('" + modLec.engine_state.ToUpper() + "');";
				}
				else
				{
					if (modLec.engine_state.ToUpper().Equals("STOP") || modLec.engine_state.ToUpper().Equals("NOTREADY"))
					{
						valHTML += " $('#engineState2').addClass('badge-danger');   $('#engineState2Label1').html('" + modLec.engine_state.ToUpper() + "');";
					}
					else
					{
						valHTML += " $('#engineState2').addClass('badge-warning');   $('#engineState2Label1').html('" + modLec.engine_state.ToUpper() + "');";
					}

				}

				if (modLec.unit_state.ToUpper().Equals("READY") || modLec.unit_state.ToUpper().Equals("OPERATIONAL") || modLec.unit_state.ToUpper().Equals("LOADED"))
				{
					valHTML += " $('#unitState2').addClass('badge-success'); $('#unitState2Label1').html('" + modLec.unit_state.ToUpper() + "');";
				}
				else
				{
					if (modLec.unit_state.ToUpper().Equals("SHUTDOWN") || modLec.unit_state.ToUpper().Equals("NOCOMMUNICATION"))
					{
						valHTML += " $('#unitState2').addClass('badge-danger'); $('#unitState2Label1').html('" + modLec.unit_state.ToUpper() + "');";
					}
					else
					{
						valHTML += " $('#unitState2').addClass('badge-warning'); $('#unitState2Label1').html('" + modLec.unit_state.ToUpper() + "'); ";
					}

				}

				if (modLec.comunication_state.ToUpper().Equals("ONLINE"))
				{
					valHTML += " $('#comState2').addClass('badge-success'); $('#comState2Label1').html('" + modLec.comunication_state.ToUpper() + "');  ";
				}
				else
				{
					if (modLec.comunication_state.ToUpper().Equals("ERROR"))
					{
						valHTML += " $('#comState2').addClass('badge-danger'); $('#comState2Label1').html('" + modLec.comunication_state.ToUpper() + "');";
					}
					else
					{
						valHTML += " $('#comState2').addClass('badge-warning'); $('#comState2Label1').html('" + modLec.comunication_state.ToUpper() + "');";
					}

				}

				valHTML += " $('#Kwh2').val('" + modLec.kwh_import + "');  $('#runHours2').val('" + modLec.run_hours + "'); $('#lastUpdate2').val('" + modLec.last_update + "');  ";

				valHTML += " $('#nomMaq3Modal').html('" + modLec.nombre + "'); $('#pr3Modal').val('" + modLec.act_power + "'); $('#pn3Modal').val('" + modLec.nomin_power + "'); ";

				valHTML += new ControladorEventos().ListaEventosPorMaquina(3);

				List<Lectura> lstLecturas = (List<Lectura>)new ConsultasDashboard().ObtenerUltima10LecturaMaquina(new Lectura(0, 3, "", "", "", "", "", "", "", "", "", ""));

				foreach (Lectura modEv in lstLecturas)
				{
					pReal += modEv.act_power + ", ";
					pRealTag += " '',";
					pNominal += modEv.nomin_power + ", ";
				}

				pNominal = pNominal.TrimEnd(' ');
				pNominal = pNominal.TrimEnd(',');

				pReal = pReal.TrimEnd(' ');
				pReal = pReal.TrimEnd(',');
				pRealTag = pRealTag.TrimEnd(' ');
				pRealTag = pRealTag.TrimEnd(',');

				valHTML += "var ctx3 = document.getElementById('myChart3').getContext('2d'); var myChart3_ = new Chart(ctx3, {  type: 'line',  data: {  labels: [" + pRealTag + "],   datasets: [{ data: [" + pReal + "], label: 'Real', borderColor: '#5DDC4B', backgroundColor: 'rgba(255, 99, 132, 0.2)', fill: false }, { data: [" + pNominal + "], label: 'Nominal', borderColor: '#4B6ADC', fill: false }]},  options: {    title: {    display: true,      text: ''   }  }}); ";


				pReal = " ";
				pNominal = " ";
				pRealTag = " ";

				return valHTML;

			}
			catch (Exception eee)
			{
				return valHTML;
			}
		}

		public String ObtenerUltimaLecturaMaquina_4()
		{
			String valHTML = "";

			try
			{
				String pReal = " ";
				String pNominal = " ";
				String pRealTag = " ";

				Lectura modLec = modLec = new ConsultasDashboard().ObtenerUltimaLecturaMaquina(new Lectura(0, 4, "", "", "", "", "", "", "", "", "", ""));

				valHTML += " $('#nomMaq3').html('" + modLec.nombre + "');  $('#actPower3').val('" + modLec.act_power + "'); $('#actPpowerReq3').val('" + modLec.act_power_req + "'); $('#norminPower3').val('" + modLec.nomin_power + "'); ";

				if (modLec.engine_state.ToUpper().Equals("RUNNING") || modLec.engine_state.ToUpper().Equals("LOADED") || modLec.engine_state.ToUpper().Equals("READY"))
				{
					valHTML += " $('#engineState3').addClass('badge-success'); $('#engineState3Label1').html('" + modLec.engine_state.ToUpper() + "');";
				}
				else
				{
					if (modLec.engine_state.ToUpper().Equals("STOP") || modLec.engine_state.ToUpper().Equals("NOTREADY"))
					{
						valHTML += " $('#engineState3').addClass('badge-danger'); $('#engineState3Label1').html('" + modLec.engine_state.ToUpper() + "');";
					}
					else
					{
						valHTML += " $('#engineState3').addClass('badge-warning'); $('#engineState3Label1').html('" + modLec.engine_state.ToUpper() + "');";
					}

				}

				if (modLec.unit_state.ToUpper().Equals("READY") || modLec.unit_state.ToUpper().Equals("OPERATIONAL") || modLec.unit_state.ToUpper().Equals("LOADED"))
				{
					valHTML += " $('#unitState3').addClass('badge-success'); $('#unitState3Label1').html('" + modLec.unit_state.ToUpper() + "');";
				}
				else
				{
					if (modLec.unit_state.ToUpper().Equals("SHUTDOWN") || modLec.unit_state.ToUpper().Equals("NOCOMMUNICATION"))
					{
						valHTML += " $('#unitState3').addClass('badge-danger'); $('#unitState3Label1').html('" + modLec.unit_state.ToUpper() + "');";
					}
					else
					{
						valHTML += " $('#unitState3').addClass('badge-warning'); $('#unitState3Label1').html('" + modLec.unit_state.ToUpper() + "');";
					}

				}

				if (modLec.comunication_state.ToUpper().Equals("ONLINE"))
				{
					valHTML += " $('#comState3').addClass('badge-success'); $('#comState3Label1').html('" + modLec.comunication_state.ToUpper() + "');";
				}
				else
				{
					if (modLec.comunication_state.ToUpper().Equals("ERROR"))
					{
						valHTML += " $('#comState3').addClass('badge-danger'); $('#comState3Label1').html('" + modLec.comunication_state.ToUpper() + "');";
					}
					else
					{
						valHTML += " $('#comState3').addClass('badge-warning'); $('#comState3Label1').html('" + modLec.comunication_state.ToUpper() + "');";
					}

				}

				valHTML += " $('#Kwh3').val('" + modLec.kwh_import + "');  $('#runHours3').val('" + modLec.run_hours + "'); $('#lastUpdate3').val('" + modLec.last_update + "');  ";

				valHTML += " $('#nomMaq4Modal').html('" + modLec.nombre + "'); $('#pr4Modal').val('" + modLec.act_power + "'); $('#pn4Modal').val('" + modLec.nomin_power + "'); ";

				valHTML += new ControladorEventos().ListaEventosPorMaquina(4);

				List<Lectura> lstLecturas = (List<Lectura>)new ConsultasDashboard().ObtenerUltima10LecturaMaquina(new Lectura(0, 4, "", "", "", "", "", "", "", "", "", ""));


				foreach (Lectura modEv in lstLecturas)
				{
					pReal += modEv.act_power + ", ";
					pRealTag += " '',";
					pNominal += modEv.nomin_power + ", ";
				}

				pNominal = pNominal.TrimEnd(' ');
				pNominal = pNominal.TrimEnd(',');

				pReal = pReal.TrimEnd(' ');
				pReal = pReal.TrimEnd(',');
				pRealTag = pRealTag.TrimEnd(' ');
				pRealTag = pRealTag.TrimEnd(',');
				valHTML += "var ctx4 = document.getElementById('myChart4').getContext('2d'); var myChart4_ = new Chart(ctx4, {  type: 'line',  data: {  labels: [" + pRealTag + "],   datasets: [{ data: [" + pReal + "], label: 'Real', borderColor: '#5DDC4B', backgroundColor: 'rgba(255, 99, 132, 0.2)', fill: false }, { data: [" + pNominal + "], label: 'Nominal', borderColor: '#4B6ADC', fill: false }]},  options: {    title: {    display: true,      text: ''   }  }}); ";

				pReal = " ";
				pNominal = " ";
				pRealTag = " ";
				return valHTML;

			}
			catch (Exception eee)
			{
				return valHTML;
			}
		}

		public String ListaEventosModal()
		{
			try
			{
				List<Evento> listaEventos = (List<Evento>)new ConsultasEventos().ListaEventos();

				String valHTML = " var tabla = $('#tblEventos').DataTable(); tabla.clear().draw();";

				int cont = 1;

				foreach (Evento modEv in listaEventos)
				{
					valHTML += " tabla.row.add(['',' <strong>" + modEv.creacion + "</strong>' , '" + modEv.id_maquina.ToString() + " | " + modEv.nomMaquina + "', '" + modEv.descripcion + "', '" + modEv.nomTipoEvento + "', '<button type=\"button\" name=\"" + modEv.id_evento.ToString() + "\" class=\"btn btn-secondary details-Editar btnEditar\"><i class=\"fas fa-edit\"></i></button> <button type=\"button\" name=\"" + modEv.id_evento.ToString() + "\" class=\"btn btn-danger details-Eliminar btnEliminar\"><i class=\"fas fa-trash-alt\"></i></button>']).draw(false); ";

				}
				return valHTML;
			}
			catch (Exception e)
			{
				return "";
			}

		}

		public bool PoseePermiso(int idPermiso, string codUsuario)
		{
			try
			{

				return new ClasesGenerales().PoseePermiso(new PermisoUsuario(0, idPermiso, 1, codUsuario));
			}
			catch (Exception e)
			{
				return false;
			}
		}
	}
}
