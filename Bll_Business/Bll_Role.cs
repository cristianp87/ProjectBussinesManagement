using BO_BusinessManagement;
using Dao_BussinessManagement;
using IBusiness.Management;
using System.Collections.Generic;
using IDaoBusiness.Business;

namespace Bll_Business
{
    public class BllRole : IBusinessRole
    {
        public IDaoRole LiDaoRole { get; set; }
        public BllRole()
        {
            this.LiDaoRole = new DaoRole();
        }
        public IList<BoRole> GetRolesByUser(int pIdUser)
        {
            return this.LiDaoRole.Dao_getRolesByUser(pIdUser);
        }
    }
}
