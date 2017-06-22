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
            return oDaoInventoryITem.Dao_getInventoryItemByIdInventory(pIdInventory);
        }



        public static string bll_InsertInventoryItem(int pIdInventory, int pIdProduct, int pIdObject, string pIdStatus, decimal pQtySellable, decimal pQtyNonSellable)
        {
            Bo_InventoryItem oInventoryItem = new Bo_InventoryItem();
            oInventoryItem.LObject = new Bo_Object();
            oInventoryItem.LStatus = new Bo_Status();
            oInventoryItem.LProduct = new Bo_Product();
            oInventoryItem.LIdInventory = pIdInventory;
            oInventoryItem.LProduct.LIdProduct = pIdProduct;
            oInventoryItem.LObject.LIdObject = pIdObject;
            oInventoryItem.LStatus.LIdStatus = pIdStatus;
            oInventoryItem.LQtyNonSellable = pQtyNonSellable;
            oInventoryItem.LQtySellable = pQtySellable;
            Dao_InventoryItem oDaoInventoryItem = new Dao_InventoryItem();
            return oDaoInventoryItem.Dao_InsertInventoryItem(oInventoryItem);
        }

        public static string bll_UpdateInventoryITem(int pIdInventoryItem, int pIdInventory, int pIdProduct, int pIdObject, string pIdStatus)
        {
            Bo_InventoryItem oInventoryItem = new Bo_InventoryItem();
            oInventoryItem.LObject = new Bo_Object();
            oInventoryItem.LStatus = new Bo_Status();
            oInventoryItem.LProduct = new Bo_Product();
            oInventoryItem.LIdInventoryItem = pIdInventoryItem;
            oInventoryItem.LIdInventory = pIdInventory;
            oInventoryItem.LProduct.LIdProduct = pIdProduct;
            oInventoryItem.LObject.LIdObject = pIdObject;
            oInventoryItem.LStatus.LIdStatus = pIdStatus;
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
    }
}
