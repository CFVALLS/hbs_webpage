using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Tomaval_Lectura.Utils
{
    public class ComapApi
    {
        private string ComapUser = ConfigurationManager.AppSettings["comapuser"].ToString();
        private string ComapPass = ConfigurationManager.AppSettings["comappass"].ToString();
        private string ComapKey = ConfigurationManager.AppSettings["comapkey"].ToString();
        private string ClientId = ConfigurationManager.AppSettings["clientid"].ToString();
        private string Secret = ConfigurationManager.AppSettings["secret"].ToString();
        private string Token = "";
        private string guidValues = "0C9117DA-495A-11DF-85EB-428556D89593,F0219C1C-1860-4b4d-8E6E-3CEC96279D6F,48EC10D1-7AF8-4ce9-B5B3-A5315993FEB3,4C214D52-3D75-11DF-8AA2-529056D89593,EE83E7E9-7453-4e64-A5CB-C8C093FB2A2F,58A6DF2D-73F7-4f18-BA2B-D19A58CC79F2,74200D25-93F2-4328-B1D6-1A08923AA499,72D0295A-3E65-11DF-892C-D6A856D89593,BB2D1ADE-740E-488d-853B-6BA970D52E27";

        public string token { get => Token; set => Token = value; }

        public async Task<string> Autenticar()
        {
            try
            {
                using var httpClient = new HttpClient();
                var url = "https://api.websupervisor.net/identity/application/authenticate";

                // Agregar el encabezado personalizado a la solicitud HTTP
                httpClient.DefaultRequestHeaders.Add("Comap-Key", ComapKey);

                // Crear un objeto HttpContent con los datos que deseas enviar en el cuerpo de la solicitud
                object requestBody = new { clientId = ClientId, secret = Secret };
                var jsonContent = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");


                // Enviar la solicitud HTTP POST a la API
                var response = await httpClient.PostAsync(url, jsonContent);
                response.EnsureSuccessStatusCode();
                // Leer el contenido de la respuesta en formato JSON
                var responseBody = await response.Content.ReadAsStringAsync();
                var jsonResponse = JsonConvert.DeserializeObject<dynamic>(responseBody);

                // Leer el token de la respuesta JSON
                token = "Bearer " + jsonResponse.access_token;

                return token;
            }
            catch (Exception ex)
            {
                Tools.writeLog("Error Autenticar", ex.Message, ex.StackTrace);
                return "";
            }
            
        }

        public async Task<bool> GetUnitValues(Models.Lectura lectura)
        {
            try
            {
                using var httpClient = new HttpClient();
                string url = "https://api.websupervisor.net/v1.1/" + ComapUser + "/units/" + lectura.Unitguid + "/values?valueGuids=" + guidValues;

                // Agregar el encabezado personalizado a la solicitud HTTP
                httpClient.DefaultRequestHeaders.Add("Authorization", token);
                httpClient.DefaultRequestHeaders.Add("Comap-Key", ComapKey);


                // Enviar la solicitud HTTP POST a la API
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                // Leer el contenido de la respuesta en formato JSON
                var responseBody = await response.Content.ReadAsStringAsync();
                Models.UnitValuesResponse valuesResponse = JsonConvert.DeserializeObject<Models.UnitValuesResponse>(responseBody);

                // Leer el token de la respuesta JSON
                foreach (Models.values value in valuesResponse.values)
                {
                    switch (value.name)
                    {
                        case "Last Update":
                            lectura.Last_update = value.value;
                            break;
                        case "Communication State":
                            lectura.Communication_state = value.value;
                            break;
                        case "Unit State":
                            lectura.Unit_state = value.value;
                            break;
                        case "kWh (Import)":
                            lectura.Kwh_import = value.value;
                            break;
                        case "Act power":
                            lectura.Act_power = value.value;
                            break;
                        case "ActPwrReq":
                            lectura.Act_power_req = value.value;
                            break;
                        case "Run hours":
                            lectura.Run_hours = value.value;
                            break;
                        case "Nomin power":
                            lectura.Nomin_power = value.value;
                            break;
                        case "Engine state":
                            lectura.Engine_state = value.value;
                            break;
                    } 
                }

                return true;
            }
            catch (Exception ex)
            {
                Tools.writeLog("Error GetUnitValues", ex.Message, ex.StackTrace);
                return false;
            }

        }
    }
}
