using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfFrameWork.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.创建一个Host对象，托管特定类型的服务
            ServiceHost host = new ServiceHost(typeof(WcfFrameWork.Services.ExceptionTest));
            //2.启动
            host.Open();
            //3.打印Endpoint
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var item in host.Description.Endpoints)
            {
                Console.WriteLine("终结点地址：" + item.Address);
            }
            //阻塞当前线程
            Console.WriteLine("WCF服务已经启动。。。");
            Console.Read();
        }
    }
}
