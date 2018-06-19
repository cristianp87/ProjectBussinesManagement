using System.Collections.Generic;
using BO_BusinessManagement;
using IBusiness.Common;

namespace IBusiness.Management
{
    public interface IInvoiceItem : IFacade
    {
        List<BoInvoiceItem> bll_GetInvoiceItemsByIdInvoice(int pIdInvoice);

        List<BoInvoiceItem> bll_ChangeOrderItemToInvoiceItem(List<BoOrderItem> lListOrderItem,
            BoObject lObjectInvoice);

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
