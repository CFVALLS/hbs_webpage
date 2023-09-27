using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Contexto
{
    public class Destinatario
    {

        public int id_destinatario { get; set; }
        public String mail { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public bool activo { get; set; }
        public String creacion { get; set; }

        public Destinatario(int id_destinatario, String mail, String nombre, String apellido, bool activo, String creacion) {
            this.id_destinatario = id_destinatario;
            this.mail = mail;
            this.nombre = nombre;
            this.apellido = apellido;
            this.activo = activo;
            this.creacion = creacion;


        }

        public Destinatario(int id_destinatario, String mail, String nombre, String apellido)
        {
            this.id_destinatario = id_destinatario;
            this.mail = mail;
            this.nombre = nombre;
            this.apellido = apellido;
            this.activo = activo;
            this.creacion = creacion;


        }


    }
}
