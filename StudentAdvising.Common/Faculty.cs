using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StudentAdvising.Common
{
    [DataContract]
    public class Faculty : Person
    {

        [DataMember]
        public int PersonID { get; set; }

   
         
    }
}
