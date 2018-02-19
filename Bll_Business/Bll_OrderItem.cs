using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;
using IBusiness.Management;
using Bll_Business;

namespace Bll_Business
{
    public class BllOrderItem:IOrderItem
    {
        public static IInventoryItem LItem;

        public static IUtilsLib LiUtilsLib;
        public BllOrderItem()
        {
            LItem = new BllInventoryItem();
            LiUtilsLib = new BllUtilsLib();
        }
        public List<Bo_OrderItem> bll_GetOrderItem(int pIdOrder)
        {
            var lDaoOrderItem = new Dao_OrderItem();
            return lDaoOrderItem.Dao_getListOrderItem(pIdOrder);
        }

        public string bll_InsertListOrderItem(int pIdOrder,int pIdInventory, List<Bo_OrderItem> pListOrderItem, bool pIsInventory)
        {
            var lObject = LiUtilsLib.bll_GetObjectByName("ORDITEM");
            string lResult = "";
            pListOrderItem.ForEach(x =>
            {
                var lOrderItem = new Bo_OrderItem
                {
                    LObject = new Bo_Object {LIdObject = lObject.LIdObject},
                    LStatus =
                        new Bo_Status {LIdStatus = LiUtilsLib.bll_getStatusApproByObject(lObject.LIdObject).LIdStatus},
                    LProduct = new Bo_Product {LCdProduct = x.LProduct.LCdProduct},
                    LOrder = new Bo_Order {LIdOrder = pIdOrder},
                    LValueProduct = x.LValueProduct,
                    LValueSupplier = x.LValueSupplier,
                    LValueTaxes = x.LValueTaxes,
                    LValueDesc = x.LValueDesc,
                    LQty = x.LQty
                };
                if(pIsInventory)
                    lResult = LItem.bll_SubstractInventoryItem(lOrderItem, pIdInventory);
                if (!string.IsNullOrEmpty(lResult))
                {
                    return;
                }
                var lDaoOrderItem = new Dao_OrderItem();
                lResult = lDaoOrderItem.Dao_InsertOrderItem(lOrderItem);
            });
            return lResult;            
        }


    }
}
