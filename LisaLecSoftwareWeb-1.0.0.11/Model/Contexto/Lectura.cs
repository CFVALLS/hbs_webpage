using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Contexto
{
    public class Lectura
    {

        public Int32 id_lectura { get; set; }
        public Int32 id_maquina { get; set; }
        public String last_update { get; set; }
        public String communication_state { get; set; }
        public String unit_state { get; set; }
        public String kwh_import { get; set; }
        public String act_power { get; set; }
        public String act_power_req { get; set; }
        public String run_hours { get; set; }
        public String nomin_power { get; set; }
        public String engine_state { get; set; }
        public String creation { get; set; }

        public String comunication_state { get; set; }

        public String nombre { get; set; }

        public Lectura(Int32 id_lectura, Int32 id_maquina, String nombre, String act_power,
                              String act_power_req, String nomin_power, String engine_state,
                              String unit_state, String kwh_import, String run_hours, String last_update, String comunication_state)
        {
            this.id_lectura = id_lectura;
            this.id_maquina = id_maquina;
            this.nombre = nombre;

            this.act_power = "".Equals(act_power) ? "" : int.Parse(act_power).ToString("N0", new CultureInfo("es-CL"));
            this.act_power_req = "".Equals(act_power_req) ? "" : int.Parse(act_power_req).ToString("N0", new CultureInfo("es-CL"));
            this.nomin_power = "".Equals(nomin_power) ? "" : int.Parse(nomin_power).ToString("N0", new CultureInfo("es-CL"));
            this.engine_state = engine_state;


            this.unit_state = unit_state;
            this.kwh_import = "".Equals(kwh_import) ? "" : int.Parse(kwh_import).ToString("N0", new CultureInfo("es-CL"));
            this.run_hours = "".Equals(run_hours) ? "" : int.Parse(run_hours).ToString("N0", new CultureInfo("es-CL"));
            this.last_update = last_update;
            this.comunication_state = comunication_state;

        }
    



    }
}
