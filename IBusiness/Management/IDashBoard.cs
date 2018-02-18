using System.Collections.Generic;
using BO_BusinessManagement;
using IBusiness.Common;

namespace IBusiness.Management 
{
    public interface IDashBoard : IFacade
    {
        List<Bo_DashBoard> bll_GetProductSellToday();
    }
}
