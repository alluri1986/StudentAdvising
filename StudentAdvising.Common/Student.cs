using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentAdvising.Common
{
    public class Student : Person
    {

        public int PersonID { get; set; }

        public DateTime DOJ { get; set; }

        public bool IsTransferFL { get; set; }

    }
}
