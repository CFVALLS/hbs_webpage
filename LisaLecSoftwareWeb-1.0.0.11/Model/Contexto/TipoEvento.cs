using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Contexto
{
    public class TipoEvento
    {
        public Int32 id_tipo_evento { get; set; }
        public String nombre { get; set; }
        public Boolean activo { get; set; }

        public TipoEvento(Int32 id_tipo_evento, String nombre, Boolean activo) {

            this.id_tipo_evento = id_tipo_evento;
            this.nombre = nombre;
            this.activo = activo;      
            
        } 

    }
}
