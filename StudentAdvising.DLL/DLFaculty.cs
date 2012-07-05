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
    public class DLFaculty
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
                ErrorLog.ErrorRoutine(false, sqlEx);
                //throw new StudentAdvising.Common.ApplicationException(sqlEx.ErrorCode,sqlEx.Message);
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


        public List<Faculty> getFaculty()
        {
            SqlConnection connection = SqlHelper.CreateConnection();
            Faculty faculty = null;
            List<Faculty> facultyList = new List<Faculty>();
            StringBuilder sb = new StringBuilder();
            try
            {
                //Creating SqlParameter objects to fields in student
                sb.Append("SELECT p.ID,p.FirstName,p.LastName,p.MiddleName,p.LSUID,p.Email,p.DeptID,f.IsActiveFL ");
                sb.Append(" FROM Person p INNER JOIN Faculty f  ON f.PersonID = p.ID ");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, CommandType.Text, sb.ToString()))
                {
                     while(dr.Read())
                    {
                        faculty = new Faculty();

                        faculty.ID = SqlHelper.ToInt32(dr["ID"]);
                        faculty.FirstName = SqlHelper.ToString(dr["FirstName"]);
                        faculty.LastName = SqlHelper.ToString(dr["LastName"]);
                        faculty.MiddleName = SqlHelper.ToString(dr["MiddleName"]);
                        faculty.LSUID = SqlHelper.ToString(dr["LSUID"]);
                        faculty.Email = SqlHelper.ToString(dr["Email"]);
                        faculty.DeptID = SqlHelper.ToInt32(dr["DeptID"]);
                        //faculty.IsActiveFL = SqlHelper.ToBool(dr["IsActiveFL"]);
                        //faculty.Phone = SqlHelper.ToString(dr["Phone"]);
                        //faculty.UserName = SqlHelper.ToString(dr["UserName"]);
                        //faculty.Password = SqlHelper.ToString(dr["Password"]);
                        //faculty.HomeAddress = SqlHelper.ToString(dr["HomeAddress"]);
                        //faculty.TemporaryAddress = SqlHelper.ToString(dr["TemporaryAddress"]);
                        //faculty.CreatedBy = SqlHelper.ToInt32(dr["CreatedBy"]);
                        //faculty.LastUpdatedBy = SqlHelper.ToInt32(dr["LastUpdatedBy"]);
                        //faculty.CreationDate = SqlHelper.ToDateTime(dr["CreationDate"]);
                        //faculty.LastUpdatedDate = SqlHelper.ToDateTime(dr["LastUpdatedDate"]);
                        facultyList.Add(faculty);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("GetFacultyDetails: " + sqlEx.ToString());
            }
            catch (Exception e)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("GetFacultyDetails: " + e.ToString());
            }
            finally
            {
                SqlHelper.CloseConnection(connection);
            }
            return facultyList;
        }



    }
}
