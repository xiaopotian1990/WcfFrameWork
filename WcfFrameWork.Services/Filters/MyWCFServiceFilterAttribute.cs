namespace WcfFrameWork.Services.Filters
{
    public class MyWCFServiceFilterAttribute : ServiceInterceptorBehaviorAttribute
    {
        protected override OperationInterceptorBehaviorAttribute CreateOperationInterceptor()
        {
            return new MyWCFOperationFilterAttribute();
        }
    }
}
