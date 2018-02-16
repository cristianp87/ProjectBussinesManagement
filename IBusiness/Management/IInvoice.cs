using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using IBusiness.Common;

namespace IBusiness.Management
{
    public interface IInvoice : IFacade
    {
        Bo_Invoice bll_GetInvoiceById(int pIdInvoice);

        List<Bo_Invoice> bll_GetAllInvoice(int pIdcustomer);

        string bll_InsertInvoiceAll(int pIdCustomer,
            int pIdOrder,
            int pIdObjectInvoice,
            List<Bo_InvoiceItem> lListInvoiceItem);

        string bll_GetcdInvoice();

        string bll_InsertInvoice(string pCdInvoice, int pIdCustomer, int pIdOrder, int pIdObject, string pIdStatus);

        string bll_UpdateInvoice(string pCdInvoice, int pIdCustomer, int pIdObject, string pIdStatus);

        string bll_DeleteInvoice(int pIdInvoice);
    }
}
