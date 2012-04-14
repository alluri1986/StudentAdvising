using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StudentAdvising.Common
{
    [DataContract]
    public class CommonBase
    {
        [DataMember]
        public virtual int ID
        {
            get
            {
                throw new ApplicationException("ID has not been implemented");
            }

            set
            {
                throw new ApplicationException("ID has not been implemented");
            }
        }
        
        [DataMember]
        public bool IsActiveFL { get; set; }

        [DataMember]
        public DateTime LastUpdatedDate { get; set; }

        [DataMember]
        public DateTime CreationDate { get; set; }

        [DataMember]
        public int CreatedBy { get; set; }

        [DataMember]
        public int LastUpdatedBy { get; set; }

    }
}
