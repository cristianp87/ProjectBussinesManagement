using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;

namespace Bll_Business
{
    public static class Bll_Role
    {
        public static IList<Bo_Role> GetRolesByUser(int pIdUser)
        {
            Dao_Role lrole = new Dao_Role();
            return lrole.Dao_getRolesByUser(pIdUser);
        }
    }
}
