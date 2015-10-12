using System;
using System.Globalization;
using System.ServiceModel.Dispatcher;
using System.Threading.Tasks;
using WcfFrameWork.AOP;

namespace WcfFrameWork.Services.Filters
{
    public class MyWCFInvoker : GenericInvoker
    {
        private MonitorLog log;
        public MyWCFInvoker(IOperationInvoker oldInvoker) : base(oldInvoker) { }

        protected override void PreInvoke(object instance, object[] inputs)
        {
            log = new MonitorLog();
            log.ExecuteStartTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss.ffff", DateTimeFormatInfo.InvariantInfo));
            log.FuncName = instance.ToString();
            log.Params = inputs;
        }

        protected override void PostInvoke(object instance, object returnedValue, object[] outputs, Exception exception)
        {
            log.ExecuteEndTime = DateTime.Now;
            LogHelper.Info(log.GetLoginfo());

            if (exception != null)
            {
                string ErrorMsg = string.Format("在执行 {0} 时产生异常", instance.ToString());
                LogHelper.Error(ErrorMsg, exception);
            }
        }
    }
}
