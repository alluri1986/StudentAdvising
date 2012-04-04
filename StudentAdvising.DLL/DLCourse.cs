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
    class DLCourse
    {
        public Course saveCourse(Course course)
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
                SqlParameter pIsElectiveFL = new SqlParameter("@IsElectiveFL", SqlDbType.Bit);
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
                pIsElectiveFL.Value         =       course.IsElectiveFL	;
                pIsActiveFL.Value           =       course.IsActiveFL;		
                pCreationDate.Value         =       course.CreationDate;
                pLastUpdatedDate.Value      =       course.LastUpdatedDate;
                pCreatedBy.Value            =       course.CreatedBy;
                pLastUpdatedBy.Value        =       course.LastUpdatedBy;


                SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, pID, pName, pAbbreviation, pDescription, pCredits, pDepartmentID,
                    pEnglishProficiencyFL, pIsMandatoryFL, pIsElectiveFL, pIsActiveFL, pCreationDate, pLastUpdatedDate, pCreatedBy, pLastUpdatedBy);

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



    }
}
