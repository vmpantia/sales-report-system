using SalesReportSystem.Database;
using SalesReportSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SalesReportSystem.Controllers
{
    public static class CredentialController
    {
        public static SalesReportSystemDBEntities db = new SalesReportSystemDBEntities();

        #region PasswordRegexPattern
        //At least one upper case English letter, (?=.*?[A - Z])
        //At least one lower case English letter, (?=.*?[a - z])
        //At least one digit, (?=.*?[0 - 9])
        //At least one special character, (?=.*?[#?!@$%^&*-])
        //Minimum eight in length.{8,}(with the anchors)
        public static Regex passwordRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,15}$");
        #endregion

        public static bool IsValidPassword(string password)
        {
            return passwordRegex.IsMatch(password);
        }
    }
}
