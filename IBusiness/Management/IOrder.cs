using System.Collections.Generic;
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
            List<BoOrderItem> pListOrderItem,
            bool pIsInventory,
            int pIdObjectOi,
            string pIdStatusOi);

        List<BoOrder> bll_GetListOrderByCustomer(int pIdCustomer);
    }
}
