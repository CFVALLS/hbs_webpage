using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Conexion
{
    public class Conectar
    {

        public String CadenaCon(String codAmbiente) {
            String cadenaSQL = "";
            try {

                if (codAmbiente.Equals("PROD"))
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                    {
                        DataSource = "190.114.255.156",
                        InitialCatalog = "LisaLec",
                        UserID = "sa",
                        Password = "cloud2018**",
                        ApplicationName = "LisaLec"
                    };
                    cadenaSQL = builder.ConnectionString;
                }

                if (codAmbiente.Equals("TEST"))
                {
                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                    {
                        DataSource = "190.114.255.156",
                        InitialCatalog = "LisaLec_TEST",
                        UserID = "sa",
                        Password = "cloud2018**",
                        ApplicationName = "LisaLec"
                    };
                    cadenaSQL = builder.ConnectionString;
                }


                return cadenaSQL;

            } catch (Exception ex) {

                return ex.ToString();
            }

        
        }


    }
}
