using BO_BusinessManagement;
using IBusiness.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBusiness.Management
{
    public interface ITypeIdentification : IFacade
    {
        List<Bo_TypeIdentification> bll_getListTypeIdentification();
    }
}
