using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentAdvising.DLL;


namespace StudentAdvising.BLL
{
    class BLStudent
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
