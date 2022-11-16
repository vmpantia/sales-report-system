using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReportSystem.Model
{
    public enum UserErrorType
    {
        USR_NO_ERROR = 0,
        USR_NULL,
        USR_NAME_EXIST,
        USR_FULL_NAME_EXIST,
        USR_PASSWORD_INVALID
    }
}
