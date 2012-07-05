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

        public UserDetails GetUserDetails(string email)
        {
            BLUserDetails blUserDetails = new BLUserDetails();
            return blUserDetails.GetUserDetails(email);

        }

        public List<Semester> getLuSemester()
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

        public Student GetStudent(int studentID)
        {
            BLStudent blStudent = new BLStudent();
            return blStudent.GetStudent(studentID);
            
        }
        
        public List<Student> SearchStudent(string lastName, string email)
        {
             BLStudent blStudent = new BLStudent();
             return blStudent.SearchStudent(lastName,email);
           
        }

        public Faculty SaveFacultyDetails(Faculty faculty) 
        {
            try
            {
                BLFaculty blFaculty = new BLFaculty();
                blFaculty.SaveFaculty(faculty);
                
            }
            catch (StudentAdvising.Common.ApplicationException appException)
            {
                throw appException;
            }
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


        public List<CoursePrerequisite> SaveCoursePrerequisite(int CourseID,List<CoursePrerequisite> coursePrerequisite)
        {
            BLCourse blCourse = new BLCourse();
            //CoursePrerequisite[] array1 ;

            return blCourse.SaveCoursePrerequisite(CourseID,coursePrerequisite);
            
        }


        
        public bool SaveSemesterCourses(int courseID, int fromYear, int toYear, bool Fall, bool Spring, bool Summer)
        {
            BLSemesterCourse blSemesterCourse = new BLSemesterCourse();
            blSemesterCourse.SaveSemesterCourses(courseID, fromYear, toYear, Fall, Spring, Summer);
            return true;
        }


        public bool AddTransferedCourse(int StudentID, Course course)
        {
            BLStudent blStudent = new BLStudent();
            return blStudent.AddTransferedCourse(StudentID, course);

        }

        public List<StudentCourse> GetTransferedCourses(int StudentID)
        {
            BLStudent blStudent = new BLStudent();
            return blStudent.GetTransferedCourses(StudentID);

        }

        public List<StudentCourse> AvailableCourses(List<StudentCourse> registeredCourses)
        {
            BLStudent blStudent = new BLStudent();
            return blStudent.GetStudentAvailableCourses(registeredCourses);

        }

        public List<StudentCourse> RegisteredCourses(int studentID)
        {
            BLStudent blStudent = new BLStudent();

            return blStudent.GetStudentRegisteredCourses(studentID);

        }

        public RegisteredAvailableCourseList GetStudentRegisteredAndAvailableCourses(int studentID, RegisteredAvailableCourseList RnAList)
        {

            BLStudent blStudent = new BLStudent();
            return blStudent.GetStudentRegisteredAndAvailableCourses(studentID, RnAList);
        }

        public bool SaveStudentRegisteredCourses(List<StudentCourse> studentRegisteredCourses, int StudentID)
        {
            BLStudent blStudent = new BLStudent();
            return blStudent.SaveStudentRegisteredCourses(studentRegisteredCourses, StudentID);
        }


        public List<StudentCourse> OverRideCourses(int studentID, int SemesterID)
        {
            BLStudent blStudent = new BLStudent();
            return blStudent.OverRideCourses(studentID, SemesterID);

        }

        public bool OverRideCourse(int advisorID, StudentCourse sc)
        {
            BLStudent blStudent = new BLStudent();
            return blStudent.OverRideCourse(advisorID, sc);

        }


        public List<Course> GetCourses()
        {
            BLCourse blCourse = new BLCourse();
            return blCourse.GetCourseList();

        }

        public List<CoursePrerequisite> GetCoursePrerequisites(int  courseID)
        {
            BLCourse blCourse = new BLCourse();
            return blCourse.GetCoursePreRequisites(courseID);
        }


        public bool SaveDepartment(Department department)
        {
            BLDepartment blDept = new BLDepartment();
            return blDept.SaveDepartment(department);

        }

        public List<Department> getLuDepartment()
        {
            BLDepartment blDept = new BLDepartment();
            return blDept.getLuDepartment();
        }


        public bool SaveSemesterCourse(List<SemesterCourse> semesterCourses)
        {
            BLSemesterCourse blsemsester = new BLSemesterCourse();
            return blsemsester.SaveSemesterCourses(semesterCourses);
        }


        public List<SemesterCourse> getSemesterCourses(int semesterID)
        {
            BLSemesterCourse blsemsester = new BLSemesterCourse();
            return blsemsester.getSemesterCourses(semesterID);
        }

        public List<Semester> GetCourseAvailability(int CourseID)
        {
            throw new NotImplementedException();
        }
    }
}
