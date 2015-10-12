using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace WcfFrameWork.Services.Filters
{
    /// <summary>
    /// 自定义服务器行为。
    /// </summary>
    class MyServiceBehavior : Attribute, IServiceBehavior, IEndpointBehavior
    {
        //private readonly Type _errorHandlerType;

        #region IEndpointBehavior Members

        /// <summary>
        /// 用于向绑定元素传递自定义数据，以支持协定实现。自定义绑定在此进行添加。
        /// </summary>
        /// <param name="endpoint"> 服务终结点。</param>
        /// <param name="bindingParameters"> 绑定元素可访问的自定义对象。</param>
        void IEndpointBehavior.AddBindingParameters(ServiceEndpoint endpoint,
             System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }
        /// <summary>
        /// 终结点添加客户端拦截器。
        /// </summary>
        /// <param name="endpoint"> 服务终结点。</param>
        /// <param name="clientRuntime"> 表示类的插入点，这些类可以扩展客户端应用程序处理的所有消息的 Windows Communication Foundation (WCF) 客户端对象的功能。</param>
        void IEndpointBehavior.ApplyClientBehavior(ServiceEndpoint endpoint,
                 System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            MyClientMessageInspector inspector = new MyClientMessageInspector();
            clientRuntime.MessageInspectors.Add(inspector);
        }

        /// <summary>
        /// 终结点添加消息拦截器
        /// </summary>
        /// <param name="endpoint"> 服务终结点。</param>
        /// <param name="endpointDispatcher"> 表示公开属性的运行时对象，使用这些属性可以在服务应用程序中插入运行时扩展或修改消息。</param>
        void IEndpointBehavior.ApplyDispatchBehavior(ServiceEndpoint endpoint,
                 System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            ChannelDispatcher channelDispatcher = endpointDispatcher.ChannelDispatcher;
            if (channelDispatcher != null)
            {
                foreach (EndpointDispatcher ed in channelDispatcher.Endpoints)
                {
                    MyDispatchMessageInspector inspector = new MyDispatchMessageInspector();
                    ed.DispatchRuntime.MessageInspectors.Add(inspector);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        void IEndpointBehavior.Validate(ServiceEndpoint endpoint) { }

        #endregion

        #region IServiceBehavior Members

        void IServiceBehavior.AddBindingParameters(ServiceDescription serviceDescription,
             ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints,
             BindingParameterCollection bindingParameters)
        {
        }
        //服务端行为添加消息拦截器
        void IServiceBehavior.ApplyDispatchBehavior(ServiceDescription desc, ServiceHostBase host)
        {
            foreach (ChannelDispatcher cDispatcher in host.ChannelDispatchers)
            {
                cDispatcher.ErrorHandlers.Add(new MyErrorHandler());
                foreach (EndpointDispatcher eDispatcher in cDispatcher.Endpoints)
                {
                    eDispatcher.DispatchRuntime.MessageInspectors.Add(new MyDispatchMessageInspector());
                }
            }
        }

        void IServiceBehavior.Validate(ServiceDescription desc, ServiceHostBase host) { }

        #endregion
    }
}
