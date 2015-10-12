using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfFrameWork.DTO;
using WcfFrameWork.IServices;
using WcfFrameWork.Services.Filters;

namespace WcfFrameWork.Services
{
    //[MyWCFServiceFilter]
    [MyServiceBehavior]
    public class ExceptionTest : IExceptionTest
    {
        //[OperationInterceptorBehavior]
        public int Test(TestDTO dto)
        {
            Console.WriteLine("1111111111111");
            return dto.A / dto.B;
        }
    }
}
