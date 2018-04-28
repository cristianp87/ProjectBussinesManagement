using BO_BusinessManagement;
using IBusiness.Common;
using System.Collections.Generic;

namespace IBusiness.Management
{
    public interface IUtilsLib : IFacade
    {
        BoObject bll_GetObjectByName(string pNameObject);

        List<BoUnit> bll_GetAllUnit();

        BoStatus bll_getStatusApproByObject(int pIdObject);

        string bll_GetValueParameter(string pNameParameter, string pNameParentParameter);

        string bll_GetValueParameter(string pNameParameter, bool pActive);

        BoStatus bll_getStatusInProByObject(int pIdObject);
    }
}
