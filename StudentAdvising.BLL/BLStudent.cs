using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentAdvising.DLL;
using StudentAdvising.Common;

namespace StudentAdvising.BLL
{
    public class BLStudent
    {

        private DLStudent dlStudent = null;

        public DLStudent GetDLStudent()
        {
            if (dlStudent == null)
                dlStudent = new DLStudent();

            return dlStudent;
        }


        /// <summary>
        /// This function is used for insert and updated functionality for student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public Student SaveStudent(Student student)
        {
            try
            {
                student.CreationDate = DateTime.UtcNow;
                student.LastUpdatedDate = DateTime.UtcNow;
                
                GetDLStudent().SaveStudent(student);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return student;
        }

         public List<Student> SearchStudent(string lastName, string email)
        {
            try
            {
                return GetDLStudent().SearchStudent(lastName,email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
           

        }

         public List<StudentCourse> GetStudentRegisteredCourses(int studentID)
         {
             dlStudent = GetDLStudent();
             return dlStudent.GetStudentRegisteredCourses(studentID);

         }

         public List<StudentCourse> GetStudentAvailableCourses(List<StudentCourse> studentRegisteredCourses)
         {
             dlStudent = new DLStudent();
             return dlStudent.GetAvailableCourses(studentRegisteredCourses);
         }

         public bool SaveStudentRegisteredCourses(List<StudentCourse> studentRegisteredCourses, int StudentID)

         {
             dlStudent = new DLStudent();
             return dlStudent.SaveStudentRegisteredCourses(studentRegisteredCourses, StudentID);
         
         }


    }
}
