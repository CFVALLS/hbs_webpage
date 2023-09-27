using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controlador
{
    public class Configs
    {
        //public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static Logs.Logs logger = new Logs.Logs(AppDomain.CurrentDomain.BaseDirectory + "Logs/", "logfile", "txt");

        public void writelog(string name, string message, string stacktrace )
        {
            if (!System.IO.Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Logs/"))
                System.IO.Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "Logs/");

            logger.Message = message;
            logger.Namelog = name;
            logger.StackTrace = stacktrace;
            logger.writeLog();
        }

    }
}
