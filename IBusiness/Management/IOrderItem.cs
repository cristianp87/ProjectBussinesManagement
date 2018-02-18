using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using IBusiness.Common;

namespace IBusiness.Management
{
    public interface IOrderItem : IFacade
    {
        string bll_InsertListOrderItem(int pIdOrder,
            int pIdInventory,
            List<Bo_OrderItem> pListOrderItem,
            bool pIsInventory);

        List<Bo_OrderItem> bll_GetOrderItem(int pIdOrder);
        
    }
}
