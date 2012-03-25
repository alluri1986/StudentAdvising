using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentAdvising.Common
{
    class Course : CommonBase
    {
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

        public string Name { get; set; }

        public string Abbreviation { get; set; }


        public string Description { get; set; }

        public int Credits { get; set; }

        public int DepartmentID { get; set; }

        public bool EnglishProfiencyFL { get; set; }

        public bool IsMandatoryFL { get; set; }

        public bool IsElectiveFL { get; set; }







    }
}
