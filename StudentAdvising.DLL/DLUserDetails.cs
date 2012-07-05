using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentAdvising.Common;
using System.Data.SqlClient;
using StudentAdvising.Common.Helper;
using System.Data;

namespace StudentAdvising.DLL
{
    public class DLUserDetails
    {
        public UserDetails GetUserDetails(string email)
        {
            UserDetails UD = new UserDetails();
            SqlConnection connection = SqlHelper.CreateConnection();
            try
            {
                SqlParameter pEmail = new SqlParameter("@Email", SqlDbType.NVarChar);

                string spName = "Authenticate";

                pEmail.Value = email;

                using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, CommandType.StoredProcedure, spName, pEmail))
                {

                    while (dr.Read())
                    {
                        UD.Email = SqlHelper.ToString(dr["Email"]);
                        UD.StudentID = SqlHelper.ToInt32(dr["StudentID"]);
                        UD.LSUID = SqlHelper.ToInt32(dr["LSUID"]);
                        UD.FacultyID = SqlHelper.ToInt32(dr["FacultyID"]);
                        UD.JoiningSemesterID = SqlHelper.ToInt32(dr["JoiningSemesterID"]);
                        UD.Role = SqlHelper.ToInt32(dr["Role"]);
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

            return UD;
        }
        /*
        public UserDetails GetUserDetails(int UserID)
        {
            SqlConnection connection = SqlHelper.CreateConnection();
            StringBuilder sb = new StringBuilder();
            Student st = new Student();
            try
            {
                //Creating SqlParameter objects to fields in student
                sb.Append("SELECT p.ID,p.FirstName,p.LastName,p.MiddleName,p.LSUID,p.Email,p.DeptID,s.JoiningSemesterID,p.IsActiveFL,IsTransferFL,IsApprovedFL");
                sb.Append("FROM Person p INNER JOIN Student s  ON s.PersonID = p.ID WHERE ID =  " + studentID);

                using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, CommandType.Text, sb.ToString()))
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
            return null;


        }
*/       
    }
}
