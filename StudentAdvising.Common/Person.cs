using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
//test
namespace StudentAdvising.Common
{
    [DataContract]
    public class Person : CommonBase
    {
        private int iD = Int32.MinValue;

        [DataMember]
        public override int ID
        {
            get
            {
                return iD;
            }
            set
            {
                iD = value;
            }
        }

        [DataMember]
        public string LSUID { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public DateTime DOB { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public int DeptID { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string TemporaryAddress { get; set; }

        [DataMember]
        public string HomeAddress { get; set; }

    }
}
