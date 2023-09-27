using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Logs;
using System.Configuration;

namespace Tomaval_Lectura.Utils
{

    public class Tools
    {
        public const string statusOK = "SUCCESS";
        public const string statusNOK = "ERROR";
        public const string statusNODATA = "NO DATA";
        public static Logs.Logs _log = new Logs.Logs(ConfigurationManager.AppSettings["pathlog"], "lecturas", "txt");

        private static Random random = new Random();

        public static string base64ToText(string sbase64)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(sbase64.Replace("-", "/").Replace("_", "+"));
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string toJson(object ds)
        {
            return JsonConvert.SerializeObject(ds).ToString();
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static void writeLog(string metodo, string texto, string stacktrace)
        {
            if (!System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Logs/"))
                System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Logs/");

            _log.MethodName = metodo;
            _log.Message = texto;
            _log.StackTrace = stacktrace;
            _log.writeLog();
        }
    }

}