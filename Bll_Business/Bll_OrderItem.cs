using BO_BusinessManagement;
using Dao_BussinessManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll_Business
{
    class Bll_OrderItem
    {
        public static string bll_InsertListOrderItem(int pIdOrder, List<Bo_OrderItem> pListOrderItem)
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
                lOrderItem.LProduct.LIdProduct = x.LProduct.LIdProduct;
                lOrderItem.LOrder.LIdOrder = pIdOrder;
                lOrderItem.LValueProduct = x.LValueProduct;
                lOrderItem.LValueSupplier = x.LValueSupplier;
                lOrderItem.LValueTaxes = x.LValueTaxes;
                lOrderItem.LValueDesc = x.LValueDesc;
                lOrderItem.LObject.LIdObject = lObject.LIdObject;
                lOrderItem.LStatus.LIdStatus = "APPRO";
                Dao_OrderItem lDaoOrderItem = new Dao_OrderItem();
                lResult = lDaoOrderItem.Dao_InsertOrderItem(lOrderItem);
            });
            return "";            
        }
    }
}
