using SalesReportSystem.Database;
using SalesReportSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesReportSystem.Controllers
{
    public static class UserController
    {
        public static SalesReportSystemDBEntities db = new SalesReportSystemDBEntities();

        public static User GetUserByCredentials(string Username, string Password)
        {
            var user = db.Users.Where(data => data.Username == Username && 
                                              data.Password == Password && 
                                              data.Status == 0).ToList();
            if(user.Count() > 0)
            {
                return user.First();
            }
            return null;
        }

        public static bool IsUsernameExist(string Username)
        {
            return db.Users.Where(data => data.Username == Username).Any();
        }

        public static bool IsUserFullNameExist(string firstName, string lastName)
        {
            return db.Users.Where(data => data.Firstname == firstName && data.Lastname == lastName).Any();
        }

        public static UserErrorType ValidateUser(User inputUser)
        {
            if (inputUser == null)
            {
                return UserErrorType.USR_NULL;
            }
            if(IsUserFullNameExist(inputUser.Firstname, inputUser.Lastname))
            {
                return UserErrorType.USR_FULL_NAME_EXIST;
            }
            if (IsUsernameExist(inputUser.Username))
            {
                return UserErrorType.USR_NAME_EXIST;
            }
            if (!CredentialController.IsValidPassword(inputUser.Password))
            {
                return UserErrorType.USR_PASSWORD_INVALID;
            }
            return UserErrorType.USR_NO_ERROR;
        }

        public static bool CreateUser(User inputUser)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    inputUser.UserID = GenerateUserID();
                    db.Users.Add(inputUser);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
                transaction.Commit();
            }
            return true;
        }

        private static string GenerateUserID()
        {
            //Format: USR2022040001
            var yearMonth = DateTime.Now.ToString(Constant.DATE_FRMT_YRMN);
            if (!db.Users.Any())
            {
                //First UserID
                return string.Concat("USR", yearMonth, Constant.USR_FRST_ID);
            }
            var latestUserID = db.Users.ToList().Last().UserID.ToString();
            var count = (int.Parse(latestUserID.Substring(6, 4)) + 1).ToString();
            return string.Concat("USR", yearMonth, count.PadLeft(4, Constant.ZERO));
        }
    }
}
