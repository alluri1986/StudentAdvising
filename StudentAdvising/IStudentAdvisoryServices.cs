using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Collections;

using StudentAdvising.Common;

namespace StudentAdvising
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IStudentAdvisoryServices
    {

        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        [OperationContract]
        List<Semester> getLuSemester();

        [OperationContract]
        bool SaveDepartment(Department department);

        [OperationContract]
        List<Department> getLuDepartment(); 
        
        [OperationContract]
        Student SaveStudentDetails(Student student);

        [OperationContract]
        Student GetStudent(int studentID);
        
        [OperationContract]
        Faculty SaveFacultyDetails(Faculty faculty) ;

        [OperationContract]
        List<Faculty> GetFaculty();

        [OperationContract]
        List<Student> SearchStudent(string lastName, string email);

        [OperationContract]
        Course SaveCourseDetails(Course course);

        [OperationContract]
        List<CoursePrerequisite> SaveCoursePrerequisite(int CourseID,List<CoursePrerequisite> coursePrerequisite);

        [OperationContract]
        List<Course> GetCourses();

        [OperationContract]
        List<CoursePrerequisite> GetCoursePrerequisites(int courseID);


        [OperationContract]
        bool SaveSemesterCourse(List<SemesterCourse> semesterCourses);

        [OperationContract]
        List<SemesterCourse> getSemesterCourses(int semesterID);


        [OperationContract]
        bool SaveSemesterCourses(int courseID, int fromYear, int toYear, bool Fall, bool Spring, bool Summer);

        [OperationContract]
        List<Semester> GetCourseAvailability(int CourseID);


        [OperationContract]
        List<StudentCourse> AvailableCourses(List<StudentCourse> registeredCourses);

        [OperationContract]
        List<StudentCourse> RegisteredCourses(int studentID);

        [OperationContract]
        RegisteredAvailableCourseList GetStudentRegisteredAndAvailableCourses(int studentID, RegisteredAvailableCourseList RnAList);
       
        [OperationContract]
        bool SaveStudentRegisteredCourses(List<StudentCourse> studentRegisteredCourses, int StudentID);

        [OperationContract]
        bool AddTransferedCourse(int StudentID,Course course);

        [OperationContract]
        List<StudentCourse> GetTransferedCourses(int StudentID);

        [OperationContract]
        List<StudentCourse> OverRideCourses(int studentID, int SemesterID);

        [OperationContract]
        bool OverRideCourse(int advisorID, StudentCourse sc);

        [OperationContract]
        UserDetails GetUserDetails(string email);
 

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
