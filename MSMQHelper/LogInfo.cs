using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMQHelper
{
    /// <summary>
    /// 日志类实体
    /// </summary>
    [Serializable]
    public class LogInfo
    {
        public string ID { get; set; }
        public string Info { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
