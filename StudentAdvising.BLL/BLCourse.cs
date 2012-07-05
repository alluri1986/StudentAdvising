using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentAdvising.DLL;
using StudentAdvising.Common;

namespace StudentAdvising.BLL
{
    public class BLCourse
    {

        private DLCourse dlcourse = null;


        public DLCourse GetDLCourse()
        {
            if (dlcourse == null)
                dlcourse = new DLCourse();

            return dlcourse;
        }

       
        public Course SaveCourse(Course course)
        {
            try
            {
                course.CreationDate = DateTime.UtcNow;
                course.LastUpdatedDate = DateTime.UtcNow;
                course = GetDLCourse().SaveCourse(course);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return course;
        }

        public List<Course> GetCourseList()
        {

            return GetDLCourse().GetCourses();
        }

        public List<CoursePrerequisite> SaveCoursePrerequisite(int CourseID,List<CoursePrerequisite> coursePrerequisite)
        {
            try
            {
                //coursePrerequisite.CreationDate = DateTime.UtcNow;
                //coursePrerequisite.LastUpdatedDate = DateTime.UtcNow;
                GetDLCourse().SaveCoursePrerequisite(CourseID,coursePrerequisite);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return coursePrerequisite;

        }

        public List<CoursePrerequisite> GetCoursePreRequisites(int CourseID)
        {
            return GetDLCourse().GetCoursePreRequisites(CourseID);
        }
       

    }
}
