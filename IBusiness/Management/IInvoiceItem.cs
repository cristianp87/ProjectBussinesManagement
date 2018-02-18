using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using IBusiness.Common;

namespace IBusiness.Management
{
    public interface IInvoiceItem : IFacade
    {
        List<Bo_InvoiceItem> bll_GetInvoiceItemsByIdInvoice(int pIdInvoice);

        List<Bo_InvoiceItem> bll_ChangeOrderItemToInvoiceItem(List<Bo_OrderItem> lListOrderItem,
            Bo_Object lObjectInvoice);

        string bll_InsertInvoiceItem(int pIdInvoice,
            decimal pQuantity,
            decimal pValueProduct,
            decimal pValueSupplier,
            decimal pValueTaxes,
            decimal pValueDesc,
            int pIdProduct,
            int pIdObject,
            string pIdStatus);

        string bll_UpdateInvoiceTem(int pIdInvoice, int pQuantity, int pIdProduct, int pIdObject, string pIdStatus);

        string bll_DeleteInvoiceItem(int pIdInvoiceItem);
    }
}
