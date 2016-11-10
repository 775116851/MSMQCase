using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MSMQHelper
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class LogService:ILogService
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(typeof(LogService));
        [OperationBehavior(TransactionScopeRequired = true)]
        public void SendMessage(LogInfo logInfo)
        {
            try
            {
                //throw new Exception("123");
                Console.WriteLine("这是消息:" + logInfo.Info);
                log.Info(string.Format("这是接收到的消息 ID：{0} Info:{1} Data:{2}", logInfo.ID, logInfo.Info, logInfo.CreateDate));
            }
            catch (Exception ex)
            {
                log.Error("这是SendMessageA异常消息"+ ex.Message);
            }
        }

        [OperationBehavior(TransactionScopeRequired = true)]
        public void SendMessageB(LogInfo logInfo,int sType)
        {
            try
            {
                log.Info(string.Format("这是XX接收到的消息 ID：{0} Info:{1} Data:{2}", logInfo.ID, logInfo.Info, logInfo.CreateDate));
            }
            catch (Exception ex)
            {
                log.Error("这是SendMessageB异常消息"+ ex.Message);
            }
        }
    }
}
