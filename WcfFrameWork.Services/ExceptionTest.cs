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
    
    public class ExceptionTest : IExceptionTest
    {
        [MyWCFOperationFilter]
        //[MyServiceBehavior]
        public int Test(TestDTO dto)
        {
            Console.WriteLine("1111111111111");
            return dto.A / dto.B;
        }
        [MyWCFOperationFilter]
        public string Test2(TestDTO dto, string a, TestDTO dto2)
        {
            return "1111111111";
        }
    }
}
