using MSMQHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMSMQ
{
    class Program
    {
        //http://www.cnblogs.com/lori/archive/2012/02/10/2345203.html
        static void Main(string[] args)
        {
            string queuePath = AppConfig.QueuePath;
            //QueueManger.GetAllMessage<List<LogInfo>>(queuePath);
            while (1 == 1)
            {
                LogInfo loginfo = QueueManger.ReceiveMessage<LogInfo>(queuePath);
                if (loginfo != null)
                {
                    Console.WriteLine("ID:" + loginfo.ID + " 内容：" + loginfo.Info + " 时间:" + loginfo.CreateDate);
                }
            }
        }
    }
}
