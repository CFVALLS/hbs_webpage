using System;

namespace Model.Contexto
{
    public class Usuario
    {

        public int id_usuario { get; set; }
        public String usuario { get; set; }
        public String clave { get; set; }
        public bool activo { get; set; }
        public String creacion { get; set; }
        public String usuario_crea { get; set; }
        public String email { get; set; }
        
        public int id_tipo_usuario { get; set; }

        public Usuario(int id_usuario, string usuario, string clave, bool activo, string creacion, string usuario_crea, string email, int id_tipo_usuario)
        {
            this.id_usuario = id_usuario;
            this.usuario = usuario;
            this.clave = clave;
            this.activo = activo;
            this.creacion = creacion;
            this.usuario_crea = usuario_crea;
            this.email = email;
            this.id_tipo_usuario = id_tipo_usuario;
        }

        public Usuario() { 
        
        }





    }
}
