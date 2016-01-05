using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using WcfFrameWork.AOP;

namespace WcfFrameWork.Services.Filters
{
    /// <summary>
    /// 服务器端自定义WCF消息拦截器，消息拦截是WCF最早的操作，此时消息还未格式化，拦截的是SOAP消息。
    /// </summary>
    public class MyDispatchMessageInspector : IDispatchMessageInspector
    {
        /// <summary>
        /// 在已接收入站消息后将消息调度到应发送到的操作之前调用。
        /// </summary>
        /// <param name="request">请求消息。</param>
        /// <param name="channel">传入通道。</param>
        /// <param name="instanceContext">当前服务实例。</param>
        /// <returns>
        /// 用于关联状态的对象。该对象将在 
        /// System.ServiceModel.Dispatcher.IDispatchMessageInspector.BeforeSendReply(System.ServiceModel.Channels.Message@,System.Object)
        ///  方法中传回。
        /// </returns>
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {

            LogHelper.Info(request.ToString());
            return null;
        }

        /// <summary>
        /// 在操作已返回后发送回复消息之前调用。
        /// </summary>
        /// <param name="reply">回复消息。如果操作是单向的，则此值为 null。</param>
        /// <param name="correlationState">
        /// 从 System.ServiceModel.Dispatcher.IDispatchMessageInspector.AfterReceiveRequest(System.ServiceModel.Channels.Message@,System.ServiceModel.IClientChannel,System.ServiceModel.InstanceContext)
        //  方法返回的关联对象。
        /// </param>
        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            //提供方法执行的上下文环境
            OperationContext context = OperationContext.Current;
            //获取传进的消息属性
            MessageProperties properties = context.IncomingMessageProperties;
            //获取消息发送的远程终结点IP和端口
            RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

            string ip = endpoint.Address;
            LogHelper.Info("IP: " + ip + "    " + reply.ToString());
        }
    }
}
