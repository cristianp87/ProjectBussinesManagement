using System.Collections.Generic;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoInvoiceItem
    {
        List<BoInvoiceItem> Dao_getInvoiceItemByIdInvoice(int pIdInvoice);

        string Dao_InsertInvoiceItem(BoInvoiceItem pInvoiceItem);

        string Dao_UpdateInvoiceIem(BoInvoiceItem pInvoiceItem);

        string Dao_DeleteInvoiceItem(BoInvoiceItem pInvoiceItem);

    }
}
