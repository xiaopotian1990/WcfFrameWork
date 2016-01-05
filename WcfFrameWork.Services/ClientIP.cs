using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.IO;

namespace JHOMS.Hospital.Common
{
    //客户端IP类
    public sealed class ClientIP
    {
        private ClientIP() { }

        private static ClientIP instance = null;
        private static readonly object obj = new object();

        public static ClientIP Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (obj)
                    {
                        if (instance == null)
                        {
                            instance = new ClientIP();
                        }
                    }
                }

                    return instance;
            }
        }

        /// <summary>
        /// 获取客户端的ip
        /// </summary>
        /// <param name="currentContext">当前的操作契约</param>
        /// <returns>ip字符串</returns>
        public string GetClientIP(OperationContext currentContext)
        {
            //提供方法执行的上下文环境
            OperationContext context = currentContext;
            //获取传进的消息属性
            MessageProperties properties = context.IncomingMessageProperties;
            //获取消息发送的远程终结点IP和端口
            RemoteEndpointMessageProperty endpoint = properties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;

            return endpoint.Address;
        }
    }
}
