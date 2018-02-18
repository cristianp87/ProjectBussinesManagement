using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using IBusiness.Common;

namespace IBusiness.Management
{
    public interface IOrder : IFacade
    {
        string bll_InsertOrder(int pIdInventory,
            int pIdCustomer,
            int pIdObject,
            string pIdStatus,
            List<Bo_OrderItem> pListOrderItem,
            bool pIsInventory,
            int pIdObjectOi,
            string pIdStatusOi);

        List<Bo_Order> bll_GetListOrderByCustomer(int pIdCustomer);
    }
}
