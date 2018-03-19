using BO_BusinessManagement;
using IBusiness.Common;
using System.Collections.Generic;

namespace IBusiness.Management
{
    public interface IStatus : IFacade
    {
        List<BoStatus> Bll_getListStatusByIdObject(int pIdObject);
    }
}
