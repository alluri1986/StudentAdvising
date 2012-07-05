using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StudentAdvising.Common
{
    [DataContract]
    public class CoursePrerequisite : CommonBase
    {
        [DataMember]
        public override int ID
        {
            get
            {
                return base.ID;
            }
            set
            {
                base.ID = value;
            }
        }

        [DataMember]
        public int CourseID { get; set; }

        [DataMember]
        public int PreReqID { get; set; }

        [DataMember]
        public bool IsDependencyFL { get; set; }

        [DataMember]
        public string PreReqCourseName { get; set; }   



    }
}
