using BO_BusinessManagement;
using Dao_BussinessManagement;
using IBusiness.Management;

namespace Bll_Business
{
    public class BllUser : IBusinessUser
    {
        public Bo_User bll_GetUserByUser(string pUser)
        {
            var lUser = new Dao_User();
            return lUser.Dao_getUserByUser(pUser);
        }

        public Bo_User bll_GetUserById(int pIdUser)
        {
            var lUser = new Dao_User();
            return lUser.Dao_getUserById(pIdUser);
        }

        public string bll_InsertUser(Bo_User pUser)
        {
            var lUser = new Dao_User();
            return lUser.Dao_InsertUser(pUser);
        }
    }
}
