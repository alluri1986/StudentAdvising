using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentAdvising.DLL;
using StudentAdvising.Common;

namespace StudentAdvising.BLL
{
    public class BLCoursePrerequisite
    {


        private DLCoursePrerequisite dlCoursePrerequisite = null;

        public DLCoursePrerequisite GetDLCoursePrerequisite()
        {
            if (dlCoursePrerequisite == null)
                dlCoursePrerequisite = new DLCoursePrerequisite();

            return dlCoursePrerequisite;
        }

        public List<CoursePrerequisite> SaveCoursePrerequisite(List<CoursePrerequisite> coursePrerequisite)
        {
            try
            {

                //coursePrerequisite.CreationDate = DateTime.UtcNow;
                //coursePrerequisite.LastUpdatedDate = DateTime.UtcNow;
                GetDLCoursePrerequisite().SaveCoursePrerequisite(coursePrerequisite);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return coursePrerequisite;
            
        }


    }
}
