using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StudentAdvising.Common
{
   public  class Department : CommonBase
    {
        [DataMember]
        public int DeptID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Abbreviation { get; set; }

        [DataMember]
        public string Description { get; set; }

       

    }
}
