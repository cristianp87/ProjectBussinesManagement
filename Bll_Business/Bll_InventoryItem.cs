using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using Dao_BussinessManagement;

namespace Bll_Business
{
    public class Bll_InventoryItem
    {
        public static List<Bo_InventoryItem> bll_GetInventoryItemsByIdInventory(int pIdInventory)
        {
            Dao_InventoryItem oDaoInventoryITem = new Dao_InventoryItem();
            return oDaoInventoryITem.Dao_getListInventoryItemByIdInventory(pIdInventory);
        }

        public static Bo_InventoryItem bll_GetInventoryItemById(int pIdInventoryItem)
        {
            Dao_InventoryItem oDaoInventoryITem = new Dao_InventoryItem();
            return oDaoInventoryITem.Dao_getInventoryItemById(pIdInventoryItem);
        }

        public static string bll_InsertInventoryItem(int pIdInventory, int pIdProduct, int pIdObject, string pIdStatus, decimal pQtySellable, decimal pQtyNonSellable)
        {
            Bo_InventoryItem oInventoryItem = new Bo_InventoryItem();
            oInventoryItem.LObject = new Bo_Object();
            oInventoryItem.LStatus = new Bo_Status();
            oInventoryItem.LProduct = new Bo_Product();
            oInventoryItem.LInventory = new Bo_Inventory();
            oInventoryItem.LInventory.LIdInventory = pIdInventory;
            oInventoryItem.LProduct.LIdProduct = pIdProduct;
            oInventoryItem.LObject.LIdObject = pIdObject;
            oInventoryItem.LStatus.LIdStatus = pIdStatus;
            oInventoryItem.LQtyNonSellable = pQtyNonSellable;
            oInventoryItem.LQtySellable = pQtySellable;
            Dao_InventoryItem oDaoInventoryItem = new Dao_InventoryItem();
            return oDaoInventoryItem.Dao_InsertInventoryItem(oInventoryItem);
        }

        public static string bll_UpdateInventoryITem(int pIdInventoryItem, int pIdInventory, int pIdProduct, decimal pQtySellable, decimal pQtyNonSellable, int pIdObject, string pIdStatus)
        {
            Bo_InventoryItem oInventoryItem = new Bo_InventoryItem();
            oInventoryItem.LObject = new Bo_Object();
            oInventoryItem.LStatus = new Bo_Status();
            oInventoryItem.LProduct = new Bo_Product();
            oInventoryItem.LInventory = new Bo_Inventory();
            oInventoryItem.LIdInventoryItem = pIdInventoryItem;
            oInventoryItem.LInventory.LIdInventory = pIdInventory;
            oInventoryItem.LProduct.LIdProduct = pIdProduct;
            oInventoryItem.LObject.LIdObject = pIdObject;
            oInventoryItem.LStatus.LIdStatus = pIdStatus;
            oInventoryItem.LQtySellable = pQtySellable;
            oInventoryItem.LQtyNonSellable = pQtyNonSellable;
            Dao_InventoryItem oDaoInventoryItem = new Dao_InventoryItem();
            return oDaoInventoryItem.Dao_UpdateInventoryItem(oInventoryItem);
        }


        public static string bll_DeleteInventoryItem(int pIdInventoryItem)
        {
            Bo_InventoryItem oInventoryItem = new Bo_InventoryItem();
            oInventoryItem.LIdInventoryItem = pIdInventoryItem;
            Dao_InventoryItem oDaoInventoryItem = new Dao_InventoryItem();
            return oDaoInventoryItem.Dao_DeleteInventoryItem(oInventoryItem);
        }


        public static string bll_SubstractInventoryItem(Bo_OrderItem pOrderItem, int lIdInventory)
        {
            Bo_InventoryItem lInventoryItem = new Bo_InventoryItem();
            lInventoryItem.LProduct = new Bo_Product();
            lInventoryItem.LInventory = new Bo_Inventory();
            lInventoryItem.LQtySellable = pOrderItem.LQty;
            lInventoryItem.LProduct.LCdProduct = pOrderItem.LProduct.LCdProduct;
            lInventoryItem.LInventory.LIdInventory = lIdInventory;
            Dao_InventoryItem lDaoInventoryItem = new Dao_InventoryItem();
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
