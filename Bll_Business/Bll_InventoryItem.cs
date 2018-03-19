using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;
using BO_BusinessManagement.Enums;
using IBusiness.Management;
using IDaoBusiness.Business;

namespace Bll_Business
{
    public class BllInventoryItem : IInventoryItem
    {
        public IDaoInventoryItem LiDaoInventoryItem { get; set; }

        public BllInventoryItem()
        {
            this.LiDaoInventoryItem = new DaoInventoryItem();
        }
        public List<BoInventoryItem> bll_GetInventoryItemsByIdInventory(int pIdInventory)
        {
            return this.LiDaoInventoryItem.Dao_getListInventoryItemByIdInventory(pIdInventory);
        }

        public BoInventoryItem bll_GetInventoryItemById(int pIdInventoryItem)
        {
            return this.LiDaoInventoryItem.Dao_getInventoryItemById(pIdInventoryItem);
        }

        public string bll_InsertInventoryItem(int pIdInventory, int pIdProduct, int pIdObject, string pIdStatus, decimal pQtySellable, decimal pQtyNonSellable)
        {
            var oInventoryItem = new BoInventoryItem
            {
                LObject = new BoObject {LIdObject = pIdObject},
                LStatus = new BoStatus {LIdStatus = pIdStatus},
                LProduct = new BoProduct {LIdProduct = pIdProduct},
                LInventory = new BoInventory {LIdInventory = pIdInventory},
                LQtyNonSellable = pQtyNonSellable,
                LQtySellable = pQtySellable
            };
            return this.LiDaoInventoryItem.Dao_InsertInventoryItem(oInventoryItem);
        }

        public string bll_UpdateInventoryITem(int pIdInventoryItem, int pIdInventory, int pIdProduct, decimal pQtySellable, decimal pQtyNonSellable, int pIdObject, string pIdStatus)
        {
            var oInventoryItem = new BoInventoryItem
            {
                LObject = new BoObject {LIdObject = pIdObject},
                LStatus = new BoStatus {LIdStatus = pIdStatus},
                LProduct = new BoProduct {LIdProduct = pIdProduct},
                LInventory = new BoInventory {LIdInventory = pIdInventory},
                LIdInventoryItem = pIdInventoryItem,
                LQtySellable = pQtySellable,
                LQtyNonSellable = pQtyNonSellable
            };
            return this.LiDaoInventoryItem.Dao_UpdateInventoryItem(oInventoryItem);
        }


        public string bll_DeleteInventoryItem(int pIdInventoryItem)
        {
            var oInventoryItem = new BoInventoryItem {LIdInventoryItem = pIdInventoryItem};
            return this.LiDaoInventoryItem.Dao_DeleteInventoryItem(oInventoryItem);
        }


        public string bll_SubstractInventoryItem(BoOrderItem pOrderItem, int lIdInventory)
        {
            var lInventoryItem = new BoInventoryItem
            {
                LProduct = new BoProduct {LCdProduct = pOrderItem.LProduct.LCdProduct},
                LInventory = new BoInventory {LIdInventory = lIdInventory},
                LQtySellable = pOrderItem.LQty
            };
            return this.LiDaoInventoryItem.Dao_SubstractInventoryItem(lInventoryItem) == EBooleans.Trues.ToString() ? null : BoErrors.MsgEmptyProductWithcode.Replace(BoErrors.ReplaceInString1, pOrderItem.LProduct.LCdProduct);
        }
    }
}
