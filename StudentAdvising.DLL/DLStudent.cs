using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using StudentAdvising.Common;
using StudentAdvising.Common.Helper;

namespace StudentAdvising.DLL
{
    class DLStudent
    {

        public Student SaveStudent(Student student)
        {
            SqlConnection connection = SqlHelper.CreateConnection();
            try
            {
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

        public Student GetStudent(int studentID)
        {
            SqlConnection connection = SqlHelper.CreateConnection();
            StringBuilder sb = new StringBuilder();
            Student student = new Student();
            try
            {
                sb.Append( "SELECT p.ID,p.LSUID,p.FirstName,p.MiddleName, p.LastName, p.DOB, p.Email, p.Phone,");
                sb.Append(" p.DeptID, p.UserName, p.Password, p.TemporaryAddress, p.HomeAddress,s.DOJ,s.IsTransferFL,");
                sb.Append(" s.IsActiveFL, s.CreationDate, s.LastUpdatedDate, s.CreatedBy, s.LastUpdatedBy ");
                sb.Append(" FROM Person p INNER JOIN Student s ON p.ID = s.PersonID ");
                sb.Append(" WHERE s.PersonID = " + studentID );

                using(SqlDataReader dr = SqlHelper.ExecuteReader(connection,CommandType.Text,sb.ToString()))
                {
                    if (dr.Read())
                    {
                        student.ID = SqlHelper.ToInt32(dr["ID"]);
                    }
                }
               
                //sb.Append(" WHERE p.ID = " + SqlHelper);
            }
            catch( SqlException sqlEx)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception(this.GetType().FullName + "GetStudent: " + sqlEx.ToString());
            }
            catch(Exception e)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("GetStudent: " + e.ToString());
            }
            finally
            {
                SqlHelper.CloseConnection(connection);
            }
            return student;
        }

    }
}
