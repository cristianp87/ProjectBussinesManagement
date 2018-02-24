using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoInvoiceItem
    {
        List<Bo_InvoiceItem> Dao_getInvoiceItemByIdInvoice(int pIdInvoice);

        string Dao_InsertInvoiceItem(Bo_InvoiceItem pInvoiceItem);

        string Dao_UpdateInvoiceIem(Bo_InvoiceItem pInvoiceItem);

        string Dao_DeleteInvoiceItem(Bo_InvoiceItem pInvoiceItem);

    }
}
