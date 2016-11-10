using MSMQHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            WCFProxyMSMQ objWCF = new WCFProxyMSMQ();
            ILogService client = objWCF.GetProxy<ILogService>(1);
            LogInfo loginfo = new LogInfo();
            loginfo.ID = Guid.NewGuid().ToString();
            loginfo.Info = txtInfo.Text.Trim();
            loginfo.CreateDate = DateTime.Now;
            client.SendMessage(loginfo);
            MessageBox.Show("发送成功");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WCFProxyMSMQ objWCF = new WCFProxyMSMQ();
            ILogService client = objWCF.GetProxy<ILogService>(1);
            LogInfo loginfo = new LogInfo();
            loginfo.ID = Guid.NewGuid().ToString();
            loginfo.Info = txtInfo.Text.Trim();
            loginfo.CreateDate = DateTime.Now;
            client.SendMessageB(loginfo,1);
            MessageBox.Show("发送成功B");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WCFProxyMSMQ objWCF = new WCFProxyMSMQ();
            IMsgService client = objWCF.GetProxy<IMsgService>(1);
            client.WriteMsg(txtInfo.Text.Trim());
            MessageBox.Show("发送成功C");
        }
    }
}
