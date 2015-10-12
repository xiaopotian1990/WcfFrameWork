using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace WcfFrameWork.Services.Filters
{
    /// <summary>
    /// 自定义客户端拦截过滤器。
    /// </summary>
    public class MyClientMessageInspector : IClientMessageInspector
    {
        //[ThreadStatic]
        //bool isRequest;

        #region 客户端拦截 IClientMessageInspector Members

        /// <summary>
        /// 客户端收到消息之后
        /// </summary>
        /// <param name="reply"></param>
        /// <param name="correlationState"></param>
        void IClientMessageInspector.AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            Console.WriteLine("WCF 消息拦截 IClientMessageInspector Recevived message at:{0}", DateTime.Now);

        }

        /// <summary>
        /// 客户端调用之前
        /// </summary>
        /// <param name="request"></param>
        /// <param name="channel"></param>
        /// <returns></returns>
        object IClientMessageInspector.BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            Console.WriteLine("WCF 消息拦截 IClientMessageInspector BeforeSend message at:{0}", DateTime.Now);

            return null;
        }
        #endregion
    }
}
