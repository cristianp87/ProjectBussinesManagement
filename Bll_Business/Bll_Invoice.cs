using BO_BusinessManagement;
using Dao_BussinessManagement;
using System.Collections.Generic;
using BO_BusinessManagement.Enums;
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
        public BoInvoice bll_GetInvoiceById(int pIdInvoice)
        {
            var lDaoInvoice = this.LiDaoInvoice.Dao_getInvoiceById(pIdInvoice);
            lDaoInvoice.LListInvoiceItem = this.LiDaoInvoiceItem.Dao_getInvoiceItemByIdInvoice(lDaoInvoice.LIdInvoice);
            return lDaoInvoice;
        }

        public List<BoInvoice> bll_GetAllInvoice(int pIdcustomer)
        {
            var oDaoInvoice = new DaoInvoice();
            return oDaoInvoice.Dao_getInvoiceListAll(pIdcustomer);
        }

        public string bll_InsertInvoiceAll( int pIdCustomer, int pIdOrder, int pIdObjectInvoice,List<BoInvoiceItem> lListInvoiceItem )
        {
            int lIdInvoice;
            var lResult = this.bll_InsertInvoice(this.bll_GetcdInvoice(),pIdCustomer, pIdOrder, pIdObjectInvoice, this.LUtilsLib.bll_getStatusApproByObject(pIdObjectInvoice).LIdStatus);
            if(int.TryParse(lResult,out lIdInvoice))
            {
                lResult = null;
                var lStatusItem = this.LUtilsLib.bll_getStatusApproByObject(lListInvoiceItem[0].LObject.LIdObject).LIdStatus;
                lListInvoiceItem.ForEach(x => {
                   lResult += this.LInvoiceItem.bll_InsertInvoiceItem(lIdInvoice, x.LQuantity, x.LValueProd, x.LValueSupplier, x.LValueTaxes, x.LValueDesc, x.LProduct.LIdProduct, x.LObject.LIdObject, lStatusItem);
               });
                if (string.IsNullOrEmpty(lResult))
                    lResult = lIdInvoice.ToString();             
            }
            else
            {
                lResult = BoErrors.MsgRollbackInvoice;
            }

            return lResult;
        }

        public string bll_GetcdInvoice()
        {
            return this.LiDaoInvoice.Dao_getCdInvoice(); 
        }

        public string bll_InsertInvoice(string pCdInvoice, int pIdCustomer,int pIdOrder, int pIdObject, string pIdStatus)
        {
            var lInvoice = new BoInvoice
            {
                LObject = new BoObject {LIdObject = pIdObject},
                LStatus = new BoStatus {LIdStatus = pIdStatus},
                LCustomer = new BoCustomer {LIdCustomer = pIdCustomer},
                LOrder = new BoOrder {LIdOrder = pIdOrder},
                LCdInvoice = pCdInvoice
            };
            return this.LiDaoInvoice.Dao_InsertInvoice(lInvoice);
        }

        public string bll_UpdateInvoice(string pCdInvoice, int pIdCustomer, int pIdObject, string pIdStatus)
        {
            var lInvoice = new BoInvoice
            {
                LObject = new BoObject {LIdObject = pIdObject},
                LStatus = new BoStatus {LIdStatus = pIdStatus},
                LCustomer = new BoCustomer {LIdCustomer = pIdCustomer},
                LCdInvoice = pCdInvoice
            };
            return this.LiDaoInvoice.Dao_UpdateInvoice(lInvoice);
        }

        public string bll_DeleteInvoice(int pIdInvoice)
        {
            var lInvoice = new BoInvoice {LIdInvoice = pIdInvoice};
            return this.LiDaoInvoice.Dao_DeleteInvoice(lInvoice);
        }
    }
}
