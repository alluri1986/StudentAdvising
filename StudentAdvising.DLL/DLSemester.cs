using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using StudentAdvising.Common;
using System.Data.SqlClient;
using StudentAdvising.Common.Helper;
using System.Data;

namespace StudentAdvising.DLL
{
    public class DLSemester
    {

        public List<Semester> getLuSemester()
        {
            SqlConnection connection = SqlHelper.CreateConnection();
            StringBuilder sb = new StringBuilder();
            List<Semester> semesterList = new List<Semester>();


            try
            {

                sb.Append("SELECT ID,Name,Year,Description FROM LuSemester WHERE IsActiveFL =  1");

                using (SqlDataReader dr = SqlHelper.ExecuteReader(connection, CommandType.Text, sb.ToString()))
                {
                    while (dr.Read())
                    {
                        Semester semester = new Semester();
                        semester.ID = SqlHelper.ToInt32(dr["ID"]);
                        semester.semester = SqlHelper.ToString(dr["Name"]);
                        semester.year = SqlHelper.ToInt32(dr["Year"]);
                        semesterList.Add(semester);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                SqlHelper.CloseConnection(connection);
                throw new Exception("GetStudentDetails: " + sqlEx.ToString());
            }

            return semesterList;
        }
    }
}
