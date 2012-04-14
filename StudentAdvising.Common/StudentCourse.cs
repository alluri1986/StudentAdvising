﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StudentAdvising.Common
{
    [DataContract]
    public class StudentCourse : CommonBase
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
        public int  StudentID { get; set; }

        [DataMember]
        public int CourseID { get; set; }
        
        [DataMember]
        public int SemesterID { get; set; }

        [DataMember]
        public string Status { get; set; }


    }
}
