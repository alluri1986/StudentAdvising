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
                sb.Append( "SELECT ID,LSUID,FirstName,MiddleName, LastName, DOB, Email, Phone,");
                sb.Append(" DeptID, UserName, Password, TemporaryAddress, HomeAddress,DOJ,IsTransferFL,");
                sb.Append(" IsActiveFL, CreationDate, LastUpdatedDate, CreatedBy, LastUpdatedBy ");
                sb.Append(" FROM Person p INNER JOIN Student s ");
                sb.Append(" ON p.ID = s.PersonID");
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
        }

    }
}
