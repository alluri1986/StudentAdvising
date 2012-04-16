using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using StudentAdvising.BLL;
using StudentAdvising.Common;

namespace StudentAdvising
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    //[ServiceContract]
    public class StudentAdvisoryServices : IStudentAdvisoryServices
    {
      // [OperationContract]
        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}

        //[OperationContract]
        public Student SaveStudentDetails(Student student)
        {
            BLStudent blStudent = new BLStudent();
            blStudent.SaveStudent(student);
            return student;
        }

        public List<Student> SearchStudent(string lastName, string email)
        {
             BLStudent blStudent = new BLStudent();
             return blStudent.SearchStudent(lastName,email);
           
        }

        public Course SaveCourseDetails(Course course)
        {
            BLCourse blCourse = new BLCourse();
            blCourse.SaveCourse(course);
            return course;
        }


        public List<CoursePrerequisite> SaveCoursePrerequisite(List<CoursePrerequisite> coursePrerequisite)
        {
            BLCoursePrerequisite blCoursePrerequisite = new BLCoursePrerequisite();
            //CoursePrerequisite[] array1 ;
            
            blCoursePrerequisite.SaveCoursePrerequisite(coursePrerequisite);
            return coursePrerequisite;
        }
    }
}
