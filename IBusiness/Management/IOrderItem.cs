using System.Collections.Generic;
using BO_BusinessManagement;
using IBusiness.Common;

namespace IBusiness.Management
{
    public interface IOrderItem : IFacade
    {
        string bll_InsertListOrderItem(int pIdOrder,
            int pIdInventory,
            List<BoOrderItem> pListOrderItem,
            bool pIsInventory);

        List<BoOrderItem> bll_GetOrderItem(int pIdOrder);
        
    }
}
