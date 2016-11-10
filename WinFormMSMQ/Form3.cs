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

namespace WinFormMSMQ
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtInfo.Text.Trim()))
            {
                MessageBox.Show("请输入发送日志内容");
                return;
            }
            try
            {
                string queuePath = txtUrl.Text.Trim();
                LogInfo loginfo = new LogInfo();
                loginfo.ID = Guid.NewGuid().ToString();
                loginfo.Info = txtInfo.Text.Trim();
                loginfo.CreateDate = DateTime.Now;
                bool isPass = QueueManger.SendMessage<LogInfo>(loginfo, queuePath);
                MessageBox.Show("发送状态:" + isPass);
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生异常:" + ex.Message);
            }
        }
    }
}
