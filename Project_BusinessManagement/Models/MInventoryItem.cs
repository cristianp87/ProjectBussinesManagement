using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_BusinessManagement.Models
{
    public class MInventoryItem
    {
        private int lIdInventoryItem;
        private MProduct lProduct = null;
        private DateTime lCreationDate;
        private MStatus lStatus;
        private MObject lObject;
        private decimal lQtySellable;
        private decimal lQtyNonSellable;
        private int lIdInventory;

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

        public MProduct LProduct
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

        public MStatus LStatus
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

        public MObject LObject
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
    }
}