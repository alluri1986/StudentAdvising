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
    class DLFaculty
    {
        public Faculty SaveFaculty(Faculty faculty)
        {
            SqlConnection connection = SqlHelper.CreateConnection();
            try
            {
                string spName = "FacultySave";

                ArrayList paramList = new ArrayList();

                //Creating SqlParameter objects to fields in faculty
                SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                SqlParameter pLSUID = new SqlParameter("@LSUID", SqlDbType.NVarChar);
                SqlParameter pFirstName = new SqlParameter("@FirstName", SqlDbType.NVarChar);
                SqlParameter pMiddleName = new SqlParameter("@MiddleName", SqlDbType.NVarChar);
                SqlParameter pLastName = new SqlParameter("@LastName", SqlDbType.NVarChar);
                SqlParameter pDOB = new SqlParameter("@DOB", SqlDbType.DateTime);
                SqlParameter pEmail = new SqlParameter("@Email", SqlDbType.NVarChar);
                SqlParameter pPhone = new SqlParameter("@Phone", SqlDbType.NVarChar);
                SqlParameter pDeptID = new SqlParameter("@DeptID", SqlDbType.Int);
                SqlParameter pUserName = new SqlParameter("@UserName", SqlDbType.NVarChar);
                SqlParameter pPassword = new SqlParameter("@Password", SqlDbType.NVarChar);
                SqlParameter pTemporaryAddress = new SqlParameter("@TemporaryAddress", SqlDbType.NVarChar);
                SqlParameter pHomeAddress = new SqlParameter("@HomeAddress", SqlDbType.NVarChar);
                SqlParameter pIsActiveFL = new SqlParameter("@IsActiveFL", SqlDbType.Bit);
                SqlParameter pCreatedBy = new SqlParameter("@CreatedBy", SqlDbType.Int);
                SqlParameter pLastUpdatedBy = new SqlParameter("@LastUpdatedBy", SqlDbType.Int);
                SqlParameter pCreationDate = new SqlParameter("@CreationDate", SqlDbType.DateTime);
                SqlParameter pLastUpdatedDate = new SqlParameter("@LastUpdatedDate", SqlDbType.DateTime);
                pID.Direction = ParameterDirection.InputOutput;

                pID.Value = faculty.ID;
                pLSUID.Value = faculty.LSUID;
                pFirstName.Value = faculty.FirstName;
                pMiddleName.Value = faculty.MiddleName;
                pLastName.Value = faculty.LastName;
                pDOB.Value = faculty.DOB;
                pEmail.Value = faculty.Email;
                pPhone.Value = faculty.Phone;
                pDeptID.Value = faculty.DeptID;
                pUserName.Value = faculty.UserName;
                pPassword.Value = faculty.Password;
                pTemporaryAddress.Value = faculty.TemporaryAddress;
                pHomeAddress.Value = faculty.HomeAddress;
                pIsActiveFL.Value = faculty.IsActiveFL;
                pCreatedBy.Value = faculty.CreatedBy;
                pLastUpdatedBy.Value = faculty.LastUpdatedBy;
                pCreationDate.Value = faculty.CreationDate;
                pLastUpdatedDate.Value = faculty.LastUpdatedDate;

                SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, pID, pLSUID, pFirstName, pMiddleName, pLastName, pDOB, pEmail, pPhone, pDeptID, pUserName,
                                            pPassword, pTemporaryAddress, pHomeAddress, pIsActiveFL, pCreatedBy, pLastUpdatedBy, pCreationDate, pLastUpdatedDate);


                faculty.ID = Convert.ToInt32(pID.Value);

            }
            catch (SqlException sqlEx)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("FacultySave: " + sqlEx.ToString());
            }
            catch (Exception e)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("FacultySave: " + e.ToString());
            }
            finally
            {
                SqlHelper.CloseConnection(connection);
            }

            return faculty;

        }



    }
}
