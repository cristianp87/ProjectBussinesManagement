using BO_BusinessManagement;
using IBusiness.Common;
using System.Collections.Generic;

namespace IBusiness.Management
{
    public interface IBusinessRole : IFacade
    {
         IList<BoRole> GetRolesByUser(int pIdUser);
    }
}
