using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StudentAdvising.Common;
using StudentAdvising.Common.Helper;
using System.Collections;

namespace StudentAdvising.DLL
{
    public class DLCourse
    {
        public Course SaveCourse(Course course)
        {

            SqlConnection connection = SqlHelper.CreateConnection();
            try
            {
                string spName = "CourseSave";

                ArrayList paramList = new ArrayList();


             //Creating SqlParameter objects to fields in course
                SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                SqlParameter pName = new SqlParameter("@Name", SqlDbType.NVarChar);
                SqlParameter pAbbreviation = new SqlParameter("@Abbreviation", SqlDbType.NVarChar);
                SqlParameter pDescription = new SqlParameter("@Description", SqlDbType.NVarChar);
                SqlParameter pCredits = new SqlParameter("@Credits", SqlDbType.Int);
                SqlParameter pDepartmentID = new SqlParameter("@DepartmentID", SqlDbType.Int);
                SqlParameter pEnglishProficiencyFL = new SqlParameter("@EnglishProficiencyFL", SqlDbType.Bit);
                SqlParameter pIsMandatoryFL = new SqlParameter("@IsMandatoryFL", SqlDbType.Bit);
                SqlParameter pIsElectiveAFL = new SqlParameter("@IsElectiveAFL", SqlDbType.Bit);
                SqlParameter pIsElectiveBFL = new SqlParameter("@IsElectiveBFL", SqlDbType.Bit);
                SqlParameter pIsActiveFL = new SqlParameter("@IsActiveFL", SqlDbType.Bit);
                SqlParameter pCreatedBy = new SqlParameter("@CreatedBy", SqlDbType.Int);
                SqlParameter pLastUpdatedBy = new SqlParameter("@LastUpdatedBy", SqlDbType.Int);
                SqlParameter pCreationDate = new SqlParameter("@CreationDate", SqlDbType.DateTime);
                SqlParameter pLastUpdatedDate = new SqlParameter("@LastUpdatedDate", SqlDbType.DateTime);
                pID.Direction = ParameterDirection.InputOutput;


                pID.Value                   =       course.ID;					
                pName.Value		            =       course.Name;		
                pAbbreviation.Value         =       course.Abbreviation;
                pDescription.Value          =       course.Description;    	
                pCredits.Value              =       course.Credits;
                pDepartmentID.Value         =       course.DepartmentID;
                pEnglishProficiencyFL.Value =       course.EnglishProficiencyFL;
                pIsMandatoryFL.Value        =       course.IsMandatoryFL;
                pIsElectiveAFL.Value        =       course.IsElectiveAFL	;
                pIsElectiveBFL.Value        =       course.IsElectiveBFL;
                pIsActiveFL.Value           =       course.IsActiveFL;		
                pCreationDate.Value         =       course.CreationDate;
                pLastUpdatedDate.Value      =       course.LastUpdatedDate;
                pCreatedBy.Value            =       course.CreatedBy;
                pLastUpdatedBy.Value        =       course.LastUpdatedBy;


                SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, pID, pName, pAbbreviation, pDescription, pCredits, pDepartmentID,
                    pEnglishProficiencyFL, pIsMandatoryFL, pIsElectiveAFL,pIsElectiveBFL ,pIsActiveFL, pCreationDate, pLastUpdatedDate, pCreatedBy, pLastUpdatedBy);

                course.ID = Convert.ToInt32(pID.Value);

            }
            catch (SqlException sqlEx)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("CourseSave: " + sqlEx.ToString());
            }
            catch (Exception e)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("CourseSave: " + e.ToString());
            }
            finally
            {
                SqlHelper.CloseConnection(connection);
            }

            return course;

        }

        public List<Course> GetCourses()
        {


           StringBuilder sb = new StringBuilder();
           SqlConnection connection = SqlHelper.CreateConnection();
           List<Course> listOfCourses = new List<Course>();
           try
           {

               sb.Append("SELECT ID,Name,Abbreviation,[Description],DepartmentID,Credits,EnglishProficiencyFL,IsMandatoryFL,IsElectiveAFL,");
               sb.Append("IsElectiveBFL,IsActiveFL FROM Course ORDER BY Name");
               

               using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, CommandType.Text, sb.ToString()))
               {
                   while (dr.Read())
                   {
                       Course course = new Course();

                       course.ID                    =   SqlHelper.ToInt32(dr["ID"]);
                       course.Name                  =   SqlHelper.ToString(dr["Name"]);
                       course.Abbreviation          =   SqlHelper.ToString(dr["Abbreviation"]);
                       course.DepartmentID = SqlHelper.ToInt32(dr["DepartmentID"]); 
                       if (dr["Description"] != null)
                       {
                           course.Description       =   SqlHelper.ToString(dr["Description"]);
                       }
                       course.Credits               =   SqlHelper.ToInt32(dr["Credits"]);
                       course.EnglishProficiencyFL  =   SqlHelper.ToBool(dr["EnglishProficiencyFL"]);
                       course.IsMandatoryFL         =   SqlHelper.ToBool(dr["IsMandatoryFL"]);
                       course.IsElectiveAFL         =   SqlHelper.ToBool(dr["IsElectiveAFL"]);
                       course.IsElectiveBFL         =   SqlHelper.ToBool(dr["IsElectiveBFL"]);
                       course.IsActiveFL            =   SqlHelper.ToBool(dr["IsActiveFL"]);
                       listOfCourses.Add(course);
                       
                   }
               }

           }
           catch (SqlException sqlEx)
           {
               SqlHelper.CloseConnection(connection);
               throw new Exception("GetCourses: " + sqlEx.ToString());
           }
           catch (Exception ex)
           {
               SqlHelper.CloseConnection(connection);
               throw new Exception("GetCourses: " + ex.ToString());
           }
           finally
           {
               SqlHelper.CloseConnection(connection);
           }

           return listOfCourses;
        }

        public void SaveCoursePrerequisite(int CourseID,List<CoursePrerequisite> coursePreReq)
        {
            SqlConnection connection = SqlHelper.CreateConnection();
            StringBuilder sb = new StringBuilder();

            //CoursePrerequisite coursePrerequisite = new CoursePrerequisite();
            try
            {
                string spName = "CoursePrerequisiteSave";

                ArrayList paramList = new ArrayList();

                //Creating SqlParameter objects to fields in CoursePrerequisite
                SqlParameter pCourseID = new SqlParameter("@CourseID", SqlDbType.Int);
                SqlParameter pPreReqID = new SqlParameter("@PreReqID", SqlDbType.Int);
                SqlParameter pIsDependencyFL = new SqlParameter("@IsDependencyFL", SqlDbType.Int);
                SqlParameter pIsActiveFL = new SqlParameter("@IsActiveFL", SqlDbType.Bit);
                SqlParameter pCreatedBy = new SqlParameter("@CreatedBy", SqlDbType.Int);
                SqlParameter pLastUpdatedBy = new SqlParameter("@LastUpdatedBy", SqlDbType.Int);
                SqlParameter pCreationDate = new SqlParameter("@CreationDate", SqlDbType.DateTime);
                SqlParameter pLastUpdatedDate = new SqlParameter("@LastUpdatedDate", SqlDbType.DateTime);

                //Deleting existing preRequisites
                sb.Append("DELETE FROM  CoursePrerequisite  WHERE CourseID =" + CourseID);

                SqlHelper.ExecuteNonQuery(connection, CommandType.Text, sb.ToString());

                foreach (CoursePrerequisite coursePrerequisite in coursePreReq)
                {
                    coursePrerequisite.CreationDate = DateTime.UtcNow;
                    coursePrerequisite.LastUpdatedDate = DateTime.UtcNow;

                    pCourseID.Value = coursePrerequisite.CourseID;
                    pPreReqID.Value = coursePrerequisite.PreReqID;
                    pIsDependencyFL.Value = coursePrerequisite.IsDependencyFL;
                    pIsActiveFL.Value = coursePrerequisite.IsActiveFL;
                    pCreationDate.Value = coursePrerequisite.CreationDate;
                    pLastUpdatedDate.Value = coursePrerequisite.LastUpdatedDate;
                    pCreatedBy.Value = coursePrerequisite.CreatedBy;
                    pLastUpdatedBy.Value = coursePrerequisite.LastUpdatedBy;



                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, pCourseID, pPreReqID, pIsDependencyFL,
                        pIsActiveFL, pCreationDate, pLastUpdatedDate, pCreatedBy, pLastUpdatedBy);

                }

            }
            catch (SqlException sqlEx)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("CoursePrerequisiteSave: " + sqlEx.ToString());
            }
            catch (Exception e)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("CoursePrerequisiteSave: " + e.ToString());
            }
            finally
            {
                SqlHelper.CloseConnection(connection);
            }



        }

        public List<CoursePrerequisite> GetCoursePreRequisites(int CourseID)
        {

            StringBuilder sb = new StringBuilder();
            SqlConnection connection = SqlHelper.CreateConnection();
            List<CoursePrerequisite> listOfPreReqs = new List<CoursePrerequisite>();
            try
            {

                sb.Append("SELECT C.ID as CourseID,Name,IsDependencyFL FROM CoursePrerequisite CP INNER JOIN Course C ON C.ID = CP.PreReqID ");
                sb.Append("WHERE CP.IsActiveFL = 1 AND CP.CourseID = "+CourseID);


                using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, CommandType.Text, sb.ToString()))
                {
                    while (dr.Read())
                    {
                        CoursePrerequisite coursePreRequisite = new CoursePrerequisite();
                        
                        coursePreRequisite.ID = SqlHelper.ToInt32(dr["CourseID"]);
                        coursePreRequisite.PreReqCourseName = SqlHelper.ToString(dr["Name"]);
                        coursePreRequisite.IsDependencyFL = SqlHelper.ToBool(dr["IsDependencyFL"]);
                        listOfPreReqs.Add(coursePreRequisite);

                    }
                }

            }
            catch (SqlException sqlEx)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("GetCourses: " + sqlEx.ToString());
            }
            catch (Exception ex)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("GetCourses: " + ex.ToString());
            }
            finally
            {
                SqlHelper.CloseConnection(connection);
            }

            return listOfPreReqs;



        }
    }
}
