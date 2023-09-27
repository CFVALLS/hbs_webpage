using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Model.Contexto
{
    public  class Evento
    {
        public int id_evento { get; set; }
        public int id_informe { get; set; }
        public String descripcion { get; set; }
        public String creacion { get; set; }
        public String usuario { get; set; }
        public int id_maquina { get; set; }

        public int id_tipo_evento { get; set; }

        public String hora { get; set; }

        public String usuEvento { get; set; }

        /*PARAMETROS ADICIONALES DE COMPLEMENTO*/

        public String nomMaquina { get; set; }

        public String nomTipoEvento { get; set; }


        public Evento(int id_evento,
                      int id_informe,
                      String descripcion,
                      String creacion,
                      String usuario,
                      int id_maquina,
                      String nomMaquina,
                      int id_tipo_evento,
                      string nomTipoEvento,
                      string hora,
                      string usuEvento)
        {
            this.id_evento = id_evento;
            this.id_informe = id_informe;
            this.descripcion = descripcion;
            this.creacion = creacion;
            this.usuario = usuario;
            this.id_maquina = id_maquina;
            this.nomMaquina = nomMaquina;
            this.id_tipo_evento = id_tipo_evento;
            this.nomTipoEvento = nomTipoEvento;
            this.hora = hora;
            this.usuEvento = usuEvento; 
        }

        public Evento(int id_evento, int id_maquina, String descripcion, int id_tipo_evento, String hora, string usuEvento, string creacion)
        { 
            this.id_evento= id_evento;
            this.id_maquina = id_maquina;
            this.descripcion = descripcion;
            this.id_tipo_evento=id_tipo_evento;
            this.hora = hora;
            this.usuEvento = usuEvento;
            this.creacion = creacion;

        }

    }
}
