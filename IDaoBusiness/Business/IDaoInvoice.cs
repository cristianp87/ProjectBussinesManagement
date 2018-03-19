using System.Collections.Generic;
using BO_BusinessManagement;

namespace IDaoBusiness.Business
{
    public interface IDaoInvoice
    {
        BoInvoice Dao_getInvoiceById(int pIdInvoice);

        List<BoInvoice> Dao_getInvoiceListAll(int pIdCustomer);

        string Dao_getCdInvoice();

        string Dao_InsertInvoice(BoInvoice pInvoice);

        string Dao_UpdateInvoice(BoInvoice pInvoice);

        string Dao_DeleteInvoice(BoInvoice pInvoice);


    }
}
