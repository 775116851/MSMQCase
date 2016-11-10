using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace MSMQHelper
{
    public class WCFProxyMSMQ
    {
        //保存已创建的代理,如果再调用此代理，直接从serviceList中返回。
        private static Dictionary<string, object> serviceList = null;

        static WCFProxyMSMQ()
        {
            serviceList = new Dictionary<string, object>();
        }

        public WCFProxyMSMQ()
        {

        }

        /// <summary>
        /// 如果serviceList有相应的代理直接返回，否则Create一个代理
        /// serviceList的key是typeof(T).FullName
        /// serviceList的value是对应的代理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetProxy<T>(int sType=0) where T : class
        {
            return CreateChannel<T>(sType);
        }

        /// <summary>
        /// Create代理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private T CreateChannel<T>(int sType) where T : class
        {
            Configuration configuration;
            if (sType == 1)//WinForm
            {
                configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            }
            else//WebForm
            {
                configuration = WebConfigurationManager.OpenWebConfiguration("~");
            }
            ServiceModelSectionGroup smsg = (ServiceModelSectionGroup)configuration.GetSectionGroup("system.serviceModel");


            NetMsmqBinding netMsmqBinding = GetBindingByContract<T>(smsg) as NetMsmqBinding;
            EndpointAddress endpointAddress = GetEndpointAddressByContract<T>(smsg);

            if ((netMsmqBinding == null) || (endpointAddress == null))
            {
                throw new ArgumentException("请检查配置!");
            }

            ChannelFactory<T> channelFactory = new ChannelFactory<T>(netMsmqBinding, endpointAddress);
            T basicHttpChannel = channelFactory.CreateChannel();

            return basicHttpChannel;
        }

        private void SetBinding(NetMsmqBinding netMsmqBinding)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// 根据T得到相应的Binding 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="smsg"></param>
        /// <returns></returns>
        private System.ServiceModel.Channels.Binding GetBindingByContract<T>(ServiceModelSectionGroup smsg) where T : class
        {
            //System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
            //ServiceModelSectionGroup smsg = (ServiceModelSectionGroup)configuration.GetSectionGroup("system.serviceModel");

            foreach (ChannelEndpointElement ce in smsg.Client.Endpoints)
            {
                if (ce.Contract == typeof(T).FullName)
                {
                    switch (ce.Binding)
                    {
                        case "netMsmqBinding":
                            NetMsmqBinding binding = new NetMsmqBinding();
                            SetBindingParam(binding, ce, smsg);
                            return binding;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// 根据T得到相应的EndpointAddress
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="smsg"></param>
        /// <returns></returns>
        private EndpointAddress GetEndpointAddressByContract<T>(ServiceModelSectionGroup smsg) where T : class
        {
            //System.Configuration.Configuration configuration = ConfigurationManager.OpenExeConfiguration(Assembly.GetEntryAssembly().Location);
            //ServiceModelSectionGroup smsg = (ServiceModelSectionGroup)configuration.GetSectionGroup("system.serviceModel");

            foreach (ChannelEndpointElement ce in smsg.Client.Endpoints)
            {
                if (ce.Contract == typeof(T).FullName)
                {
                    return new EndpointAddress(ce.Address);
                }
            }

            return null;
        }


        /// <summary>
        /// 设置NetTcpBinding的参数
        /// </summary>
        /// <param name="binding"></param>
        /// <param name="ce"></param>
        /// <param name="svcmod"></param>
        private void SetBindingParam(NetMsmqBinding binding, ChannelEndpointElement ce, ServiceModelSectionGroup svcmod)
        {
            foreach (NetMsmqBindingElement el in svcmod.Bindings.NetMsmqBinding.ConfiguredBindings)
            {
                if (ce.BindingConfiguration == el.Name)
                {
                    binding.MaxReceivedMessageSize = el.MaxReceivedMessageSize;
                    binding.Security.Mode = el.Security.Mode;
                    binding.ReceiveTimeout = el.ReceiveTimeout;
                    binding.SendTimeout = el.SendTimeout;
                    binding.ReaderQuotas.MaxArrayLength = el.ReaderQuotas.MaxArrayLength;
                    binding.ReaderQuotas.MaxDepth = el.ReaderQuotas.MaxDepth;
                    binding.ReaderQuotas.MaxNameTableCharCount = el.ReaderQuotas.MaxNameTableCharCount;
                    binding.ReaderQuotas.MaxStringContentLength = el.ReaderQuotas.MaxStringContentLength;
                    return;
                }
            }
        }

        /// <summary>
        /// T:源类型  U:目标类型。用T实例中的属性的值向U实例中的字段或属性赋值
        /// </summary>
        /// <param name="t">源类型的一个Instance</param>
        /// <param name="u">目标类型的一个Instance</param>
        /// <returns></returns>
        public static U TransferInfoToEntity<T, U>(T t, U u)
            where T : class
            where U : class
        {
            Type type1 = typeof(T);
            Type type2 = typeof(U);

            if ((type1 == null) || (type2 == null))
            {
                throw new ArgumentNullException("类型不存在，或没有找到!");
            }
            if (type2.GetProperties(BindingFlags.Public | BindingFlags.Instance).Length == 0)
            {
                throw new ArgumentException("目标类型不存在公有Property");
            }

            if (type1.GetFields(BindingFlags.Public | BindingFlags.Instance).Length != 0)
            {
                foreach (FieldInfo info in type1.GetFields(BindingFlags.Public | BindingFlags.Instance))
                {
                    object temp = type1.InvokeMember(info.Name, BindingFlags.IgnoreCase | BindingFlags.GetField | BindingFlags.Public | BindingFlags.Instance, null, t, null);
                    type2.InvokeMember(info.Name, BindingFlags.IgnoreCase | BindingFlags.SetProperty | BindingFlags.Public | BindingFlags.Instance, null, u, new object[] { temp });
                }
            }

            if (type1.GetProperties(BindingFlags.Public | BindingFlags.Instance).Length != 0)
            {
                foreach (PropertyInfo info in type1.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    object temp = type1.InvokeMember(info.Name, BindingFlags.GetProperty | BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance, null, t, null);

                    PropertyInfo propertyInfo = type2.GetProperty(info.Name);
                    type2.InvokeMember(propertyInfo.Name, BindingFlags.SetProperty, null, u, new object[] { temp });
                }
            }
            return u;
        }
        public static U TransferEntityToInfo<T, U>(T t, U u)
            where T : class
            where U : class
        {
            Type type1 = typeof(T);
            Type type2 = typeof(U);

            if ((type1 == null) || (type2 == null))
            {
                throw new ArgumentNullException("类型不存在，或没有找到!");
            }
            if (type2.GetFields(BindingFlags.Public | BindingFlags.Instance).Length == 0 && type2.GetProperties(BindingFlags.Public | BindingFlags.Instance).Length == 0)
            {
                throw new ArgumentException("目标类型不存在公有的Field或Property");
            }

            //由property向field赋值(也就说DataContract以property向外expose,而Info是以field向外expose)
            if (type2.GetFields(BindingFlags.Public | BindingFlags.Instance).Length != 0)
            {
                foreach (PropertyInfo info in type1.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    object temp = type1.InvokeMember(info.Name, BindingFlags.GetProperty, null, t, null);

                    FieldInfo fieldInfo = type2.GetField(info.Name);
                    if (fieldInfo != null)
                    {
                        type2.InvokeMember(fieldInfo.Name, BindingFlags.SetField, null, u, new object[] { temp });
                    }
                }
            }

            //由property向property赋值(也就说DataContract和Info都是以property向外expose)
            if (type2.GetProperties(BindingFlags.Public | BindingFlags.Instance).Length != 0)
            {
                foreach (PropertyInfo info in type1.GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    object temp = type1.InvokeMember(info.Name, BindingFlags.GetProperty, null, t, null);

                    PropertyInfo propertyInfo = type2.GetProperty(info.Name);
                    if (propertyInfo != null)
                    {
                        type2.InvokeMember(propertyInfo.Name, BindingFlags.SetProperty, null, u, new object[] { temp });
                    }
                }
            }

            return u;
        }
    }
}
