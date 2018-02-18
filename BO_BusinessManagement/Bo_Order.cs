using System;
using System.Collections.Generic;

namespace BO_BusinessManagement
{
    public class Bo_Order: Bo_Exception
    {
        private int lIdOrder;
        private DateTime lCreationDate;
        private Bo_Status lStatus;
        private Bo_Object lObject;
        private Bo_Inventory lInventory;
        private Bo_Customer lCustomer;

        private List<Bo_OrderItem> lListOrderItem;

        public int LIdOrder
        {
            get
            {
                return lIdOrder;
            }

            set
            {
                lIdOrder = value;
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

        public Bo_Customer LCustomer
        {
            get
            {
                return lCustomer;
            }

            set
            {
                lCustomer = value;
            }
        }

        public List<Bo_OrderItem> LListOrderItem
        {
            get
            {
                return lListOrderItem;
            }

            set
            {
                lListOrderItem = value;
            }
        }
    }
}
