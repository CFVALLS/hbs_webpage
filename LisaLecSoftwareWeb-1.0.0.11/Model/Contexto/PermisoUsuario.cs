using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Contexto
{
    public class PermisoUsuario
    {
      
        public Int32 id_usuario { get; set; }
        public Int32 idPermiso { get; set; }
        public Int32 estado { get; set; }

        public String codUsuario { get; set; }

        public PermisoUsuario(Int32 id_usuario, Int32 idPermiso, Int32 estado, String codUsuario) { 
              
               this.id_usuario = id_usuario;
               this.idPermiso = idPermiso;
               this.estado = estado;   
               this.codUsuario = codUsuario;
             
        } 


    }
}
