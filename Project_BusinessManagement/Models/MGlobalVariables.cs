using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Project_BusinessManagement.Models
{
    public static class MGlobalVariables
    {
        private static string lNameObjectSupplier;
        private static string lNameObjectCustomer;
        private static string lNameObjectProduct;
        private static string lNameObjectInventory;
        private static string lNameObjectInventoryItem;

        public static string LNameObjectSupplier
        {
            get
            {
                lNameObjectSupplier = ConfigurationManager.AppSettings["objectSupplier"].ToString() ;
                return lNameObjectSupplier;
            }
        }

        public static string LNameObjectCustomer
        {
            get
            {
                lNameObjectCustomer = ConfigurationManager.AppSettings["objectCustomer"].ToString();
                return lNameObjectCustomer;
            }
        }

        public static string LNameObjectProduct
        {
            get
            {
                lNameObjectProduct = ConfigurationManager.AppSettings["objectProduct"].ToString();
                return lNameObjectProduct;
            }
        }

        public static string LNameObjectInventory
        {
            get
            {
                lNameObjectInventory= ConfigurationManager.AppSettings["objectInventory"].ToString();
                return lNameObjectInventory;
            }
        }

        public static string LNameObjectInventoryItem
        {
            get
            {
                lNameObjectInventoryItem = ConfigurationManager.AppSettings["objectInvenItem"].ToString();
                return lNameObjectInventoryItem;
            }
        }
    }
}