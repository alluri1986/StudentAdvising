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
   public class DLCoursePrerequisite
    {

       public void SaveCoursePrerequisite(List<CoursePrerequisite> coursePreReq)
        {
            SqlConnection connection = SqlHelper.CreateConnection();
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



    }
}
