using BO_BusinessManagement;
using Dao_BussinessManagement;
namespace Bll_Business
{
    public static class Bll_User
    {
        public static Bo_User bll_GetUserByUser(string pUser)
        {
            var lUser = new Dao_User();
            return lUser.Dao_getUserByUser(pUser);
        }

        public static Bo_User bll_GetUserById(int pIdUser)
        {
            var lUser = new Dao_User();
            return lUser.Dao_getUserById(pIdUser);
        }

        public static string bll_InsertUser(Bo_User pUser)
        {
            var lUser = new Dao_User();
            return lUser.Dao_InsertUser(pUser);
        }
    }
}
