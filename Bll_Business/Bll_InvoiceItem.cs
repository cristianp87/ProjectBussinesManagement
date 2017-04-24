using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using Dao_BussinessManagement;

namespace Bll_Business
{
    public class Bll_InvoiceItem
    {
        public static List<Bo_InvoiceItem> bll_GetInvoiceItemsByIdInvoice(int pIdInvoice)
        {
            Dao_InvoiceItem oDaoInvoiceItem = new Dao_InvoiceItem();
            return oDaoInvoiceItem.Dao_getInvoiceItemByIdInvoice(pIdInvoice);
        }


        public static string bll_InsertInvoiceItem(int pIdInvoice, int pQuantity, int pIdProduct, int pIdObject, string pIdStatus)
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
