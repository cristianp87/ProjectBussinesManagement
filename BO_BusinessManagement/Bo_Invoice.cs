using System;
using System.Collections.Generic;

namespace BO_BusinessManagement
{
    public class BoInvoice: BoException
    {
        public int LIdInvoice { get; set; }

        public string LCdInvoice { get; set; }


        public DateTime LCreationDate { get; set; }

        public BoObject LObject { get; set; }

        public BoStatus LStatus { get; set; }

        public BoCustomer LCustomer { get; set; }


        public List<BoInvoiceItem> LListInvoiceItem { get; set; }

        public BoOrder LOrder { get; set; }

        public decimal LValueInvoice { get; set; }
    }
}
