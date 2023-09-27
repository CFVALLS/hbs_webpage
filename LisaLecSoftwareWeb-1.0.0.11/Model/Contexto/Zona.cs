using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Contexto
{
    public  class Zona
    {
        public Int32 id_zona { get; set; }
        public string nombre { get; set; }
        public Boolean activo { get; set; }

        public Zona(Int32 id_zona, string nombre, Boolean activo) { 
            
            this.id_zona = id_zona;
            this.nombre = nombre;
            this.activo = activo;
        
        }

    }
}
