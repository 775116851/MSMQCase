using MSMQHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            WCFProxyMSMQ objWCF = new WCFProxyMSMQ();
            ILogService client = objWCF.GetProxy<ILogService>();
            LogInfo loginfo = new LogInfo();
            loginfo.ID = Guid.NewGuid().ToString();
            loginfo.Info = txtInfo.Text.Trim();
            loginfo.CreateDate = DateTime.Now;
            client.SendMessage(loginfo);
            Response.Write("发送成功");
        }
    }
}