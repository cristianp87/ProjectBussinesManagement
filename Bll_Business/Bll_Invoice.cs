using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_BusinessManagement;
using Dao_BussinessManagement;

namespace Bll_Business
{
    public class Bll_Invoice
    {
        public static Bo_Invoice bll_GetInvoiceById(int pIdInvoice)
        {
            Dao_Invoice oDaoInvoice = new Dao_Invoice();
            return oDaoInvoice.Dao_getInvoiceById(pIdInvoice);
        }

        public static List<Bo_Invoice> bll_GetAllInvoice()
        {
            Dao_Invoice oDaoInvoice = new Dao_Invoice();
            return oDaoInvoice.Dao_getInvoiceListAll();
        }

        public static string bll_InsertInvoice(string pCdInvoice, int pIdCustomer, int pIdObject, string pIdStatus)
        {
            Bo_Invoice oInvoice = new Bo_Invoice();
            oInvoice.LObject = new Bo_Object();
            oInvoice.LStatus = new Bo_Status();
            oInvoice.LCustomer = new Bo_Customer();
            oInvoice.LCdInvoice = pCdInvoice;
            oInvoice.LCustomer.LIdCustomer = pIdCustomer;
            oInvoice.LObject.LIdObject = pIdObject;
            oInvoice.LStatus.LIdStatus = pIdStatus;
            Dao_Invoice oDaoInvoice = new Dao_Invoice();
            return oDaoInvoice.Dao_InsertInvoice(oInvoice);
        }

        public static string bll_UpdateInvoice(string pCdInvoice, int pIdCustomer, int pIdObject, string pIdStatus)
        {
            Bo_Invoice oInvoice = new Bo_Invoice();
            oInvoice.LObject = new Bo_Object();
            oInvoice.LStatus = new Bo_Status();
            oInvoice.LCustomer = new Bo_Customer();
            oInvoice.LCdInvoice = pCdInvoice;
            oInvoice.LCustomer.LIdCustomer = pIdCustomer;
            oInvoice.LObject.LIdObject = pIdObject;
            oInvoice.LStatus.LIdStatus = pIdStatus;
            Dao_Invoice oDaoInvoice = new Dao_Invoice();
            return oDaoInvoice.Dao_UpdateInvoice(oInvoice);
        }

        public static string bll_DeleteInvoice(int pIdInvoice)
        {
            Bo_Invoice oInvoice = new Bo_Invoice();
            oInvoice.LIdInvoice = pIdInvoice;
            Dao_Invoice oDaoInvoice = new Dao_Invoice();
            return oDaoInvoice.Dao_DeleteInvoice(oInvoice);
        }
    }
}
