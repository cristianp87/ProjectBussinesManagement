using System;
using System.Collections.Generic;

namespace BO_BusinessManagement
{
    public class BoInventory: BoException
    {
        public int LIdInventory { get; set; }

        public string LNameInventory { get; set; }

        public DateTime LCreationDate { get; set; }

        public BoStatus LStatus { get; set; }

        public BoObject LObject { get; set; }

        public List<BoInventoryItem> LListInventoryItem { get; set; } = null;
    }
}
