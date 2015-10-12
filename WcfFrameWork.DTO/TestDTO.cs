using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfFrameWork.DTO
{
    [DataContract]
    public class TestDTO
    {
        [DataMember]
        public int A { get; set; }

        [DataMember]
        public int B { get; set; }
    }
}
