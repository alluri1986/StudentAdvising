using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentAdvising.Common
{
     public virtual class CommonBase
    {
        virtual int ID { get; set; }

        bool IsActiveFL { get; set; }

        DateTime LastUpdatedDate { get; set; }

        DateTime CreationDate { get; set; }

        int CreatedBy { get; set; }

        int LastUpdatedBy { get; set; }

    }
}
