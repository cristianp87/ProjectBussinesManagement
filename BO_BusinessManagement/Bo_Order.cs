using System;
using System.Collections.Generic;

namespace BO_BusinessManagement
{
    public class BoOrder: BoException
    {
        public int LIdOrder { get; set; }

        public DateTime LCreationDate { get; set; }

        public BoStatus LStatus { get; set; }

        public BoObject LObject { get; set; }

        public BoInventory LInventory { get; set; }

        public BoCustomer LCustomer { get; set; }

        public List<BoOrderItem> LListOrderItem { get; set; }

        public decimal LValueOrder { get; set; }
    }
}
