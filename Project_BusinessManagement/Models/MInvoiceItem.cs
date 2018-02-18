using BO_BusinessManagement;
using System;
using System.Collections.Generic;

namespace Project_BusinessManagement.Models
{
    public class MInvoiceItem
    {
        private int lIdInvoiceItem = 0;
        private int lIdInvoice = 0;
        private MProduct lProduct = new MProduct();
        private DateTime lCreationDate = new DateTime();
        private decimal lQuantity = 0;
        private MStatus lStatus = new MStatus();
        private MObject lObject = new MObject();
        private decimal lValueTaxes;
        private decimal lValueSupplier;
        private decimal lValueDesc;
        private decimal lValueProd;
        private decimal lValueTotal;

        public int LIdInvoiceItem
        {
            get
            {
                return lIdInvoiceItem;
            }

            set
            {
                lIdInvoiceItem = value;
            }
        }

        public int LIdInvoice
        {
            get
            {
                return lIdInvoice;
            }

            set
            {
                lIdInvoice = value;
            }
        }

        public MProduct LProduct
        {
            get
            {
                return lProduct;
            }

            set
            {
                lProduct = value;
            }
        }

        public DateTime LCreationDate
        {
            get
            {
                return lCreationDate;
            }

            set
            {
                lCreationDate = value;
            }
        }

        public decimal LQuantity
        {
            get
            {
                return lQuantity;
            }

            set
            {
                lQuantity = value;
            }
        }

        public MStatus LStatus
        {
            get
            {
                return lStatus;
            }

            set
            {
                lStatus = value;
            }
        }

        public MObject LObject
        {
            get
            {
                return lObject;
            }

            set
            {
                lObject = value;
            }
        }

        public decimal LValueTaxes
        {
            get
            {
                return lValueTaxes;
            }

            set
            {
                lValueTaxes = value;
            }
        }

        public decimal LValueSupplier
        {
            get
            {
                return lValueSupplier;
            }

            set
            {
                lValueSupplier = value;
            }
        }

        public decimal LValueDesc
        {
            get
            {
                return lValueDesc;
            }

            set
            {
                lValueDesc = value;
            }
        }

        public decimal LValueProd
        {
            get
            {
                return lValueProd;
            }

            set
            {
                lValueProd = value;
            }
        }

        public decimal LValueTotal
        {
            get
            {
                lValueTotal = (((LValueProd - LValueDesc) * LQuantity) + (LValueTaxes * LQuantity));
                return lValueTotal;
            }
        }

        public static List<MInvoiceItem> MListInvoiceItem(List<Bo_InvoiceItem> oBListInvoiceItem)
        {
            List<MInvoiceItem> oMListInvoiceItem = new List<MInvoiceItem>();
            oBListInvoiceItem.ForEach(x => {
                MInvoiceItem oMInvoiceItem = new MInvoiceItem();
                oMInvoiceItem.LProduct = new MProduct();
                oMInvoiceItem.LIdInvoice = x.LIdInvoice;
                oMInvoiceItem.LIdInvoiceItem = x.LIdInvoiceItem;
                oMInvoiceItem.LCreationDate = x.LCreationDate;
                oMInvoiceItem.LQuantity = x.LQuantity;
                oMInvoiceItem.LProduct.LIdProduct = x.LProduct.LIdProduct;
                oMInvoiceItem.LProduct.LCdProduct = x.LProduct.LCdProduct;
                oMInvoiceItem.LProduct.LNameProduct = x.LProduct.LNameProduct;
                oMInvoiceItem.LProduct.LValue = x.LProduct.LValue;
                oMInvoiceItem.lValueProd = x.LValueProd;
                oMListInvoiceItem.Add(oMInvoiceItem);
            });
            return oMListInvoiceItem;
        }
    }
}