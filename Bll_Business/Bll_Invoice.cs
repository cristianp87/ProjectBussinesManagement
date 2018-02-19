using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;
using IBusiness.Management;

namespace Bll_Business
{
    public class BllInvoice : IInvoice
    {
        public IInvoiceItem LInvoiceItem;
        public IUtilsLib LUtilsLib;

        public BllInvoice()
        {
            this.LInvoiceItem = new BllInvoiceItem();
            this.LUtilsLib = new BllUtilsLib();
        }
        public Bo_Invoice bll_GetInvoiceById(int pIdInvoice)
        {
            var oDaoInvoice = new Dao_Invoice();
            return oDaoInvoice.Dao_getInvoiceById(pIdInvoice);
        }

        public List<Bo_Invoice> bll_GetAllInvoice(int pIdcustomer)
        {
            var oDaoInvoice = new Dao_Invoice();
            return oDaoInvoice.Dao_getInvoiceListAll(pIdcustomer);
        }

        public string bll_InsertInvoiceAll( int pIdCustomer, int pIdOrder, int pIdObjectInvoice,List<Bo_InvoiceItem> lListInvoiceItem )
        {
            var lResult = "";
            var lIdInvoice = 0;
            lResult = this.bll_InsertInvoice(this.bll_GetcdInvoice(),pIdCustomer, pIdOrder, pIdObjectInvoice, this.LUtilsLib.bll_getStatusApproByObject(pIdObjectInvoice).LIdStatus);
            if(int.TryParse(lResult,out lIdInvoice))
            {
                lResult = "";
                var lStatusItem = this.LUtilsLib.bll_getStatusApproByObject(lListInvoiceItem[0].LObject.LIdObject).LIdStatus;
                lListInvoiceItem.ForEach(x => {
                   lResult += this.LInvoiceItem.bll_InsertInvoiceItem(lIdInvoice, x.LQuantity, x.LValueProd, x.LValueSupplier, x.LValueTaxes, x.LValueDesc, x.LProduct.LIdProduct, x.LObject.LIdObject, lStatusItem);
               });
                if (string.IsNullOrEmpty(lResult))
                    lResult = lIdInvoice.ToString();             
            }
            else
            {
                lResult = "No se ingreso la factura al sistema, contacte con el administrador";
            }

            return lResult;
        }

        public string bll_GetcdInvoice()
        {
            var lDaoinvoice = new Dao_Invoice();
            return lDaoinvoice.Dao_getCdInvoice(); 
        }

        public string bll_InsertInvoice(string pCdInvoice, int pIdCustomer,int pIdOrder, int pIdObject, string pIdStatus)
        {
            var oInvoice = new Bo_Invoice
            {
                LObject = new Bo_Object {LIdObject = pIdObject},
                LStatus = new Bo_Status {LIdStatus = pIdStatus},
                LCustomer = new Bo_Customer {LIdCustomer = pIdCustomer},
                LOrder = new Bo_Order {LIdOrder = pIdOrder},
                LCdInvoice = pCdInvoice
            };
            var oDaoInvoice = new Dao_Invoice();
            return oDaoInvoice.Dao_InsertInvoice(oInvoice);
        }

        public string bll_UpdateInvoice(string pCdInvoice, int pIdCustomer, int pIdObject, string pIdStatus)
        {
            var oInvoice = new Bo_Invoice
            {
                LObject = new Bo_Object {LIdObject = pIdObject},
                LStatus = new Bo_Status {LIdStatus = pIdStatus},
                LCustomer = new Bo_Customer {LIdCustomer = pIdCustomer},
                LCdInvoice = pCdInvoice
            };
            var oDaoInvoice = new Dao_Invoice();
            return oDaoInvoice.Dao_UpdateInvoice(oInvoice);
        }

        public string bll_DeleteInvoice(int pIdInvoice)
        {
            var oInvoice = new Bo_Invoice {LIdInvoice = pIdInvoice};
            var oDaoInvoice = new Dao_Invoice();
            return oDaoInvoice.Dao_DeleteInvoice(oInvoice);
        }
    }
}
