using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentAdvising.DLL;
using StudentAdvising.Common;

namespace StudentAdvising.BLL
{
    class BLSearchStudent
    {

        private DLStudent dlStudent = null;

        public DLStudent GetDLStudent()
        {
            if (dlStudent == null)
                dlStudent = new DLStudent();

            return dlStudent;
        }

       
    }
}
