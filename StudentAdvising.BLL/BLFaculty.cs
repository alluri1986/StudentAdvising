using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentAdvising.DLL;
using StudentAdvising.Common;

namespace StudentAdvising.BLL
{
    public class BLFaculty
    {
        private DLFaculty dlFaculty = null;

        public DLFaculty GetDLFaculty()
        {
            if (dlFaculty == null)
            {
                dlFaculty = new DLFaculty();
            }
            return dlFaculty;
        }

        public Faculty SaveFaculty(Faculty faculty)
        {
            try
            {
                faculty.CreationDate = DateTime.UtcNow;
                faculty.LastUpdatedDate = DateTime.UtcNow;
                GetDLFaculty().SaveFaculty(faculty);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return faculty;
        }


        public List<Faculty> GetFaculty()
        {
            return GetDLFaculty().getFaculty();

        }

    }
}
