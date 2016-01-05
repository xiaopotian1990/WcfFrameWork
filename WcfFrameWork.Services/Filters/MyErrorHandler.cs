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
    /// 自定义错误异常处理类，可配合自定义消息拦截器使用。
    /// </summary>
    public class MyErrorHandler : IErrorHandler
    {
        /// <summary>
        /// 启用错误相关处理并返回一个值，该值指示调度程序在某些情况下是否中止会话和实例上下文。
        /// </summary>
        /// <param name="error">处理过程中引发的异常。</param>
        /// <returns>如果 Windows Communication Foundation (WCF) 不应中止会话（如果有一个）和
        /// 实例上下文（如果实例上下文不是 System.ServiceModel.InstanceContextMode.Single），则为
        /// true；否则为 false。默认值为 false。
        /// </returns>
        public bool HandleError(Exception error)
        {
            return true;
        }

        /// <summary>
        /// 启用创建从服务方法过程中的异常返回的自定义 System.ServiceModel.FaultException
        /// </summary>
        /// <param name="error">服务操作过程中引发的 Exception 异常。</param>
        /// <param name="version">消息的 SOAP 版本。</param>
        /// <param name="fault">双工情况下，返回到客户端或服务的 System.ServiceModel.Channels.Message 对象。</param>
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            string err = string.Format("调用WCF接口 '{0}' 出错",
                    error.TargetSite.Name) + "，详情：\r\n" + error.Message;
            var newEx = new FaultException(err);

            MessageFault msgFault = newEx.CreateMessageFault();
            fault = Message.CreateMessage(version, msgFault, newEx.Action);
            LogHelper.Error(err,error);
        }
    }
}
