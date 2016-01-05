using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfFrameWork.DTO;

namespace WcfFrameWork.IServices
{
    [ServiceContract(Namespace ="www.xiaopotian.com")]
    public interface IExceptionTest
    {
        [OperationContract]
        int Test(TestDTO dto);

        [OperationContract]
        string Test2(TestDTO dto, string a, TestDTO dto2);
    }
}
