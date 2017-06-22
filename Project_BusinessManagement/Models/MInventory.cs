using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_BusinessManagement.Models
{
    public class MInventory
    {
        private int lIdInventory;
        private string lNameInventory;
        private DateTime lCreationDate;
        private MStatus lStatus;
        private MObject lObject;
        private List<MInventoryItem> lListInventoryItem = null;

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

        public List<MInventoryItem> LListInventoryItem
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