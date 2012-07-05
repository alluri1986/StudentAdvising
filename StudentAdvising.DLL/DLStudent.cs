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
      List<StudentCourse> studentCourses = new List<StudentCourse>();
                     
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
                sb.Append("SELECT p.ID,p.FirstName,p.LastName,p.MiddleName,p.LSUID,p.Email,p.DeptID,s.JoiningSemesterID,s.AdvisorID");
                sb.Append(",p.IsActiveFL,IsTransferFL,IsApprovedFL,ApprovalDate,p.CreatedBy,p.CreationDate,p.LastUpdatedBy,p.LastUpdatedDate");
	            sb.Append(" FROM Person p INNER JOIN Student s  ON s.PersonID = p.ID WHERE ID =  " + studentID);

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
                        //st.Phone = SqlHelper.ToString(dr["Phone"]);
                        //st.UserName = SqlHelper.ToString(dr["UserName"]);
                        //st.Password = SqlHelper.ToString(dr["Password"]);
                        //st.HomeAddress = SqlHelper.ToString(dr["HomeAddress"]);
                        //st.TemporaryAddress = SqlHelper.ToString(dr["TemporaryAddress"]);
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
      public bool AddTransferedCourse(int StudentID, Course course)
        {

            SqlConnection connection = SqlHelper.CreateConnection();
            StringBuilder sb = new StringBuilder();

            try
            {
                //Creating SqlParameter objects to fields in student
                sb.Append("INSERT INTO StudentCourse(StudentID,CourseID,SemesterCourseID,CourseName,ElectiveID,SemesterID,");
                sb.Append("Credits,[Status],IsActiveFL,CreationDate,LastUpdatedDate,CreatedBy,LastUpdatedBy) VALUES");
                sb.Append("(" + StudentID + "," + course.ID + ",0,'" + course.Name + "'");
                sb.Append(",0," + 0 + "," + course.Credits + ",'Pass','" + course.IsActiveFL);
                sb.Append("','" + DateTime.UtcNow + "','" + DateTime.UtcNow + "'," + StudentID + "," + StudentID);
                sb.Append(")");


                SqlHelper.ExecuteNonQuery(connection, CommandType.Text, sb.ToString());
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

            return true;
        }
      public List<StudentCourse> GetTransferedCourses(int StudentID)
        {
            SqlConnection connection = SqlHelper.CreateConnection();
            StringBuilder sb = new StringBuilder();
            List<StudentCourse> studentCourses = new List<StudentCourse>();
            try
            {
                //Creating SqlParameter objects to fields in student
                

                sb.Append("SELECT cour.ID as ID,sc.StudentID as StudentID,sc.SemesterCourseID as SemesterCourseID,cour.Name as CourseName,");
                sb.Append("cour.ID as CourseID,cour.Credits as Credits,cour.IsElectiveAFL as IsElectiveAFL ,cour.IsElectiveBFL as IsElectiveBFL ,");
                sb.Append("sc.SemesterID as SemesterID,sc.[Status] as Status,sc.IsActiveFL as IsActiveFL,sc.CreationDate as CreationDate,");
                sb.Append("sc.LastUpdatedDate as LastUpdatedDate,sc.CreatedBy as CreatedBy,sc.LastUpdatedBy as LastUpdatedBy FROM StudentCourse sc ");
                sb.Append(" JOIN Course cour ON cour.Name = sc.CourseName WHERE StudentID =  " + StudentID + " AND SemesterID =0 ;");
                using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, CommandType.Text, sb.ToString()))
                {
                    while (dr.Read())
                    {
                        StudentCourse sc = new StudentCourse();
                        sc.ID = SqlHelper.ToInt32(dr["ID"]);
                        sc.StudentID = SqlHelper.ToInt32(dr["StudentID"]);
                        sc.SemesterCourseID = SqlHelper.ToInt32(dr["SemesterCourseID"]);
                        sc.CourseID = SqlHelper.ToInt32(dr["CourseID"]);
                        sc.CourseName = SqlHelper.ToString(dr["CourseName"]);
                        sc.Credits = SqlHelper.ToInt32(dr["Credits"]);
                        sc.SemesterID = SqlHelper.ToInt32(dr["SemesterID"]);
                        sc.Status = SqlHelper.ToString(dr["Status"]);
                        sc.IsElectiveAFL = SqlHelper.ToBool(dr["IsElectiveAFL"]);
                        sc.IsElectiveBFL = SqlHelper.ToBool(dr["IsElectiveBFL"]);
                        sc.IsActiveFL = SqlHelper.ToBool(dr["IsActiveFL"]);
                        sc.CreationDate = SqlHelper.ToDateTime(dr["CreationDate"]);
                        sc.LastUpdatedDate = SqlHelper.ToDateTime(dr["LastUpdatedDate"]);
                        sc.CreatedBy = SqlHelper.ToInt32(dr["CreatedBy"]);
                        sc.LastUpdatedBy = SqlHelper.ToInt32(dr["LastUpdatedBy"]);
                        studentCourses.Add(sc);
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
            return studentCourses;

        }
      public List<StudentCourse> GetStudentRegisteredCourses(int studentID)
       {
           StringBuilder sb = new StringBuilder();
           StringBuilder sb1 = new StringBuilder();
           SqlConnection connection = SqlHelper.CreateConnection();
           
           try
           {
             
               sb.Append("SELECT cour.ID as ID,sc.StudentID as StudentID,sc.SemesterCourseID as SemesterCourseID,cour.Name as CourseName,cour.ID as CourseID,");
               sb.Append("cour.Credits as Credits,cour.IsElectiveAFL as IsElectiveAFL ,cour.IsElectiveBFL as IsElectiveBFL ,sc.SemesterID as SemesterID,sc.[Status] as Status,");
               sb.Append("sc.IsActiveFL as IsActiveFL,sc.CreationDate as CreationDate,sc.LastUpdatedDate as LastUpdatedDate,sc.CreatedBy as CreatedBy,");
               sb.Append("sc.LastUpdatedBy as LastUpdatedBy FROM StudentCourse sc INNER JOIN SemesterCourse SemCour ON sc.SemesterCourseID=SemCour.ID ");
               sb.Append(" JOIN Course cour ON cour.ID = SemCour.CourseID WHERE StudentID =  " + studentID + "; ");


               sb1.Append("SELECT sc.ID as ID,sc.StudentID as StudentID,sc.SemesterCourseID as SemesterCourseID ,CourseName,CourseID,Credits,");
               sb1.Append("ElectiveID,SemesterID,[Status],IsActiveFL,CreationDate,sc.LastUpdatedDate as LastUpdatedDate,sc.CreatedBy as CreatedBy,");
               sb1.Append("sc.LastUpdatedBy as LastUpdatedBy FROM StudentCourse sc WHERE (CourseID =0 or SemesterID=0)  and StudentID = " + studentID + "; ");


               using(SqlDataReader dr = SqlHelper.ExecuteReader(connection,CommandType.Text,sb.ToString()))
               {
                   while (dr.Read())
                   {
                       StudentCourse sc  =  new StudentCourse();
                       sc.ID                = SqlHelper.ToInt32(dr["ID"]);
                       sc.StudentID         = SqlHelper.ToInt32(dr["StudentID"]);
                       sc.SemesterCourseID  = SqlHelper.ToInt32(dr["SemesterCourseID"]);
                       sc.CourseID          = SqlHelper.ToInt32(dr["CourseID"]);
                       sc.CourseName        = SqlHelper.ToString(dr["CourseName"]);
                       sc.Credits           = SqlHelper.ToInt32(dr["Credits"]);
                       sc.SemesterID        = SqlHelper.ToInt32(dr["SemesterID"]);
                       sc.Status            = SqlHelper.ToString(dr["Status"]);
                       sc.IsElectiveAFL     = SqlHelper.ToBool(dr["IsElectiveAFL"]);
                       sc.IsElectiveBFL     = SqlHelper.ToBool(dr["IsElectiveBFL"]);
                       sc.IsActiveFL        = SqlHelper.ToBool(dr["IsActiveFL"]);
                       sc.CreationDate      = SqlHelper.ToDateTime(dr["CreationDate"]);
                       sc.LastUpdatedDate   = SqlHelper.ToDateTime(dr["LastUpdatedDate"]);
                       sc.CreatedBy         = SqlHelper.ToInt32(dr["CreatedBy"]);
                       sc.LastUpdatedBy     = SqlHelper.ToInt32(dr["LastUpdatedBy"]);
                       studentCourses.Add(sc);
                   }
               }



               using (SqlDataReader dr1 = SqlHelper.ExecuteReader(connection, CommandType.Text, sb1.ToString()))
               {
                   while (dr1.Read())
                   {

                       StudentCourse sc = new StudentCourse();
                       sc.ID = SqlHelper.ToInt32(dr1["ID"]);
                       sc.StudentID = SqlHelper.ToInt32(dr1["StudentID"]);
                       sc.SemesterCourseID = SqlHelper.ToInt32(dr1["SemesterCourseID"]);
                       sc.CourseID = SqlHelper.ToInt32(dr1["CourseID"]);
                       sc.CourseName = SqlHelper.ToString(dr1["CourseName"]);
                       sc.Credits = SqlHelper.ToInt32(dr1["Credits"]);
                       sc.SemesterID = SqlHelper.ToInt32(dr1["SemesterID"]);
                       sc.Status = SqlHelper.ToString(dr1["Status"]);
                       sc.ElectiveID = SqlHelper.ToInt32(dr1["ElectiveID"]);
                       if (SqlHelper.ToInt32(dr1["ElectiveID"]) == 1)
                       {
                           sc.IsElectiveAFL = true;
                       }
                       else if (SqlHelper.ToInt32(dr1["ElectiveID"]) == 2)
                       {
                           sc.IsElectiveBFL = true;
                       }
                       else if (SqlHelper.ToInt32(dr1["ElectiveID"]) == 3)
                       {
                           sc.GenEd = true;
                       }

                       sc.IsActiveFL = SqlHelper.ToBool(dr1["IsActiveFL"]);
                       sc.CreationDate = SqlHelper.ToDateTime(dr1["CreationDate"]);
                       sc.LastUpdatedDate = SqlHelper.ToDateTime(dr1["LastUpdatedDate"]);
                       sc.CreatedBy = SqlHelper.ToInt32(dr1["CreatedBy"]);
                       sc.LastUpdatedBy = SqlHelper.ToInt32(dr1["LastUpdatedBy"]);
                       studentCourses.Add(sc);
                   }

               }
          
           }
           catch (SqlException sqlEx)
           {
               SqlHelper.CloseConnection(connection);
               throw new Exception("GetStudentSemesterCourses: " + sqlEx.ToString());
           }
           catch (Exception ex)
           {
               SqlHelper.CloseConnection(connection);
               throw new Exception("GetStudentSemesterCourses: " + ex.ToString());
           }
           finally
           {
               SqlHelper.CloseConnection(connection);
           }

           return studentCourses;
       }
      public List<StudentCourse> GetAvailableCourses(List<StudentCourse> studentCourses)
        {
            SqlConnection connection = SqlHelper.CreateConnection();

            List<StudentCourse> availableCourses = new List<StudentCourse>();

            string RegisteredCoursesList = "-";
            foreach (StudentCourse studentCourse in studentCourses)
            {
                RegisteredCoursesList = RegisteredCoursesList + "," + studentCourse.CourseID+"-"+ studentCourse.SemesterID +"-"+studentCourse.Status;
            }
           
           RegisteredCoursesList = RegisteredCoursesList.Replace("-,", "");
           if (RegisteredCoursesList.Length == 1) {
               RegisteredCoursesList = "";
           }

            try
            {
                SqlParameter pCourseList = new SqlParameter("@CourseIDs", SqlDbType.NVarChar);
                SqlParameter pSemester = new SqlParameter("@SemesterID", SqlDbType.Int);
                string spName = "GetAvailableCoursesForStudentCheckingAllPreReqChain";

                //Replace 2 with current semester
                for (int sem = 1; sem <= 12; sem++)
                {
                    pCourseList.Value = RegisteredCoursesList;
                    //RegisteredCoursesList;
                    pSemester.Value = sem;


                    using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, pCourseList, pSemester))
                    {
                        while (dr.Read())
                        {
                            StudentCourse st = new StudentCourse();
                            st.CourseID = SqlHelper.ToInt32(dr["CourseID"]);

                            st.Credits = SqlHelper.ToInt32(dr["Credits"]);
                            st.SemesterCourseID = SqlHelper.ToInt32(dr["SemCourseID"]);
                            st.IsActiveFL = SqlHelper.ToBool(dr["IsActiveFL"]);
                            st.IsElectiveAFL = SqlHelper.ToBool(dr["IsElectiveAFL"]);
                            st.IsElectiveBFL = SqlHelper.ToBool(dr["IsElectiveBFL"]);

                            st.SemesterID = SqlHelper.ToInt32(dr["SemesterID"]);
                            st.CourseName = SqlHelper.ToString(dr["CourseName"]);
                            st.Status = "Not Yet";
                            st.CreatedBy = SqlHelper.ToInt32(dr["CreatedBy"]);
                            st.LastUpdatedBy = SqlHelper.ToInt32(dr["LastUpdatedBy"]);
                            st.CreationDate = SqlHelper.ToDateTime(dr["CreationDate"]);
                            st.LastUpdatedDate = SqlHelper.ToDateTime(dr["LastUpdatedDate"]);
                            availableCourses.Add(st);

                        }
                    }

                }
            }
            catch (SqlException sqlEx)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("SearchStudent: " + sqlEx.ToString());
            }
            catch (Exception Ex)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("SearchStudent: " + Ex.ToString());
            }


            return availableCourses;
        }
      public RegisteredAvailableCourseList GetUpdatedRegisteredCoursesList(RegisteredAvailableCourseList RnAList)
       {

           SqlConnection connection = SqlHelper.CreateConnection();

           List<StudentCourse> availableCourses = new List<StudentCourse>();
            
           List<StudentCourse> RegisteredCourses   =   RnAList.registeredCourses;
           List<StudentCourse> AvailableCourses    =   RnAList.availableCourses;
           string RegisteredCoursesList = "";
           foreach (StudentCourse studentCourse in RegisteredCourses)
           {
               RegisteredCoursesList = RegisteredCoursesList + studentCourse.SemesterCourseID + ",";
           }

           if (RegisteredCoursesList != "" && RegisteredCoursesList != null)
           {
               try
               {
                   SqlParameter pCourseList = new SqlParameter("@CourseIDs", SqlDbType.NVarChar);
                   SqlParameter pRemovedSemesterCourseID = new SqlParameter("@CheckSemesterCourseID", SqlDbType.Int);
                   SqlParameter pToRemoveCourseList = new SqlParameter("@ToRemove", SqlDbType.NVarChar, 100);

                   pToRemoveCourseList.Direction = ParameterDirection.Output;

                   string spName = "GetAllDependenciesChain";

                   RegisteredCoursesList = RegisteredCoursesList.Remove(RegisteredCoursesList.Length - 1);
                   pCourseList.Value = RegisteredCoursesList;
                   pRemovedSemesterCourseID.Value = RnAList.removedSemesterCourseID;

                   SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName,pRemovedSemesterCourseID, pCourseList, 
                       pToRemoveCourseList);

                   string ToRemove = SqlHelper.ToString(pToRemoveCourseList.Value);
                   if(ToRemove!=null && ToRemove!="")
                   {
                   string[] toRemoveCourses = ToRemove.Trim(',').Split(',');


                   foreach (string semestercourseID in toRemoveCourses)
                     {
                       foreach (StudentCourse SC in RegisteredCourses)
                       {
                           if (SC.SemesterCourseID == Convert.ToInt32(semestercourseID))
                           {
                               RegisteredCourses.Remove(SC);
                               break;
                           }
                       }
                   }
                   }
                   RnAList.registeredCourses = RegisteredCourses;

               }

               catch (SqlException sqlEx)
               {
                   SqlHelper.CloseConnection(connection);
                   throw new Exception("SearchStudent: " + sqlEx.ToString());
               }
               catch (Exception Ex)
               {
                   SqlHelper.CloseConnection(connection);
                   throw new Exception("SearchStudent: " + Ex.ToString());
               }

           }
           return RnAList;
       }
      public RegisteredAvailableCourseList GetStudentRegisteredAndAvailableCourses(int studentID,RegisteredAvailableCourseList RnAList)
        {

            List<StudentCourse> RegisteredCourses   =   RnAList.registeredCourses;
            List<StudentCourse> AvailableCourses    =   RnAList.availableCourses;
            if (RnAList.availableCourses == null)
            {
                RegisteredCourses = GetStudentRegisteredCourses(studentID);
                AvailableCourses = GetAvailableCourses(RegisteredCourses);
                RnAList.availableCourses = AvailableCourses;
                RnAList.registeredCourses = RegisteredCourses;
                return RnAList;
            }
            else
            {
                RnAList =  GetUpdatedRegisteredCoursesList(RnAList);
                RnAList.availableCourses = GetAvailableCourses(RnAList.registeredCourses);

            }

            return RnAList;
        }
      public bool SaveStudentRegisteredCourses(List<StudentCourse> studentCourses, int StudentID)
        {
            SqlConnection connection = SqlHelper.CreateConnection();
            StringBuilder sb = new StringBuilder();
            StringBuilder deleteStudentCourses = new StringBuilder();
            
            try
            {
                sb.Append("INSERT INTO StudentCourse(StudentID,CourseID,SemesterCourseID,CourseName,ElectiveID,SemesterID,");
                sb.Append("Credits,[Status],IsActiveFL,CreationDate,LastUpdatedDate,CreatedBy,LastUpdatedBy) VALUES");
                foreach (StudentCourse studentCourse in studentCourses)
                {

                    //sb.Append("SELECT p.ID,p.FirstName,p.LastName,p.MiddleName,p.LSUID,p.Email,p.DeptID,s.JoiningSemesterID,p.IsActiveFL,IsTransferFL,IsApprovedFL");
                    sb.Append("(" +StudentID + "," + studentCourse.CourseID + "," + studentCourse.SemesterCourseID + ",'" + studentCourse.CourseName + "'");
                    sb.Append("," + studentCourse.ElectiveID +","+ studentCourse.SemesterID + "," + studentCourse.Credits + ",'" + studentCourse.Status + "','" + studentCourse.IsActiveFL);
                    sb.Append("','" + DateTime.UtcNow + "','" + DateTime.UtcNow + "'," + StudentID + "," + StudentID);
                    sb.Append("),");
                    
                }
                int x=sb.Length;
                sb.Remove(x-1, 1);
                deleteStudentCourses.Append("DELETE  FROM StudentCourse WHERE StudentID = " + StudentID);
               SqlDataReader dr = SqlHelper.ExecuteReader(connection, CommandType.Text, deleteStudentCourses.ToString());
               dr.Close();
                dr = SqlHelper.ExecuteReader(connection, CommandType.Text, sb.ToString());
             
            }
            catch (Exception exception)
            {
                
            }
            return true;
        }
      public List<StudentCourse> OverRideCourses(int studentID , int SemesterID)
      {
          SqlConnection connection = SqlHelper.CreateConnection();
          StringBuilder sb = new StringBuilder();
          List<StudentCourse> studentCourses = new List<StudentCourse>();

          try
          {
              sb.Append("SELECT SC.ID AS SemesterCourseID,C.ID AS CourseID,C.Name AS CourseName,SC.SemesterID AS SemesterID ,C.Credits AS Credits, ");
              sb.Append("IsElectiveAFL,IsElectiveBFL FROM SemesterCourse SC INNER JOIN Course C ON SC.CourseID = C.ID WHERE C.ID NOT IN");
              sb.Append("(SELECT CourseID FROM StudentCourse WHERE StudentID = "+studentID);
              sb.Append(") AND SemesterID ="+SemesterID);
              
              using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, CommandType.Text, sb.ToString()))
              {
                  while (dr.Read())
                  {
                      StudentCourse sc = new StudentCourse();
                      sc.SemesterCourseID = SqlHelper.ToInt32(dr["SemesterCourseID"]);
                      sc.CourseID = SqlHelper.ToInt32(dr["CourseID"]);
                      sc.CourseName = SqlHelper.ToString(dr["CourseName"]);
                      sc.Credits = SqlHelper.ToInt32(dr["Credits"]);
                      sc.SemesterID = SqlHelper.ToInt32(dr["SemesterID"]);
                      sc.IsElectiveAFL = SqlHelper.ToBool(dr["IsElectiveAFL"]);
                      sc.IsElectiveBFL = SqlHelper.ToBool(dr["IsElectiveBFL"]);
                      studentCourses.Add(sc);
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

          return studentCourses;

      }
      public bool OverRideCourse(int advisorID, StudentCourse sc)
      {
          SqlConnection connection = SqlHelper.CreateConnection();
          StringBuilder sb = new StringBuilder();

          try
          {
              //Creating SqlParameter objects to fields in student
              sb.Append("INSERT INTO StudentCourse(StudentID,CourseID,SemesterCourseID,CourseName,ElectiveID,SemesterID,");
              sb.Append("Credits,[Status],IsActiveFL,CreationDate,LastUpdatedDate,CreatedBy,LastUpdatedBy) VALUES");
              sb.Append("(" + sc.StudentID + "," + sc.CourseID + ","+sc.SemesterCourseID+",'" + sc.CourseName + "'");
              sb.Append(","+sc.ElectiveID+"," +sc.SemesterID + "," + sc.Credits + ",'Pending','" + sc.IsActiveFL);
              sb.Append("','" + DateTime.UtcNow + "','" + DateTime.UtcNow + "'," + advisorID + "," + advisorID);
              sb.Append(")");


              SqlHelper.ExecuteNonQuery(connection, CommandType.Text, sb.ToString());
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

          return true;
      }

    }
}