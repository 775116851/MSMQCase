using MSMQHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormMSMQ
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtInfo.Text.Trim()))
            {
                MessageBox.Show("请输入发送日志内容");
                return;
            }
            string queuePath = txtUrl.Text.Trim();
            LogInfo loginfo = new LogInfo();
            loginfo.ID = Guid.NewGuid().ToString();
            loginfo.Info = txtInfo.Text.Trim();
            loginfo.CreateDate = DateTime.Now;
            bool isPass = false;
            if (cboSW.Checked == true)
            {
                MessageQueueTransaction myTran = new MessageQueueTransaction();
                try
                {
                    myTran.Begin();
                    isPass = QueueManger.SendMessage<LogInfo>(loginfo, queuePath, System.Messaging.MessagePriority.High, myTran);
                    myTran.Commit();
                }
                catch (Exception ex)
                {
                    myTran.Abort();
                }
            }
            else
            {
                isPass = QueueManger.SendMessage<LogInfo>(loginfo, queuePath,System.Messaging.MessagePriority.High);
            }
            MessageBox.Show("发送状态:" + isPass);
        }
    }
}
