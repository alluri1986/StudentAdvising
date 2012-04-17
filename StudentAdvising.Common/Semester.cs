using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StudentAdvising.Common
{
    [DataContract]
    class Semester
    {
        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string Name { get; set; }


    }
}
