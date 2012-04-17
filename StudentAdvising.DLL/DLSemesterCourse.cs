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
    class DLSemesterCourse
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
                    pCreationDate.Value = semesterCourse.CreationDate;
                    pLastUpdatedDate.Value = semesterCourse.LastUpdatedDate;

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



    }
}
