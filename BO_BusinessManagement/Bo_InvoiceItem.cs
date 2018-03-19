using System;

namespace BO_BusinessManagement
{
    public class BoInvoiceItem: BoException
    {
        private decimal myLValueTotal;

        public int LIdInvoiceItem { get; set; }

        public int LIdInvoice { get; set; }

        public BoProduct LProduct { get; set; }

        public DateTime LCreationDate { get; set; }

        public decimal LQuantity { get; set; }

        public BoStatus LStatus { get; set; }

        public BoObject LObject { get; set; }

        public decimal LValueTaxes { get; set; }

        public decimal LValueSupplier { get; set; }

        public decimal LValueDesc { get; set; }

        public decimal LValueProd { get; set; }

        public decimal LValueTotal
        {
            get
            {
                this.myLValueTotal = (((this.LValueProd - this.LValueDesc) *this.LQuantity) + (this.LValueTaxes *this.LQuantity));
                return this.myLValueTotal;
            }
        }
    }
}
