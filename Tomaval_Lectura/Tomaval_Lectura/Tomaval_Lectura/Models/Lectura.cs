using System;
using System.Collections.Generic;
using System.Text;

namespace Tomaval_Lectura.Models
{
    public class Lectura
    {
        private int id_maquina;
        private string last_update;
        private string communication_state;
        private string unit_state;
        private string kwh_import;
        private string act_power;
        private string act_power_req;
        private string run_hours;
        private string nomin_power;
        private string engine_state;
        private string unitguid;

        public int Id_maquina { get => id_maquina; set => id_maquina = value; }
        public string Last_update { get => last_update; set => last_update = value; }
        public string Communication_state { get => communication_state; set => communication_state = value; }
        public string Unit_state { get => unit_state; set => unit_state = value; }
        public string Kwh_import { get => kwh_import; set => kwh_import = value; }
        public string Act_power { get => act_power; set => act_power = value; }
        public string Act_power_req { get => act_power_req; set => act_power_req = value; }
        public string Run_hours { get => run_hours; set => run_hours = value; }
        public string Nomin_power { get => nomin_power; set => nomin_power = value; }
        public string Engine_state { get => engine_state; set => engine_state = value; }
        public string Unitguid { get => unitguid; set => unitguid = value; }
    }
}
