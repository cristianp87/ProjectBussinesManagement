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

        public static List<Bo_Invoice> bll_GetAllInvoice(int pIdcustomer)
        {
            Dao_Invoice oDaoInvoice = new Dao_Invoice();
            return oDaoInvoice.Dao_getInvoiceListAll(pIdcustomer);
        }

        public static string bll_InsertInvoiceAll(string pCdInvoice, int pIdCustomer, int pIdOrder, int pIdObjectInvoice,List<Bo_InvoiceItem> lListInvoiceItem )
        {
            string lResult = "";
            int lIdInvoice = 0;
            lResult = bll_InsertInvoice(pCdInvoice,pIdCustomer, pIdOrder, pIdObjectInvoice, Bll_UtilsLib.bll_getStatusApproByObject(pIdObjectInvoice).LIdStatus);
            if(int.TryParse(lResult,out lIdInvoice))
            {
                lResult = "";
                string lStatusItem = Bll_UtilsLib.bll_getStatusApproByObject(lListInvoiceItem[0].LObject.LIdObject).LIdStatus;
                lListInvoiceItem.ForEach(x =>
               {
                   lResult += Bll_InvoiceItem.bll_InsertInvoiceItem(lIdInvoice, x.LQuantity, x.LValueProd, x.LValueSupplier, x.LValueTaxes, x.LValueDesc, x.LProduct.LIdProduct, x.LObject.LIdObject, lStatusItem);
               });
            }
            else
            {
                lResult = "No se ingreso la factura al sistema, contacte con el administrador";
            }

            return lResult;
        }

        public static string bll_InsertInvoice(string pCdInvoice, int pIdCustomer,int pIdOrder, int pIdObject, string pIdStatus)
        {
            Bo_Invoice oInvoice = new Bo_Invoice();
            oInvoice.LObject = new Bo_Object();
            oInvoice.LStatus = new Bo_Status();
            oInvoice.LCustomer = new Bo_Customer();
            oInvoice.LCdInvoice = pCdInvoice;
            oInvoice.LCustomer.LIdCustomer = pIdCustomer;
            oInvoice.LOrder.LIdOrder = pIdOrder;
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
