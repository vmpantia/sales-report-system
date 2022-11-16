using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReportSystem.Model
{
    public class Constant
    {

        public const string CNTRL_LABEL = "Label";
        public const string CNTRL_TEXTBOX = "TextBox";

        public static char ZERO = '0';

        public const string USR_FRST_ID = "0001";

        public const string USR_NULL_MSG = "User can't be empty";
        public const string USR_NAME_EXIST_MSG = "User full name is already exist in the system";
        public const string USR_FULL_NAME_EXIST_MSG = "Username is already exist in the system";
        public const string USR_PASSWORD_INVALID_MSG = "Your password is invalid";

        public const string ENUM_USR_ERROR_TYPE = "UserErrorType";

        public const string DATE_FRMT_YRMN = "yyyyMM";
    }
}
