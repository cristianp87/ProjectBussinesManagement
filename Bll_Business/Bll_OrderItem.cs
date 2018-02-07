using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;

namespace Bll_Business
{
    public class Bll_OrderItem
    {
        public static List<Bo_OrderItem> bll_GetOrderItem(int pIdOrder)
        {
            Dao_OrderItem lDaoOrderItem = new Dao_OrderItem();
            return lDaoOrderItem.Dao_getListOrderItem(pIdOrder);
        }

        public static string bll_InsertListOrderItem(int pIdOrder,int pIdInventory, List<Bo_OrderItem> pListOrderItem, bool pIsInventory)
        {
            var lObject = Bll_UtilsLib.bll_GetObjectByName("ORDITEM");
            string lResult = "";
            pListOrderItem.ForEach(x =>
            {
                Bo_OrderItem lOrderItem = new Bo_OrderItem();
                lOrderItem.LObject = new Bo_Object();
                lOrderItem.LStatus = new Bo_Status();
                lOrderItem.LProduct = new Bo_Product();
                lOrderItem.LOrder = new Bo_Order();
                lOrderItem.LProduct.LCdProduct = x.LProduct.LCdProduct;
                lOrderItem.LOrder.LIdOrder = pIdOrder;
                lOrderItem.LValueProduct = x.LValueProduct;
                lOrderItem.LValueSupplier = x.LValueSupplier;
                lOrderItem.LValueTaxes = x.LValueTaxes;
                lOrderItem.LValueDesc = x.LValueDesc;
                lOrderItem.LQty = x.LQty;
                lOrderItem.LObject.LIdObject = lObject.LIdObject;
                lOrderItem.LStatus.LIdStatus = Bll_UtilsLib.bll_getStatusApproByObject(lObject.LIdObject).LIdStatus;
                if(pIsInventory)
                    lResult = Bll_InventoryItem.bll_SubstractInventoryItem(lOrderItem, pIdInventory);
                if (string.IsNullOrEmpty(lResult))
                {
                    Dao_OrderItem lDaoOrderItem = new Dao_OrderItem();
                    lResult = lDaoOrderItem.Dao_InsertOrderItem(lOrderItem);
                }
                
            });
            return lResult;            
        }


    }
}
