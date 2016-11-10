using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MSMQServer
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }
        private static readonly ILog log = log4net.LogManager.GetLogger(typeof(Service1));
        protected List<ServiceHost> serviceHostList = new List<ServiceHost>();
        protected override void OnStart(string[] args)
        {
            List<ServiceHost> serviceHostList = new List<ServiceHost>();
            var configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
            ServiceModelSectionGroup serviceModelSectionGroup = (ServiceModelSectionGroup)configuration.GetSectionGroup("system.serviceModel");
            log.Info("1123");
            //开启每个服务
            foreach (ServiceElement serviceElement in serviceModelSectionGroup.Services.Services)
            {
                try
                {
                    var wcfServiceType = Assembly.Load("MSMQHelper").GetType(serviceElement.Name);
                    var serviceHost = new ServiceHost(wcfServiceType);
                    serviceHostList.Add(serviceHost);
                    serviceHost.Open();
                }
                catch (Exception ex)
                {
                    log.Error(ex.ToString());
                    EventLog.WriteEntry("遍历启动服务出问题" + ex.Message);

                    //System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
            }
            
        }

        protected override void OnStop()
        {
            if (serviceHostList != null && serviceHostList.Count > 0)
            {
                foreach (ServiceHost sh in serviceHostList)
                {
                    sh.Close();
                }
            }
        }
    }
}
