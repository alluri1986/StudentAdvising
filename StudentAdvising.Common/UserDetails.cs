using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StudentAdvising.Common
{
   public class UserDetails
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }
       
       
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public bool IsTransfered { get; set; }

        [DataMember]
        public int Role { get; set; }
       
        [DataMember]
        public int StudentID { get; set; }

        [DataMember]
        public int FacultyID { get; set; }

        [DataMember]
        public int JoiningSemesterID { get; set; }

        [DataMember]
        public int LSUID { get; set; }
    }
}
