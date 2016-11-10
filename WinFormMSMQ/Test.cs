using MSMQHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormMSMQ
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInfo.Text.Trim()))
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
                MessageQueueTransaction mqt = new MessageQueueTransaction();
                mqt.Begin();
                bool isPass = QueueManger.SendMessage<LogInfo>(loginfo, queuePath,MessagePriority.High,mqt);
                mqt.Commit();
                MessageBox.Show("发送状态:" + isPass);
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生异常:" + ex.Message);
            }
        }

        Thread a;
        Queue<string> f = new Queue<string>();
        private void button2_Click(object sender, EventArgs e)
        {
            f.Enqueue(txtQu.Text.Trim());
            
        }

        private void showQu()
        {
            while (true)
            {
                if (f.Count > 0)
                {
                    MessageBox.Show(f.Dequeue());
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }
        private void Test_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a = new Thread(showQu);
            a.Start();
        }

        private void Test_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(a != null)
            {
                a.Abort();
            }
            
        }
    }
}
