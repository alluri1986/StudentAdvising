﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StudentAdvising.Common
{
    [DataContract]
    class SemesterCourse : CommonBase
    {
        [DataMember]
        public int SemesterID { get; set; }

        [DataMember]
        public int CourseID { get; set; }



    }
}
