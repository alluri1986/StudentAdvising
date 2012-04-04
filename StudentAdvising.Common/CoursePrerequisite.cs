using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentAdvising.Common
{
    public class CoursePrerequisite : CommonBase
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

        public int CourseID { get; set; }

        public int PreReqID { get; set; }

        public bool IsDependencyFL { get; set; }       

    }
}
