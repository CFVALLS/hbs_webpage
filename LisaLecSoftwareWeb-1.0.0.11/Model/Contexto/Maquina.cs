using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Model.Contexto
{
    public class Maquina
    {
        public int id_maquina { get; set; }
        public String nombre { get; set; }
        public String url { get; set; }
        public String clave { get; set; }
        public bool activo { get; set; }

        public Maquina(int id_maquina, String nombre, String url, String clave, bool activo) { 
            this.id_maquina = id_maquina;
            this.nombre = nombre;
            this.url = url;
            this.clave = clave;
            this.activo = activo;
        }
        


    }
}
