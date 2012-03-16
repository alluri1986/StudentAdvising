using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentAdvising.Common
{
    class StudentCourse : CommonBase
    {

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
                    
        public int  StudentID { get; set; }

        public int CourseID { get; set; }

        public int SemesterID { get; set; }

        public string Status { get; set; }


    }
}
