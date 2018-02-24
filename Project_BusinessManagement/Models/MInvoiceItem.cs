using BO_BusinessManagement;
using System;
using System.Collections.Generic;

namespace Project_BusinessManagement.Models
{
    public class MInvoiceItem
    {
        private decimal myLValueTotal;

        public int LIdInvoiceItem { get; set; } = 0;

        public int LIdInvoice { get; set; } = 0;

        public MProduct LProduct { get; set; } = new MProduct();

        public DateTime LCreationDate { get; set; } = new DateTime();

        public decimal LQuantity { get; set; } = 0;

        public MStatus LStatus { get; set; } = new MStatus();

        public MObject LObject { get; set; } = new MObject();

        public decimal LValueTaxes { get; set; }

        public decimal LValueSupplier { get; set; }

        public decimal LValueDesc { get; set; }

        public decimal LValueProd { get; set; }

        public decimal LValueTotal
        {
            get
            {
                this.myLValueTotal = (((this.LValueProd - this.LValueDesc) *this.LQuantity) + (this.LValueTaxes * this.LQuantity));
                return this.myLValueTotal;
            }
        }

        public static List<MInvoiceItem> MListInvoiceItem(List<Bo_InvoiceItem> pBoListInvoiceItem)
        {
            var lMListInvoiceItem = new List<MInvoiceItem>();
            pBoListInvoiceItem.ForEach(x => {
                                               var lMInvoiceItem = new MInvoiceItem
                                               {
                                                   LProduct = new MProduct
                                                   {
                                                       LIdProduct = x.LProduct.LIdProduct,
                                                       LCdProduct = x.LProduct.LCdProduct,
                                                       LNameProduct = x.LProduct.LNameProduct,
                                                       LValue = x.LProduct.LValue
                                                   },
                                                   LIdInvoice = x.LIdInvoice,
                                                   LIdInvoiceItem = x.LIdInvoiceItem,
                                                   LCreationDate = x.LCreationDate,
                                                   LQuantity = x.LQuantity,
                                                   LValueProd = x.LValueProd
                                               };
                                               lMListInvoiceItem.Add(lMInvoiceItem);
            });
            return lMListInvoiceItem;
        }
    }
}