using BO_BusinessManagement;
using IBusiness.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Management
{
    public interface IUtilsLib : IFacade
    {
        Bo_Object bll_GetObjectByName(string pNameObject);

        List<Bo_Unit> bll_GetAllUnit();

        Bo_Status bll_getStatusApproByObject(int pIdObject);

        string bll_GetValueParameter(string pNameParameter, string pNameParentParameter);

        string bll_GetValueParameter(string pNameParameter, bool pActive);
    }
}
