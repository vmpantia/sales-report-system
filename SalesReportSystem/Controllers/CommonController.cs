using SalesReportSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesReportSystem.Controllers
{
    public static class CommonController
    {
        public static void ResetInput(params object[] inputFields)
        {
            foreach(var input in inputFields)
            {
                Type inputType = input.GetType();

                switch(inputType.Name)
                {
                    case Constant.CNTRL_LABEL:
                        {
                            ((Label)input).Text = String.Empty;
                            break;
                        }
                    case Constant.CNTRL_TEXTBOX:
                        {
                            ((TextBox)input).Text = String.Empty;
                            break;
                        }
                }
            }
        }

        public static string GetErrorMessage(object inputErrorType)
        {
            Type errorType = inputErrorType.GetType();
            switch(errorType.Name)
            {
                case Constant.ENUM_USR_ERROR_TYPE:
                    switch((UserErrorType)inputErrorType)
                    {
                        case UserErrorType.USR_NULL:
                            return Constant.USR_NULL_MSG;
                        case UserErrorType.USR_FULL_NAME_EXIST:
                            return Constant.USR_NAME_EXIST_MSG;
                        case UserErrorType.USR_NAME_EXIST:
                            return Constant.USR_FULL_NAME_EXIST_MSG;
                        default:
                            return Constant.USR_PASSWORD_INVALID_MSG;
                    }
                default: return String.Empty;
            }
        }
    }
}
