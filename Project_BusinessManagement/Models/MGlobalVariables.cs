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
        private static string lNameObjectOrder;
        private static string lNameObjectOrderItem;
        private static string lNameObjectInvoice;
        private static string lNameObjectInvoiceItem;

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

        public static string LNameObjectOrder
        {
            get
            {
                lNameObjectOrder = ConfigurationManager.AppSettings["objectOrder"].ToString();
                return lNameObjectOrder;
            }
        }

        public static string LNameObjectOrderItem
        {
            get
            {
                lNameObjectOrderItem = ConfigurationManager.AppSettings["objectOrderItem"].ToString();
                return lNameObjectOrderItem;
            }
        }

        public static string LNameObjectInvoice
        {
            get
            {
                lNameObjectInvoice = ConfigurationManager.AppSettings["objectInvoice"].ToString();
                return lNameObjectInvoice;
            }

        }

        public static string LNameObjectInvoiceItem
        {
            get
            {
                lNameObjectInvoiceItem = ConfigurationManager.AppSettings["objectInvoiceItem"].ToString();
                return lNameObjectInvoiceItem;
            }

        }
    }
}