using MSMQHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormMSMQ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //发送邮件
        private void btnSend_Click(object sender, EventArgs e)
        {
            MailInfo mi = new MailInfo();
            mi.StmpServer = txtSMTP.Text.Trim();
            mi.SendAddress = txtFJRDZ.Text.Trim();
            mi.SendPwd = txtFJRMM.Text.Trim();
            mi.ReceiveAddress = txtSJRDZ.Text.Trim();
            mi.Title = txtYJZT.Text.Trim();
            mi.Content = txtYJZW.Text.Trim();
            if (mi != null)
            {
                string queuePath = AppConfig.QueuePath;

                bool isPass = QueueManger.Createqueue(queuePath);//创建队列
                if (isPass == true)
                {
                    isPass = QueueManger.SendMessage<MailInfo>(mi, queuePath,MessagePriority.Highest);//发送消息到队列
                    if (isPass == true)
                    {
                        MessageBox.Show("成功");
                    }
                    else
                    {
                        MessageBox.Show("失败");
                    }
                }
            }
        }

        //从消息队列中取出消息并发送
        private void btnAllSend_Click(object sender, EventArgs e)
        {
            string queuePath = AppConfig.QueuePath;
            MessageQueue myQueue = new MessageQueue(queuePath);
            myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(MailInfo) });
            MessageEnumerator enumerator = myQueue.GetMessageEnumerator2();
            while (enumerator.MoveNext())
            {
                MailInfo mi = (MailInfo)enumerator.Current.Body;
                bool isPass = SendMail(mi);
                if (isPass == true)
                {
                    //enumerator.RemoveCurrent();
                    myQueue.ReceiveById(enumerator.Current.Id);
                }
                MessageBox.Show(mi.Content);
            }
        }

        //邮件服务
        private bool SendMail(MailInfo mi)
        {
            SmtpClient client = new SmtpClient();
            client.Host = mi.StmpServer;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(mi.SendAddress, mi.SendPwd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage message = new MailMessage(mi.SendAddress, mi.ReceiveAddress);
            message.Subject = mi.Title;
            message.Body = mi.Content;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            try
            {
                client.Send(message);
                MessageBox.Show("邮件已发送到：" + mi.ReceiveAddress);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("邮件发送失败：{0}。失败原因：{1}", mi.ReceiveAddress, ex.Message));
                return false;
            }
        }

        //发送邮件(含事务)
        private void btnSWSend_Click(object sender, EventArgs e)
        {
            MailInfo mi = new MailInfo();
            mi.StmpServer = txtSMTP.Text.Trim();
            mi.SendAddress = txtFJRDZ.Text.Trim();
            mi.SendPwd = txtFJRMM.Text.Trim();
            mi.ReceiveAddress = txtSJRDZ.Text.Trim();
            mi.Title = txtYJZT.Text.Trim();
            mi.Content = txtYJZW.Text.Trim();
            if (mi != null)
            {
                string queuePath = AppConfig.QueuePathTran;

                bool isPass = QueueManger.Createqueue(queuePath,true);//创建事务队列
                if (isPass == true)
                {
                    MessageQueueTransaction myTran = new MessageQueueTransaction();
                    try
                    {
                        myTran.Begin();
                        isPass = QueueManger.SendMessage<MailInfo>(mi, queuePath, MessagePriority.Highest, myTran);//发送消息到队列
                        //QueueManger.SendMessage<MailInfo>(mi, queuePath, MessagePriority.Highest, myTran);//发送消息到队列
                        if (isPass == true)
                        {
                            myTran.Commit();
                            MessageBox.Show("成功");
                        }
                        else
                        {
                            myTran.Abort();
                            MessageBox.Show("失败");
                        }
                    }
                    catch (Exception ex)
                    {
                        myTran.Abort();
                        MessageBox.Show("失败原因:" + ex.Message);
                    }
                }
            }
        }

        //从消息队列中取出消息并发送(含事务)
        private void btnSWAllSend_Click(object sender, EventArgs e)
        {
            string queuePath = AppConfig.QueuePathTran;
            //List<MailInfo> list = QueueManger.GetAllMessage<MailInfo>(queuePath);
            //foreach(MailInfo mi in list)
            //{
            //    MessageBox.Show(mi.Content);
            //    bool isPass = SendMail(mi);
            //    if (isPass == true)
            //    {
            //        //enumerator.RemoveCurrent();
            //    }
            //    MessageBox.Show(mi.Content);
            //}
            //QueueManger.Purgequeue(queuePath);

            List<MailInfo> list = QueueManger.GetAllMessage<MailInfo>(queuePath);
            MessageQueueTransaction myTran = new MessageQueueTransaction();
            try
            {
                myTran.Begin();
                for (int i = 0; i < list.Count; i++)
                {
                    MailInfo mi = QueueManger.ReceiveMessage<MailInfo>(queuePath, myTran);
                    bool isPass = SendMail(mi);
                    MessageBox.Show(mi.Content);
                }
                myTran.Commit();
            }
            catch (Exception ex)
            {
                myTran.Abort();
                MessageBox.Show("出现异常：" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string queuePath = AppConfig.QueuePathTran;
            MessageQueue myQueue = new MessageQueue(queuePath);
            if (myQueue.Transactional)
            {
                MessageQueueTransaction myTransaction = new MessageQueueTransaction();
                //这里使用了委托,当接收消息完成的时候就执行MyReceiveCompleted方法
                myQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(MyReceiveCompleted);
                myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(MailInfo) });
                myTransaction.Begin();
                //myQueue.BeginReceive();//启动一个没有超时时限的异步操作
                myQueue.BeginReceive(TimeSpan.FromMinutes(0.2));
                //signal.WaitOne();
                myTransaction.Commit();
            }
        }

        private static void MyReceiveCompleted(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue myQueue = (MessageQueue)source;
            //完成指定的异步接收操作
            System.Messaging.Message message = myQueue.EndReceive(asyncResult.AsyncResult);
            MailInfo mi = message.Body as MailInfo;
            MessageBox.Show(mi.Content);
            //Thread.Sleep(60000);
            //myQueue.BeginReceive();
            myQueue.BeginReceive(TimeSpan.FromMinutes(0.2));
        }
    }
}
