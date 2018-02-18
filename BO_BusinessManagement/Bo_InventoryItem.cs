using System;

namespace BO_BusinessManagement
{
    public class Bo_InventoryItem : Bo_Exception
    {
        private int lIdInventoryItem;
        private Bo_Product lProduct = null;
        private DateTime lCreationDate;
        private Bo_Status lStatus;
        private Bo_Object lObject;
        private Bo_Inventory lInventory;
        private decimal lQtySellable;
        private decimal lQtyNonSellable;

        public int LIdInventoryItem
        {
            get
            {
                return lIdInventoryItem;
            }

            set
            {
                lIdInventoryItem = value;
            }
        }

        public Bo_Product LProduct
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


        public decimal LQtySellable
        {
            get
            {
                return lQtySellable;
            }

            set
            {
                lQtySellable = value;
            }
        }

        public decimal LQtyNonSellable
        {
            get
            {
                return lQtyNonSellable;
            }

            set
            {
                lQtyNonSellable = value;
            }
        }

        public Bo_Inventory LInventory
        {
            get
            {
                return lInventory;
            }

            set
            {
                lInventory = value;
            }
        }
    }
}
