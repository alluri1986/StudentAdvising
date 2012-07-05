using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentAdvising.Common;
using StudentAdvising.DLL;

namespace StudentAdvising.BLL
{
    public class BLUserDetails
    {

        public UserDetails GetUserDetails(string email)
        {
            DLUserDetails dlud = new DLUserDetails();
            return dlud.GetUserDetails(email);
        }
    }
}
