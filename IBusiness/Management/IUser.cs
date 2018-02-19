using BO_BusinessManagement;
using IBusiness.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Management
{
    public interface IBusinessUser : IFacade
    {
        Bo_User bll_GetUserByUser(string pUser);

        Bo_User bll_GetUserById(int pIdUser);

        string bll_InsertUser(Bo_User pUser);
    }
}
