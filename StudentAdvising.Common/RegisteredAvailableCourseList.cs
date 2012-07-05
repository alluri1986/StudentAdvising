using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StudentAdvising.Common
{
   public class RegisteredAvailableCourseList
    {
        [DataMember]
        public List<StudentCourse> registeredCourses { get; set; }


        [DataMember]
        public List<StudentCourse> availableCourses { get; set; }
               
       [DataMember]
        public int removedSemesterCourseID { get; set; }

    }
}
