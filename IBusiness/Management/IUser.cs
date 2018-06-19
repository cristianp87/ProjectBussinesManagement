using BO_BusinessManagement;
using IBusiness.Common;

namespace IBusiness.Management
{
    public interface IBusinessUser : IFacade
    {
        BoUser bll_GetUserByUser(string pUser);

        BoUser bll_GetUserById(int pIdUser);

        string bll_InsertUser(BoUser pUser);
    }
}
