using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StudentAdvising.Common
{
    [DataContract]
   public  class Semester
    {
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string semester { get; set; }

        [DataMember]
        public int year { get; set; }

        [DataMember]
        public DateTime startDate { get; set; }

        [DataMember]
        public DateTime endDate { get; set; }



    }
}
