using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;




namespace StudentAdvising.Common
{
    [DataContract]
    public class Student : Person
    {
        //[DataMember]
        //public int PersonID { get; set; }

        [DataMember]
        public int JoiningSemesterID { get; set; }

        [DataMember]
        public bool IsTransferFL { get; set; }

        [DataMember]
        public int AdvisorID { get; set; }

        [DataMember]
        public DateTime ApprovalDate { get; set; }
        
        [DataMember]
        public bool IsApprovedFL { get; set; }

       
            
        	

    }
}
