using System;

namespace BO_BusinessManagement
{
    public class BoInventoryItem : BoException
    {
        public int LIdInventoryItem { get; set; }

        public BoProduct LProduct { get; set; } = null;


        public DateTime LCreationDate { get; set; }

        public BoStatus LStatus { get; set; }

        public BoObject LObject { get; set; }


        public decimal LQtySellable { get; set; }

        public decimal LQtyNonSellable { get; set; }

        public BoInventory LInventory { get; set; }
    }
}
