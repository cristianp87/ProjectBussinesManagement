using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoInvoice
    {
        Bo_Invoice Dao_getInvoiceById(int pIdInvoice);

        List<Bo_Invoice> Dao_getInvoiceListAll(int pIdCustomer);

        string Dao_getCdInvoice();

        string Dao_InsertInvoice(Bo_Invoice pInvoice);

        string Dao_UpdateInvoice(Bo_Invoice pInvoice);

        string Dao_DeleteInvoice(Bo_Invoice pInvoice);


    }
}
