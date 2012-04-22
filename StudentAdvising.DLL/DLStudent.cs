using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using StudentAdvising.Common;
using StudentAdvising.Common.Helper;
using System.Collections;

namespace StudentAdvising.DLL
{
   public class DLStudent
    {
                                               
        public Student SaveStudent(Student student)
        {
            SqlConnection connection = SqlHelper.CreateConnection();
            try
            {
                string spName = "StudentSave";
                

                ArrayList paramList = new ArrayList();
          
                //Creating SqlParameter objects to fields in student
                SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                SqlParameter pLSUID = new SqlParameter("@LSUID", SqlDbType.NVarChar);
                SqlParameter pFirstName = new SqlParameter("@FirstName",SqlDbType.NVarChar);
                SqlParameter pMiddleName = new SqlParameter("@MiddleName", SqlDbType.NVarChar);
                SqlParameter pLastName = new SqlParameter("@LastName", SqlDbType.NVarChar);
                SqlParameter pDOB = new SqlParameter("@DOB", SqlDbType.DateTime);
                SqlParameter pEmail = new SqlParameter("@Email", SqlDbType.NVarChar);
                SqlParameter pPhone = new SqlParameter("@Phone", SqlDbType.NVarChar);
                SqlParameter pDeptID = new SqlParameter("@DeptID", SqlDbType.Int);
                SqlParameter pUserName = new SqlParameter("@UserName",SqlDbType.NVarChar);
                SqlParameter pPassword = new SqlParameter("@Password",SqlDbType.NVarChar);
                SqlParameter pTemporaryAddress =  new SqlParameter("@TemporaryAddress", SqlDbType.NVarChar);
                SqlParameter pHomeAddress = new SqlParameter("@HomeAddress", SqlDbType.NVarChar);
                SqlParameter pAdvisorID = new SqlParameter("@AdvisorID", SqlDbType.Int);
                SqlParameter pApprovalDate = new SqlParameter("@ApprovalDate", SqlDbType.DateTime);
                SqlParameter pIsApprovedFL = new SqlParameter("@IsApprovedFL", SqlDbType.Bit);
                SqlParameter pJoiningSemesterID = new SqlParameter("@JoiningSemesterID", SqlDbType.Int);
                SqlParameter pIsTranferFL = new SqlParameter("@IsTransferFL",SqlDbType.Bit);
                SqlParameter pIsActiveFL = new SqlParameter("@IsActiveFL", SqlDbType.Bit);
                SqlParameter pCreatedBy = new SqlParameter("@CreatedBy", SqlDbType.Int);
                SqlParameter pLastUpdatedBy = new SqlParameter("@LastUpdatedBy", SqlDbType.Int);
                SqlParameter pCreationDate = new SqlParameter("@CreationDate", SqlDbType.DateTime);
                SqlParameter pLastUpdatedDate = new SqlParameter("@LastUpdatedDate", SqlDbType.DateTime);
                pID.Direction = ParameterDirection.InputOutput;

                pID.Value = student.ID;
                pLSUID.Value = student.LSUID;
                pFirstName.Value = student.FirstName;
                pMiddleName.Value = student.MiddleName;
                pLastName.Value = student.LastName;
                pDOB.Value = student.DOB;
                pEmail.Value = student.Email;
                pPhone.Value = student.Phone;
                pDeptID.Value = student.DeptID;
                pUserName.Value = student.UserName;
                pPassword.Value = student.Password;
                pTemporaryAddress.Value = student.TemporaryAddress;
                pHomeAddress.Value = student.HomeAddress;
                pAdvisorID.Value = student.AdvisorID;
                pJoiningSemesterID.Value = student.JoiningSemesterID;
                pApprovalDate.Value = student.ApprovalDate;
                pIsApprovedFL.Value = student.IsApprovedFL;
                pIsTranferFL.Value = student.IsTransferFL;
                pIsActiveFL.Value = student.IsActiveFL;
                pCreatedBy.Value = student.CreatedBy;
                pLastUpdatedBy.Value = student.LastUpdatedBy;
                pCreationDate.Value = student.CreationDate;
                pLastUpdatedDate.Value = student.LastUpdatedDate;

                SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, pID, pLSUID, pFirstName, pMiddleName, pLastName, pDOB, pEmail, pPhone, pDeptID, pUserName,
                                            pPassword, pTemporaryAddress, pHomeAddress, pAdvisorID,pApprovalDate ,pIsApprovedFL,pJoiningSemesterID, pIsTranferFL, pIsActiveFL, pCreatedBy, pLastUpdatedBy, pCreationDate, pLastUpdatedDate);


                student.ID = Convert.ToInt32(pID.Value);

            }
            catch (SqlException sqlEx)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("StudentSave: " + sqlEx.ToString());
            }
            catch (Exception e)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("StudentSave: " + e.ToString());
            }
            finally
            {
                SqlHelper.CloseConnection(connection);
            }

            return student;

        }

        public Student GetStudent(int studentID)
        {
            SqlConnection connection = SqlHelper.CreateConnection();
            StringBuilder sb = new StringBuilder();
            Student st = new Student();
            try
            {
              //Creating SqlParameter objects to fields in student
                sb.Append("SELECT p.ID,p.FirstName,p.LastName,p.MiddleName,p.LSUID,p.Email,p.DeptID,s.JoiningSemesterID,p.IsActiveFL,IsTransferFL,IsApprovedFL");
	            sb.Append("FROM Person p INNER JOIN Student s  ON s.PersonID = p.ID WHERE ID =  " + studentID);

               using(SqlDataReader dr = SqlHelper.ExecuteReader(connection,CommandType.Text,sb.ToString()))
                {
                    if (dr.Read())
                    {
                        st.ID = SqlHelper.ToInt32(dr["ID"]);
                        st.FirstName = SqlHelper.ToString(dr["FirstName"]);
                        st.LastName = SqlHelper.ToString(dr["LastName"]);
                        st.MiddleName = SqlHelper.ToString(dr["MiddleName"]);
                        st.LSUID = SqlHelper.ToString(dr["LSUID"]);
                        st.Email = SqlHelper.ToString(dr["Email"]);
                        st.DeptID = SqlHelper.ToInt32(dr["DeptID"]);
                        st.JoiningSemesterID = SqlHelper.ToInt32(dr["JoiningSemesterID"]);
                        st.IsActiveFL = SqlHelper.ToBool(dr["IsActiveFL"]);
                        st.IsTransferFL = SqlHelper.ToBool(dr["IsTransferFL"]);
                        st.IsApprovedFL = SqlHelper.ToBool(dr["IsApprovedFL"]);
                        st.ApprovalDate = SqlHelper.ToDateTime(dr["ApprovalDate"]);
                        st.AdvisorID = SqlHelper.ToInt32(dr["AdvisorID"]);
                        st.Phone = SqlHelper.ToString(dr["Phone"]);
                        st.UserName = SqlHelper.ToString(dr["UserName"]);
                        st.Password = SqlHelper.ToString(dr["Password"]);
                        st.HomeAddress = SqlHelper.ToString(dr["HomeAddress"]);
                        st.TemporaryAddress = SqlHelper.ToString(dr["TemporaryAddress"]);
                        st.CreatedBy = SqlHelper.ToInt32(dr["CreatedBy"]);
                        st.LastUpdatedBy = SqlHelper.ToInt32(dr["LastUpdatedBy"]);
                        st.CreationDate = SqlHelper.ToDateTime(dr["CreationDate"]);
                        st.LastUpdatedDate = SqlHelper.ToDateTime(dr["LastUpdatedDate"]);

                    }               
                }
            }
            catch (SqlException sqlEx)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("GetStudentDetails: " + sqlEx.ToString());
            }
            catch (Exception e)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("GetStudentDetails: " + e.ToString());
            }
            finally
            {
                SqlHelper.CloseConnection(connection);
            }
            return st;
        }

        public List<Student> SearchStudent(string lastName,string email)
        {
            SqlConnection connection = SqlHelper.CreateConnection();
            List<Student> students = new List<Student>();
            try
            {
                SqlParameter pLastName  = new SqlParameter("@LastName",SqlDbType.NVarChar);
                SqlParameter pEmail     = new SqlParameter("@Email",SqlDbType.NVarChar);

                pLastName.Value         = lastName;
                pEmail.Value            = email;
                string spName           = "SearchStudent";

                using(SqlDataReader dr = SqlHelper.ExecuteReader(connection,CommandType.StoredProcedure,spName,pLastName,pEmail))
                {

                    while (dr.Read())
                    {
                            Student st = new Student();
                            st.ID = SqlHelper.ToInt32(dr["ID"]);
                            st.FirstName = SqlHelper.ToString(dr["FirstName"]);
                            st.LastName = SqlHelper.ToString(dr["LastName"]);
                            st.MiddleName = SqlHelper.ToString(dr["MiddleName"]);
                            st.LSUID = SqlHelper.ToString(dr["LSUID"]);
                            st.Email = SqlHelper.ToString(dr["Email"]);
                            st.DeptID = SqlHelper.ToInt32(dr["DeptID"]);
                            st.JoiningSemesterID = SqlHelper.ToInt32(dr["JoiningSemesterID"]);
                            st.IsActiveFL = SqlHelper.ToBool(dr["IsActiveFL"]);
                            st.IsTransferFL = SqlHelper.ToBool(dr["IsTransferFL"]);
                            st.IsApprovedFL = SqlHelper.ToBool(dr["IsApprovedFL"]);
                            st.ApprovalDate = SqlHelper.ToDateTime(dr["ApprovalDate"]);
                            st.AdvisorID = SqlHelper.ToInt32(dr["AdvisorID"]);
                            st.Phone = SqlHelper.ToString(dr["Phone"]);
                            st.UserName = SqlHelper.ToString(dr["UserName"]);
                            st.Password = SqlHelper.ToString(dr["Password"]);
                            st.HomeAddress = SqlHelper.ToString(dr["HomeAddress"]);
                            st.TemporaryAddress = SqlHelper.ToString(dr["TemporaryAddress"]);
                            st.CreatedBy = SqlHelper.ToInt32(dr["CreatedBy"]);
                            st.LastUpdatedBy = SqlHelper.ToInt32(dr["LastUpdatedBy"]);
                            st.CreationDate = SqlHelper.ToDateTime(dr["CreationDate"]);
                            st.LastUpdatedDate = SqlHelper.ToDateTime(dr["LastUpdatedDate"]);
                            students.Add(st);
                    }
                }

            }
            catch(SqlException sqlEx)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("SearchStudent: " + sqlEx.ToString());
            }
            catch (Exception Ex)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("SearchStudent: " + Ex.ToString());
            }

            return students;
        }


        public List<SemesterCourse> GetSemesterCourses(int semesterID, List<SemesterCourse> courses)
        {
            SqlConnection connection = SqlHelper.CreateConnection();
            StringBuilder sb = new StringBuilder();
            List<SemesterCourse> list = new List<SemesterCourse>();
            try
            {
                ///Get all course that do not have prereq

                foreach (SemesterCourse course in courses)
                {
                    
                }
            }
            catch(Exception Ex)
            {
                SqlHelper.CloseConnection(connection);
            }
            finally
            {
                SqlHelper.CloseConnection(connection);
            }

            return list;
        }

        public List<SemesterCourse> GetIndependentSemesterCourses(int semesterID)
        {
            SqlConnection connection = SqlHelper.CreateConnection();
            StringBuilder sb = new StringBuilder();
            List<SemesterCourse> courses = new List<SemesterCourse>();
            try
            {
                sb.Append(" SELECT ID, SemesterID, CourseID, IsActiveFL,CreationDate,LastUpdatedDate,CreatedBy,LastUpdatedBy ");
                sb.Append(" FROM SemesterCourse WHERE ID NOT IN (SELECT DISTINCT SemesterCourseID FROM SemesterCoursePrerequisite) ");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, CommandType.Text, sb.ToString()))
                {
                    while (dr.Read())
                    {
                        SemesterCourse semesterCourse = new SemesterCourse();
                        semesterCourse.ID = SqlHelper.ToInt32(dr["ID"]);
                        semesterCourse.SemesterID = SqlHelper.ToInt32(dr["SemesterID"]);
                        semesterCourse.CourseID = SqlHelper.ToInt32(dr["CourseID"]);
                        semesterCourse.IsActiveFL = SqlHelper.ToBool(dr["IsActiveFL"]);
                        semesterCourse.CreatedBy = SqlHelper.ToInt32(dr["CreatedBy"]);
                        semesterCourse.LastUpdatedBy = SqlHelper.ToInt32(dr["LastUpdatedBy"]);
                        semesterCourse.CreationDate = SqlHelper.ToDateTime(dr["CreationDate"]);
                        semesterCourse.LastUpdatedDate = SqlHelper.ToDateTime(dr["LastUpdatedDate"]);
                        courses.Add(semesterCourse);
                    }
                }
            }
            catch(SqlException sqlEx)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("GetIndependentSemesterCourses: " + sqlEx.ToString());
            }
            catch (Exception e)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("GetIndependentSemesterCourses: " + e.ToString());

            }
            finally
            {
                SqlHelper.CloseConnection(connection);
            }
            return courses;
        }

       //public List<SemesterCourse> Get


    }
}