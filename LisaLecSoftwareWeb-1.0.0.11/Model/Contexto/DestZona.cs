using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Contexto
{
    public class DestZona
    {
        public int id_destinatario { get; set; }
        public int id_zona { get; set; }
        public Boolean activo { get; set; }
        public String nombre { get; set; }

        public DestZona(int id_destinatario, int id_zona, Boolean activo, String nombre)
        {
            this.id_zona = id_zona;
            this.id_destinatario = id_destinatario;
            this.activo = activo;
            this.nombre = nombre;

        }

    }
}
