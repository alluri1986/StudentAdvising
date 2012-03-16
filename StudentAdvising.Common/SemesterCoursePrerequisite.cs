using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentAdvising.Common
{
    class SemesterCoursePrerequisite : CommonBase
    {

        public int CourseID { get; set; }

        public int PreReqID { get; set; }

        public bool IsDependencyFL { get; set; }       

    }
}
