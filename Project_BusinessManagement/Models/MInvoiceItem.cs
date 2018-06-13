using System;
using System.ComponentModel.DataAnnotations;

namespace Project_BusinessManagement.Models
{
    public class MInvoiceItem
    {
        private decimal myLValueTotal;

        public int LIdInvoiceItem { get; set; }

        public int LIdInvoice { get; set; }

        public MProduct LProduct { get; set; } = new MProduct();

        public DateTime LCreationDate { get; set; }

        public decimal LQuantity { get; set; }

        public MStatus LStatus { get; set; } = new MStatus();

        public MObject LObject { get; set; } = new MObject();

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        public decimal LValueTaxes { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        public decimal LValueSupplier { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        public decimal LValueDesc { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        public decimal LValueProd { get; set; }

        public string LMessageException { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        public decimal LValueTotal
        {
            get
            {
                this.myLValueTotal = (((this.LValueProd - this.LValueDesc) *this.LQuantity) + (this.LValueTaxes * this.LQuantity));
                return this.myLValueTotal;
            }
        }

        
    }
}