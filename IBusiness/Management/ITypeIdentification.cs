using BO_BusinessManagement;
using IBusiness.Common;
using System.Collections.Generic;

namespace IBusiness.Management
{
    public interface ITypeIdentification : IFacade
    {
        List<BoTypeIdentification> bll_getListTypeIdentification();
    }
}
