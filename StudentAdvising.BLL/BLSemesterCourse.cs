using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentAdvising.DLL;

namespace StudentAdvising.BLL
{
     public class BLSemesterCourse
    {

        private DLSemesterCourse dlSemesterCourse = null;

        public DLSemesterCourse GetDLSemesterCourse()
        {
            if (dlSemesterCourse == null)
            {
                dlSemesterCourse = new DLSemesterCourse();
            }
            return dlSemesterCourse;
        }


        public bool SaveSemesterCourses(int courseID, int fromYear, int toYear, bool Fall, bool Spring, bool Summer)
        {
            GetDLSemesterCourse().SaveSemesterCourses(courseID,  fromYear, toYear,  Fall,  Spring,  Summer);
            return true;
        }
        
    }
}
