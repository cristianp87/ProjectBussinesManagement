using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;
using IBusiness.Management;

namespace Bll_Business
{
    public class BllInventoryItem : IInventoryItem
    {
        public List<Bo_InventoryItem> bll_GetInventoryItemsByIdInventory(int pIdInventory)
        {
            var oDaoInventoryITem = new Dao_InventoryItem();
            return oDaoInventoryITem.Dao_getListInventoryItemByIdInventory(pIdInventory);
        }

        public Bo_InventoryItem bll_GetInventoryItemById(int pIdInventoryItem)
        {
            var oDaoInventoryITem = new Dao_InventoryItem();
            return oDaoInventoryITem.Dao_getInventoryItemById(pIdInventoryItem);
        }

        public string bll_InsertInventoryItem(int pIdInventory, int pIdProduct, int pIdObject, string pIdStatus, decimal pQtySellable, decimal pQtyNonSellable)
        {
            var oInventoryItem = new Bo_InventoryItem
            {
                LObject = new Bo_Object {LIdObject = pIdObject},
                LStatus = new Bo_Status {LIdStatus = pIdStatus},
                LProduct = new Bo_Product {LIdProduct = pIdProduct},
                LInventory = new Bo_Inventory {LIdInventory = pIdInventory},
                LQtyNonSellable = pQtyNonSellable,
                LQtySellable = pQtySellable
            };
            var oDaoInventoryItem = new Dao_InventoryItem();
            return oDaoInventoryItem.Dao_InsertInventoryItem(oInventoryItem);
        }

        public string bll_UpdateInventoryITem(int pIdInventoryItem, int pIdInventory, int pIdProduct, decimal pQtySellable, decimal pQtyNonSellable, int pIdObject, string pIdStatus)
        {
            var oInventoryItem = new Bo_InventoryItem
            {
                LObject = new Bo_Object {LIdObject = pIdObject},
                LStatus = new Bo_Status {LIdStatus = pIdStatus},
                LProduct = new Bo_Product {LIdProduct = pIdProduct},
                LInventory = new Bo_Inventory {LIdInventory = pIdInventory},
                LIdInventoryItem = pIdInventoryItem,
                LQtySellable = pQtySellable,
                LQtyNonSellable = pQtyNonSellable
            };
            var oDaoInventoryItem = new Dao_InventoryItem();
            return oDaoInventoryItem.Dao_UpdateInventoryItem(oInventoryItem);
        }


        public string bll_DeleteInventoryItem(int pIdInventoryItem)
        {
            var oInventoryItem = new Bo_InventoryItem {LIdInventoryItem = pIdInventoryItem};
            var oDaoInventoryItem = new Dao_InventoryItem();
            return oDaoInventoryItem.Dao_DeleteInventoryItem(oInventoryItem);
        }


        public string bll_SubstractInventoryItem(Bo_OrderItem pOrderItem, int lIdInventory)
        {
            var lInventoryItem = new Bo_InventoryItem
            {
                LProduct = new Bo_Product {LCdProduct = pOrderItem.LProduct.LCdProduct},
                LInventory = new Bo_Inventory {LIdInventory = lIdInventory},
                LQtySellable = pOrderItem.LQty
            };
            var lDaoInventoryItem = new Dao_InventoryItem();
            if(lDaoInventoryItem.Dao_SubstractInventoryItem(lInventoryItem) == "1")
            {
                return "";
            }
            else
            {
                return "No hay mas del producto con el codigo" + pOrderItem.LProduct.LCdProduct + " en el inventario";
            }
        }
    }
}
