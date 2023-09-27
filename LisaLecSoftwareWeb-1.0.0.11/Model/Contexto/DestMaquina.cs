using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Contexto
{
    public class DestMaquina
    {

        public int id_destinatario { get; set; }
        public int id_maquina { get; set; }
        public Boolean activo { get; set; }
        public String nombre { get; set; }

        public DestMaquina(int id_destinatario, int id_maquina, Boolean activo, String nombre)
        { 
            this.id_maquina = id_maquina;
            this.id_destinatario = id_destinatario;
            this.activo = activo;
            this.nombre = nombre;
        
        }

    }
}
