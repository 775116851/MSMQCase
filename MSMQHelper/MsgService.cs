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
    public class MsgService:IMsgService
    {
        private static readonly ILog log = log4net.LogManager.GetLogger(typeof(MsgService));
        [OperationBehavior(TransactionScopeRequired = true)]
        public void WriteMsg(string sMsg)
        {
            log.Info(string.Format("这是MSG接收到的消息 :{0}", sMsg));
        }
    }
}
