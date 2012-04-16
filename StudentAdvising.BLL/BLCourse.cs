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
                GetDLCourse().SaveCourse(course);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return course;
        }

       

    }
}
