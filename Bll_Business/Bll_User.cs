using System;
using Dao_BussinessManagement;
using BO_BusinessManagement;
namespace Bll_Business
{
    public static class Bll_User
    {
        public static Bo_User bll_GetUserByUser(string pUser)
        {
            var lUser = new Dao_User();
            return lUser.Dao_getUserByUser(pUser);
        }

        public static string bll_InsertUser(Bo_User pUser)
        {
            var lUser = new Dao_User();
            return lUser.Dao_InsertUser(pUser);
        }
    }
}
