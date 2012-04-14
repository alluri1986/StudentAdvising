using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace StudentAdvising.Common
{
    [DataContract]
    public class Course : CommonBase
    {
        [DataMember]
        public override int ID
        {
            get
            {
                return base.ID;
            }
            set
            {
                base.ID = value;
            }
        }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Abbreviation { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Credits { get; set; }

        [DataMember]
        public int DepartmentID { get; set; }

        [DataMember]
        public bool EnglishProficiencyFL { get; set; }

        [DataMember]
        public bool IsMandatoryFL { get; set; }

        [DataMember]
        public bool IsElectiveFL { get; set; }







    }
}
