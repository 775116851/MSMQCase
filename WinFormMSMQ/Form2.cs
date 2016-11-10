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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //远程发送
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRequest.Text.Trim()))
            {
                MessageBox.Show("请先输入传入参数！！");
                return;
            }
            try
            {
                bool isPass = QueueManger.SendMessage<string>(txtRequest.Text.Trim(), txtURL.Text.Trim());
                MessageBox.Show("发送状态:" + isPass);
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生异常:"+ ex.Message);
            }
        }

        //远程接收
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string strMes = QueueManger.ReceiveMessage<string>(txtURL.Text.Trim());
                txtResponse.Text = strMes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("发生异常:" + ex.Message);
            }
        }

        //本地接收
        private void button3_Click(object sender, EventArgs e)
        {
            string queuePath = txtBDUrl.Text.Trim();
            List<string> list = QueueManger.GetAllMessage<string>(queuePath);
            for (int i = 0; i < list.Count; i++)
            {
                string mi = QueueManger.ReceiveMessage<string>(queuePath);
                MessageBox.Show(mi);
            }

        }
    }
}
