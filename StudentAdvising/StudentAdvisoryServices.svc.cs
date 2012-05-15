using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using StudentAdvising.BLL;
using StudentAdvising.DLL;
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

        public System.Collections.Hashtable getLuSemester()
        {
            DLSemester dlSemester = new DLSemester();
            return dlSemester.getLuSemester();
        }


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

        public Faculty SaveFacultyDetails(Faculty faculty)
        {
            BLFaculty blFaculty = new BLFaculty();
            blFaculty.SaveFaculty(faculty);
            return faculty;
        }

        public List<Faculty> GetFaculty()
        {
            BLFaculty blfaculty = new BLFaculty();

            return blfaculty.GetFaculty();

        }

        public Course SaveCourseDetails(Course course)
        {
            BLCourse blCourse = new BLCourse();
            blCourse.SaveCourse(course);
            return course;
        }


        public List<CoursePrerequisite> SaveCoursePrerequisite(List<CoursePrerequisite> coursePrerequisite)
        {
            BLCourse blCourse = new BLCourse();
            //CoursePrerequisite[] array1 ;

            return blCourse.SaveCoursePrerequisite(coursePrerequisite);
            
        }


        public bool SaveSemesterCourse(List<SemesterCourse> semesterCourses)
        {

            return true;
        }

        public bool SaveSemesterCourses(int courseID, int fromYear, int toYear, bool Fall, bool Spring, bool Summer)
        {
            BLSemesterCourse blSemesterCourse = new BLSemesterCourse();
            blSemesterCourse.SaveSemesterCourses(courseID, fromYear, toYear, Fall, Spring, Summer);
            return true;
        }




        
    }
}
