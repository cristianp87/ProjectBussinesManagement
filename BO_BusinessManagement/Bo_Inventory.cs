using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_BusinessManagement
{
    public class Bo_Inventory: Bo_Exception
    {
        private int lIdInventory;
        private string lNameInventory;
        private DateTime lCreationDate;
        private Bo_Status lStatus;
        private Bo_Object lObject;
        private List<Bo_InventoryItem> lListInventoryItem = null;

        public int LIdInventory
        {
            get
            {
                return lIdInventory;
            }

            set
            {
                lIdInventory = value;
            }
        }

        public string LNameInventory
        {
            get
            {
                return lNameInventory;
            }

            set
            {
                lNameInventory = value;
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

        public Bo_Status LStatus
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

        public Bo_Object LObject
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

        public List<Bo_InventoryItem> LListInventoryItem
        {
            get
            {
                return lListInventoryItem;
            }

            set
            {
                lListInventoryItem = value;
            }
        }
    }
}
