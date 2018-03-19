using System.Collections.Generic;
using BO_BusinessManagement;
using IBusiness.Common;

namespace IBusiness.Management 
{
    public interface IDashBoard : IFacade
    {
        List<BoDashBoard> bll_GetProductSellToday();
    }
}
