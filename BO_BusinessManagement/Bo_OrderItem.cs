using System;

namespace BO_BusinessManagement
{
    public class BoOrderItem : BoException
    {
        private decimal myLValueTotal;

        public int LIdOrderItem { get; set; }

        public BoProduct LProduct { get; set; } = null;

        public DateTime LCreationDate { get; set; }

        public BoStatus LStatus { get; set; }

        public BoObject LObject { get; set; }

        public BoOrder LOrder { get; set; }

        public decimal LValueProduct { get; set; }

        public decimal LValueSupplier { get; set; }

        public decimal LValueTaxes { get; set; }

        public decimal LValueDesc { get; set; }

        public decimal LValueTotal
        {
            get {
                this.myLValueTotal = (((this.LValueProduct - this.LValueDesc) *this.LQty) + (this.LValueTaxes *this.LQty));
                return this.myLValueTotal; }
        }

        public decimal LQty { get; set; }
    }
}
