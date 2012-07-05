using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentAdvising.DLL;
using StudentAdvising.Common;

namespace StudentAdvising.BLL
{
    public class BLDepartment
    {

        private DLDepartment dlDepartment = null;


        public DLDepartment GetDLDepartment()
        {
            if (dlDepartment == null)
                dlDepartment = new DLDepartment();

            return dlDepartment;
        }


        public bool SaveDepartment(Department department)
        {
            try
            {
                department.CreationDate = DateTime.UtcNow;
                department.LastUpdatedDate = DateTime.UtcNow;
                return GetDLDepartment().SaveDepartment(department);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            
        }

        public List<Department> getLuDepartment()
        {

            return GetDLDepartment().getLuDepartment();
        }
    }
}
