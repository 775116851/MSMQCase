using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMQHelper
{
    public class AppConfig
    {
        public static string QueuePath
        {
            get { return ConfigurationManager.AppSettings["QueuePath"]; }
        }

        public static string QueuePathTran
        {
            get { return ConfigurationManager.AppSettings["QueuePathTran"]; }
        }
    }
}
