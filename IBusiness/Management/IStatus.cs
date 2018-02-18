using BO_BusinessManagement;
using IBusiness.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Management
{
    public interface IStatus : IFacade
    {
        List<Bo_Status> Bll_getListStatusByIdObject(int pIdObject);
    }
}
