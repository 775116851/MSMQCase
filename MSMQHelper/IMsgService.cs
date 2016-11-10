﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MSMQHelper
{
    [ServiceContract(Namespace = "http://www.tts.com")]
    public interface IMsgService
    {
        [OperationContract(IsOneWay = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void WriteMsg(string sMsg);
    }
}
