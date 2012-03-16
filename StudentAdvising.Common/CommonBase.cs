using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentAdvising.Common
{
    public class CommonBase
    {
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
        
        public bool IsActiveFL { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public DateTime CreationDate { get; set; }

        public int CreatedBy { get; set; }

        public int LastUpdatedBy { get; set; }

    }
}
