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
                string spName = "SaveStudent";

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
                SqlParameter pDOJ = new SqlParameter("@DOJ",SqlDbType.DateTime);
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
                pDOJ.Value = student.DOJ;
                pIsTranferFL.Value = student.IsTransferFL;
                pIsActiveFL.Value = student.IsActiveFL;
                pCreatedBy.Value = student.CreatedBy;
                pLastUpdatedBy.Value = student.LastUpdatedBy;
                pCreationDate.Value = student.CreationDate;
                pLastUpdatedDate.Value = student.LastUpdatedDate;

                SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, pID, pLSUID, pFirstName, pMiddleName, pLastName, pDOB, pEmail, pPhone, pDeptID, pUserName,
                                            pPassword, pTemporaryAddress, pHomeAddress, pDOJ, pIsTranferFL, pIsActiveFL, pCreatedBy, pLastUpdatedBy, pCreationDate, pLastUpdatedDate);


                student.ID = Convert.ToInt32(pID.Value);

            }
            catch (SqlException sqlEx)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("SaveStudent: " + sqlEx.ToString());
            }
            catch (Exception e)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("SaveStudent: " + e.ToString());
            }
            finally
            {
                SqlHelper.CloseConnection(connection);
            }

            return student;

        }

        

    }
}
