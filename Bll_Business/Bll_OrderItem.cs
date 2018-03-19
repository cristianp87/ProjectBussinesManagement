using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;
using BO_BusinessManagement.Enums;
using IBusiness.Management;
using IDaoBusiness.Business;

namespace Bll_Business
{
    public class BllOrderItem:IOrderItem
    {
        public static IInventoryItem LItem;

        public static IUtilsLib LiUtilsLib;

        public IDaoOrderItem LiDaoOrderItem { get; set; }

        public BllOrderItem()
        {
            LItem = new BllInventoryItem();
            LiUtilsLib = new BllUtilsLib();
            this.LiDaoOrderItem = new DaoOrderItem();
        }
        public List<BoOrderItem> bll_GetOrderItem(int pIdOrder)
        {
            return this.LiDaoOrderItem.Dao_getListOrderItem(pIdOrder);
        }

        public string bll_InsertListOrderItem(int pIdOrder,int pIdInventory, List<BoOrderItem> pListOrderItem, bool pIsInventory)
        {
            var lObject = LiUtilsLib.bll_GetObjectByName(EObjects.BoOrderItem);
            string lResult = null;
            pListOrderItem.ForEach(x =>
            {
                var lOrderItem = new BoOrderItem
                {
                    LObject = new BoObject {LIdObject = lObject.LIdObject},
                    LStatus =
                        new BoStatus {LIdStatus = LiUtilsLib.bll_getStatusApproByObject(lObject.LIdObject).LIdStatus},
                    LProduct = new BoProduct {LCdProduct = x.LProduct.LCdProduct},
                    LOrder = new BoOrder {LIdOrder = pIdOrder},
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
                lResult = this.LiDaoOrderItem.Dao_InsertOrderItem(lOrderItem);
            });
            return lResult;            
        }


    }
}
