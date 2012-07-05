using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentAdvising.Common
{
    public class ApplicationException : Exception
    {
        int errCode;
        string errDesc;


        public ApplicationException(int ErrorCode,string ErrorDescription)
        {
            errCode = ErrorCode;
            errDesc = ErrorDescription;

        }
        
    }
}
