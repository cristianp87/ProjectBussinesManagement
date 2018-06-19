using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Project_BusinessManagement.Models
{
    public class MInvoice
    {
        [DisplayName("Id Factura")]
        public int LIdInvoice { get; set; }

        [DisplayName("Codigo De Factura")]
        public string LCdInvoice { get; set; }

        [DisplayName("Fecha De Creación")]
        public DateTime LCreationDate { get; set; }

        public MObject LObject { get; set; }

        public MStatus LStatus { get; set; }

        public MCustomer LCustomer { get; set; }

        public List<MInvoiceItem> LListMInvoiceItem { get; set; } = new List<MInvoiceItem>();

        
    }
}