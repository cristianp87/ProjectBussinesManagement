using System.Collections.Generic;
using BO_BusinessManagement;
using IBusiness.Common;

namespace IBusiness.Management
{
    public interface IInvoice : IFacade
    {
        BoInvoice bll_GetInvoiceById(int pIdInvoice);

        List<BoInvoice> bll_GetAllInvoice(int pIdcustomer);

        string bll_InsertInvoiceAll(int pIdCustomer,
            int pIdOrder,
            int pIdObjectInvoice,
            List<BoInvoiceItem> lListInvoiceItem);

        string bll_GetcdInvoice();

        string bll_InsertInvoice(string pCdInvoice, int pIdCustomer, int pIdOrder, int pIdObject, string pIdStatus);

        string bll_UpdateInvoice(string pCdInvoice, int pIdCustomer, int pIdObject, string pIdStatus);

        string bll_DeleteInvoice(int pIdInvoice);
    }
}
