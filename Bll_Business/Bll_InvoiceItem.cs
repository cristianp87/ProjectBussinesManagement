using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;

namespace Bll_Business
{
    public class Bll_InvoiceItem
    {
        public static List<Bo_InvoiceItem> bll_GetInvoiceItemsByIdInvoice(int pIdInvoice)
        {
            Dao_InvoiceItem oDaoInvoiceItem = new Dao_InvoiceItem();
            return oDaoInvoiceItem.Dao_getInvoiceItemByIdInvoice(pIdInvoice);
        }

        public static List<Bo_InvoiceItem> bll_ChangeOrderItemToInvoiceItem(List<Bo_OrderItem> lListOrderItem, Bo_Object lObjectInvoice)
        {
            List<Bo_InvoiceItem> lListInvoiceItem = new List<Bo_InvoiceItem>();
            lListOrderItem.ForEach(x =>
            {
                Bo_InvoiceItem lInvoiceItem = new Bo_InvoiceItem();
                lInvoiceItem.LProduct = new Bo_Product();
                lInvoiceItem.LProduct = Bll_Product.bll_GetProductByCode(x.LProduct.LCdProduct);              
                lInvoiceItem.LQuantity = x.LQty;
                lInvoiceItem.LValueProd = x.LValueProduct;
                lInvoiceItem.LValueDesc = x.LValueDesc;
                lInvoiceItem.LValueSupplier = x.LValueSupplier;
                lInvoiceItem.LValueTaxes = x.LValueTaxes;
                lInvoiceItem.LObject = lObjectInvoice;
                lListInvoiceItem.Add(lInvoiceItem);
            });
            return lListInvoiceItem;
        }


        public static string bll_InsertInvoiceItem(int pIdInvoice, decimal pQuantity, decimal pValueProduct, decimal pValueSupplier, decimal pValueTaxes, decimal pValueDesc, int pIdProduct, int pIdObject, string pIdStatus)
        {
            Bo_InvoiceItem oInvoiceItem = new Bo_InvoiceItem();
            oInvoiceItem.LObject = new Bo_Object();
            oInvoiceItem.LStatus = new Bo_Status();
            oInvoiceItem.LProduct = new Bo_Product();
            oInvoiceItem.LIdInvoice = pIdInvoice;
            oInvoiceItem.LQuantity = pQuantity;
            oInvoiceItem.LProduct.LIdProduct = pIdProduct;
            oInvoiceItem.LValueDesc = pValueDesc;
            oInvoiceItem.LValueProd = pValueProduct;
            oInvoiceItem.LValueSupplier = pValueSupplier;
            oInvoiceItem.LValueTaxes = pValueTaxes;
            oInvoiceItem.LObject.LIdObject = pIdObject;
            oInvoiceItem.LStatus.LIdStatus = pIdStatus;
            Dao_InvoiceItem oDaoInvoiceItem = new Dao_InvoiceItem();
            return oDaoInvoiceItem.Dao_InsertInvoiceItem(oInvoiceItem);
        }

        public static string bll_UpdateInvoiceTem(int pIdInvoice, int pQuantity, int pIdProduct, int pIdObject, string pIdStatus)
        {
            Bo_InvoiceItem oInvoiceItem = new Bo_InvoiceItem();
            oInvoiceItem.LObject = new Bo_Object();
            oInvoiceItem.LStatus = new Bo_Status();
            oInvoiceItem.LProduct = new Bo_Product();
            oInvoiceItem.LIdInvoice = pIdInvoice;
            oInvoiceItem.LQuantity = pQuantity;
            oInvoiceItem.LProduct.LIdProduct = pIdProduct;
            oInvoiceItem.LObject.LIdObject = pIdObject;
            oInvoiceItem.LStatus.LIdStatus = pIdStatus; 
            Dao_InvoiceItem oDaoInvoiceItem = new Dao_InvoiceItem();
            return oDaoInvoiceItem.Dao_UpdateInvoiceIem(oInvoiceItem);
        }

        public static string bll_DeleteInvoiceItem(int pIdInvoiceItem)
        {
            Bo_InvoiceItem oInvoiceItem = new Bo_InvoiceItem();
            oInvoiceItem.LIdInvoiceItem = pIdInvoiceItem;
            Dao_InvoiceItem oDaoInvoiceItem = new Dao_InvoiceItem();
            return oDaoInvoiceItem.Dao_DeleteInvoiceItem(oInvoiceItem);
        }
    }
}
