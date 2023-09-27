using Newtonsoft.Json;
using System;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tomaval_Lectura
{
    class Program
    {
        static async Task Main(string[] args)
        {
            
            Utils.ComapApi comapApi = new Utils.ComapApi();

            string comaptoken = Utils.DBRequest.ValidaToken().Tables[0].Rows[0][0].ToString();

            if (comaptoken == "expired")
            {
                string token = await comapApi.Autenticar();
                if (!"".Equals(token))
                {
                    Utils.DBRequest.ActualizaToken(token);
                }
            }
            else
            {
                comapApi.token = comaptoken;
            }

            //conectarse para obtener ips de maquinas
            DataSet maquinas = Utils.DBRequest.Maquinalistar();

            foreach (DataRow maquina in maquinas.Tables[0].Rows)
            {
                Models.Lectura lectura = new Models.Lectura();
                lectura.Unitguid = maquina["unitguid"].ToString();
                lectura.Id_maquina = int.Parse(maquina["id_maquina"].ToString());
                //LLamada a api
                if (!"".Equals(lectura.Unitguid) && !"0".Equals(lectura.Unitguid))
                {
                    if (await comapApi.GetUnitValues(lectura))
                        //Registrar en base de datos
                        Utils.DBRequest.crearLectura(lectura);
                }
            }

        }

    }
}
