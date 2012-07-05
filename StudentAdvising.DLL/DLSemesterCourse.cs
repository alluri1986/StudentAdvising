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
    public class DLSemesterCourse
    {
        public bool SaveSemesterCourses(List<SemesterCourse> semesterCourses)
        {
            SqlConnection connection = SqlHelper.CreateConnection();
            try
            {
                string spName = "SemesterCourseSave";

                ArrayList paramList = new ArrayList();

                //Creating SqlParameter objects to fields in faculty
                SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                SqlParameter pSemesterID = new SqlParameter("@SemesterID", SqlDbType.Int);
                SqlParameter pCourseID = new SqlParameter("@CourseID", SqlDbType.Int);
                SqlParameter pIsActiveFL = new SqlParameter("@IsActiveFL", SqlDbType.Bit);
                SqlParameter pCreatedBy = new SqlParameter("@CreatedBy", SqlDbType.Int);
                SqlParameter pLastUpdatedBy = new SqlParameter("@LastUpdatedBy", SqlDbType.Int);
                SqlParameter pCreationDate = new SqlParameter("@CreationDate", SqlDbType.DateTime);
                SqlParameter pLastUpdatedDate = new SqlParameter("@LastUpdatedDate", SqlDbType.DateTime);
                pID.Direction = ParameterDirection.InputOutput;
                foreach (SemesterCourse semesterCourse in semesterCourses)
                {
                    pID.Value = semesterCourse.ID;
                    pSemesterID.Value = semesterCourse.SemesterID;
                    pCourseID.Value = semesterCourse.CourseID;
                    pIsActiveFL.Value = semesterCourse.IsActiveFL;
                    pCreatedBy.Value = semesterCourse.CreatedBy;
                    pLastUpdatedBy.Value = semesterCourse.LastUpdatedBy;
                    pCreationDate.Value = DateTime.UtcNow;
                    pLastUpdatedDate.Value = DateTime.UtcNow;

                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, pID, pSemesterID,pCourseID, pIsActiveFL, pCreatedBy, pLastUpdatedBy, pCreationDate, pLastUpdatedDate);

                    semesterCourse.ID = Convert.ToInt32(pID.Value);


                }
            }
            catch (SqlException sqlEx)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("SemesterCourseSave: " + sqlEx.ToString());
            }
            catch (Exception e)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("SemesterCourseSave: " + e.ToString());
            }
            finally
            {
                SqlHelper.CloseConnection(connection);
            }

            return true;

        }

        public bool SaveSemesterCourses(int courseID,int fromYear,int toYear, bool Fall,bool Spring ,bool Summer )
        {

            SqlConnection connection = SqlHelper.CreateConnection();
            try
            {
                string spName = "AddSemesterCourse";

                ArrayList paramList = new ArrayList();

                //Creating SqlParameter objects to fields in faculty
                SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                SqlParameter pCourseID = new SqlParameter("@CourseID", SqlDbType.Int);
                SqlParameter pFromYear     = new SqlParameter("@FromYear",SqlDbType.Int);
                SqlParameter pToYear     = new SqlParameter("@ToYear",SqlDbType.Int);
                SqlParameter pFall     = new SqlParameter("@Fall",SqlDbType.Bit);
                SqlParameter pSpring     = new SqlParameter("@Spring",SqlDbType.Bit);
                SqlParameter pSummer     = new SqlParameter("@Summer",SqlDbType.Bit);

                pID.Direction = ParameterDirection.InputOutput;
                
                pCourseID.Value  = courseID;
                pFromYear.Value  = fromYear;
                pToYear.Value    = toYear;
                pFall.Value      = Fall;
                pSpring.Value    = Spring;
                pSummer.Value    = Summer;

                    SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName,pCourseID,pFromYear ,pToYear,pFall,pSpring,pSummer);

                //    int i = 0;
                
            }
            catch (SqlException sqlEx)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("SemesterCourseSave: " + sqlEx.ToString());
            }
            catch (Exception e)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("SemesterCourseSave: " + e.ToString());
            }
            finally
            {
                SqlHelper.CloseConnection(connection);
            }

            return true;


        }


        public List<SemesterCourse> getSemesterCourses(int semesterID)
        {

            StringBuilder sb = new StringBuilder();
            SqlConnection connection = SqlHelper.CreateConnection();
            List<SemesterCourse> listOfCourses = new List<SemesterCourse>();
            try
            {

                sb.Append("SELECT C.ID AS CourseID,Name,SC.ID AS ID,SemesterID");
                sb.Append(" FROM SemesterCourse SC INNER JOIN Course C ON ");
                sb.Append("SC.CourseID = C.ID WHERE SC.SemesterID = "+ semesterID);

               using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, CommandType.Text, sb.ToString()))
                {
                    while (dr.Read())
                    {
                        SemesterCourse semesterCourse = new SemesterCourse();

                        semesterCourse.ID = SqlHelper.ToInt32(dr["ID"]);
                        semesterCourse.CourseName = SqlHelper.ToString(dr["Name"]);
                        semesterCourse.CourseID = SqlHelper.ToInt32(dr["CourseID"]);
                        semesterCourse.SemesterID = SqlHelper.ToInt32(dr["SemesterID"]);

                        listOfCourses.Add(semesterCourse);

                    }
                }

            }
            catch (SqlException sqlEx)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("getSemesterCourses: " + sqlEx.ToString());
            }
            catch (Exception ex)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("getSemesterCourses: " + ex.ToString());
            }
            finally
            {
                SqlHelper.CloseConnection(connection);
            }

            return listOfCourses;
        }

    }
}
