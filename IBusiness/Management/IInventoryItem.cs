using System.Collections.Generic;
using BO_BusinessManagement;
using IBusiness.Common;

namespace IBusiness.Management
{
    public interface IInventoryItem : IFacade
    {
        List<BoInventoryItem> bll_GetInventoryItemsByIdInventory(int pIdInventory);

        BoInventoryItem bll_GetInventoryItemById(int pIdInventoryItem);

        string bll_InsertInventoryItem(int pIdInventory,
            int pIdProduct,
            int pIdObject,
            string pIdStatus,
            decimal pQtySellable,
            decimal pQtyNonSellable);

        string bll_UpdateInventoryITem(int pIdInventoryItem,
            int pIdInventory,
            int pIdProduct,
            decimal pQtySellable,
            decimal pQtyNonSellable,
            int pIdObject,
            string pIdStatus);  

        string bll_DeleteInventoryItem(int pIdInventoryItem);

        string bll_SubstractInventoryItem(BoOrderItem pOrderItem, int lIdInventory);
    }
}
