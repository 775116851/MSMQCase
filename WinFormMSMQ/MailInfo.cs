using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormMSMQ
{
    public class MailInfo
    {
        public string StmpServer { get; set; }
        public string SendAddress { get; set; }
        public string SendPwd { get; set; }
        public string ReceiveAddress { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
