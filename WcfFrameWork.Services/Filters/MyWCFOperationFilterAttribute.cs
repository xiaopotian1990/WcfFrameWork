using System.ServiceModel.Dispatcher;

namespace WcfFrameWork.Services.Filters
{
    public class MyWCFOperationFilterAttribute : OperationInterceptorBehaviorAttribute
    {
        protected override GenericInvoker CreateInvoker(IOperationInvoker oldInvoker)
        {
            return new MyWCFInvoker(oldInvoker);
        }
    }
}
