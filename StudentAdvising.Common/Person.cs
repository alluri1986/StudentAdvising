using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//test
namespace StudentAdvising.Common
{
    public class Person : CommonBase
    {
       
        public string LSUID { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int DeptID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string TemporaryAddress { get; set; }

        public string HomeAddress { get; set; }

    }
}
