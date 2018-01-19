using BO_BusinessManagement;
using Dao_BussinessManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
