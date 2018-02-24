using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;
using IBusiness.Management;
using IDaoBusiness.Business;

namespace Bll_Business
{
    public class BllInvoice : IInvoice
    {
        public IInvoiceItem LInvoiceItem;
        public IUtilsLib LUtilsLib;
        public IDaoInvoice LiDaoInvoice { get; set; }

        public IDaoInvoiceItem LiDaoInvoiceItem { get; set; }

        public BllInvoice()
        {
            this.LInvoiceItem = new BllInvoiceItem();
            this.LUtilsLib = new BllUtilsLib();
            this.LiDaoInvoice = new DaoInvoice();
            this.LiDaoInvoiceItem = new DaoInvoiceItem();
        }
        public Bo_Invoice bll_GetInvoiceById(int pIdInvoice)
        {
            var lDaoInvoice = this.LiDaoInvoice.Dao_getInvoiceById(pIdInvoice);
            lDaoInvoice.LListInvoiceItem = this.LiDaoInvoiceItem.Dao_getInvoiceItemByIdInvoice(lDaoInvoice.LIdInvoice);
            return lDaoInvoice;
        }

        public List<Bo_Invoice> bll_GetAllInvoice(int pIdcustomer)
        {
            var oDaoInvoice = new DaoInvoice();
            return oDaoInvoice.Dao_getInvoiceListAll(pIdcustomer);
        }

        public string bll_InsertInvoiceAll( int pIdCustomer, int pIdOrder, int pIdObjectInvoice,List<Bo_InvoiceItem> lListInvoiceItem )
        {
            var lResult = "";
            int lIdInvoice;
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
            return this.LiDaoInvoice.Dao_getCdInvoice(); 
        }

        public string bll_InsertInvoice(string pCdInvoice, int pIdCustomer,int pIdOrder, int pIdObject, string pIdStatus)
        {
            var lInvoice = new Bo_Invoice
            {
                LObject = new Bo_Object {LIdObject = pIdObject},
                LStatus = new Bo_Status {LIdStatus = pIdStatus},
                LCustomer = new Bo_Customer {LIdCustomer = pIdCustomer},
                LOrder = new Bo_Order {LIdOrder = pIdOrder},
                LCdInvoice = pCdInvoice
            };
            return this.LiDaoInvoice.Dao_InsertInvoice(lInvoice);
        }

        public string bll_UpdateInvoice(string pCdInvoice, int pIdCustomer, int pIdObject, string pIdStatus)
        {
            var lInvoice = new Bo_Invoice
            {
                LObject = new Bo_Object {LIdObject = pIdObject},
                LStatus = new Bo_Status {LIdStatus = pIdStatus},
                LCustomer = new Bo_Customer {LIdCustomer = pIdCustomer},
                LCdInvoice = pCdInvoice
            };
            return this.LiDaoInvoice.Dao_UpdateInvoice(lInvoice);
        }

        public string bll_DeleteInvoice(int pIdInvoice)
        {
            var lInvoice = new Bo_Invoice {LIdInvoice = pIdInvoice};
            return this.LiDaoInvoice.Dao_DeleteInvoice(lInvoice);
        }
    }
}
