using BO_BusinessManagement;
using IBusiness.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Management
{
    public interface IBusinessRole : IFacade
    {
         IList<Bo_Role> GetRolesByUser(int pIdUser);
    }
}
