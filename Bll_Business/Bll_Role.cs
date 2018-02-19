using BO_BusinessManagement;
using Dao_BussinessManagement;
using IBusiness.Management;
using System.Collections.Generic;

namespace Bll_Business
{
    public class BllRole : IBusinessRole
    {
        public IList<Bo_Role> GetRolesByUser(int pIdUser)
        {
            var lrole = new Dao_Role();
            return lrole.Dao_getRolesByUser(pIdUser);
        }
    }
}
