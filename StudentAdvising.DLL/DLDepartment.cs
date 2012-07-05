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
    public class DLDepartment
    {
       public bool SaveDepartment(Department department)
        {
           SqlConnection connection = SqlHelper.CreateConnection();
            try
            {
                string spName = "DepartmentSave";

                ArrayList paramList = new ArrayList();

                //Creating SqlParameter objects to fields in course
                SqlParameter pID = new SqlParameter("@ID", SqlDbType.Int);
                SqlParameter pName = new SqlParameter("@Name", SqlDbType.NVarChar);
                SqlParameter pAbbreviation = new SqlParameter("@Abbreviation", SqlDbType.NVarChar);
                SqlParameter pDescription = new SqlParameter("@Description", SqlDbType.NVarChar);
                SqlParameter pIsActiveFL = new SqlParameter("@IsActiveFL", SqlDbType.Bit);
                SqlParameter pCreatedBy = new SqlParameter("@CreatedBy", SqlDbType.Int);
                SqlParameter pLastUpdatedBy = new SqlParameter("@LastUpdatedBy", SqlDbType.Int);
                SqlParameter pCreationDate = new SqlParameter("@CreationDate", SqlDbType.DateTime);
                SqlParameter pLastUpdatedDate = new SqlParameter("@LastUpdatedDate", SqlDbType.DateTime);
                pID.Direction = ParameterDirection.InputOutput;


                pID.Value = department.DeptID;
                pName.Value = department.Name;
                pAbbreviation.Value = department.Abbreviation;
                pDescription.Value = department.Description;
                pIsActiveFL.Value = department.IsActiveFL;
                pCreationDate.Value = department.CreationDate;
                pLastUpdatedDate.Value = DateTime.UtcNow;
                pCreatedBy.Value = department.CreatedBy;
                pLastUpdatedBy.Value = department.LastUpdatedBy;


                SqlHelper.ExecuteNonQuery(connection, CommandType.StoredProcedure, spName, pID, pName, pAbbreviation, pDescription,
                     pIsActiveFL, pCreationDate, pLastUpdatedDate, pCreatedBy, pLastUpdatedBy);

                department.DeptID = Convert.ToInt32(pID.Value);

            }
            catch (SqlException sqlEx)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("DepartmentSave: " + sqlEx.ToString());
            }
            catch (Exception e)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("DepartmentSave: " + e.ToString());
            }
            finally
            {
                SqlHelper.CloseConnection(connection);
            }

            return true;

        }

       public List<Department> getLuDepartment()
       {
           SqlConnection connection = SqlHelper.CreateConnection();
           StringBuilder sb = new StringBuilder();
           List<Department> departmentList = new List<Department>();


           try
           {
               sb.Append("SELECT ID,Name,[Description],Abbreviation,IsActiveFL,CreatedBy,CreationDate,LastUpdatedBy,");
               sb.Append("LastUpdatedDate FROM LuDepartment");

               using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, CommandType.Text, sb.ToString()))
               {
                   while (dr.Read())
                   {
                       Department department = new Department();
                       department.DeptID = SqlHelper.ToInt32(dr["ID"]);
                       department.Name = SqlHelper.ToString(dr["Name"]);
                       department.Abbreviation = SqlHelper.ToString(dr["Abbreviation"]);
                       department.Description = SqlHelper.ToString(dr["Description"]);
                       department.IsActiveFL = SqlHelper.ToBool(dr["IsActiveFL"]);

                       department.CreationDate = SqlHelper.ToDateTime(dr["CreationDate"]);
                       department.LastUpdatedDate = SqlHelper.ToDateTime(dr["LastUpdatedDate"]);
                       department.CreatedBy = SqlHelper.ToInt32(dr["CreatedBy"]);
                       department.LastUpdatedBy = SqlHelper.ToInt32(dr["LastUpdatedBy"]);
                       departmentList.Add(department);
                   }
               }
           }
           catch (SqlException sqlEx)
           {
               SqlHelper.CloseConnection(connection);
               throw new Exception("getLuDepartment : " + sqlEx.ToString());
           }

           return departmentList;
       }

    }
}
