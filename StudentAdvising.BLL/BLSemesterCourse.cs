using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentAdvising.DLL;
using StudentAdvising.Common;

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
        public bool SaveSemesterCourses(List<SemesterCourse> semesterCourses)
        {

            return GetDLSemesterCourse().SaveSemesterCourses(semesterCourses);
        }

        public bool SaveSemesterCourses(int courseID, int fromYear, int toYear, bool Fall, bool Spring, bool Summer)
        {
            GetDLSemesterCourse().SaveSemesterCourses(courseID,  fromYear, toYear,  Fall,  Spring,  Summer);
            return true;
        }

        public List<SemesterCourse> getSemesterCourses(int semesterID)
        {
            return GetDLSemesterCourse().getSemesterCourses(semesterID);
        }
    }
}
