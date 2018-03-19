using System.Configuration;

namespace Project_BusinessManagement.Models
{
    public static class MGlobalVariables
    {
        private static string _lNameObjectSupplier;
        private static string _lNameObjectCustomer;
        private static string _lNameObjectProduct;
        private static string _lNameObjectInventory;
        private static string _lNameObjectInventoryItem;
        private static string _lNameObjectOrder;
        private static string _lNameObjectOrderItem;
        private static string _lNameObjectInvoice;
        private static string _lNameObjectInvoiceItem;

        public static string LNameObjectSupplier
        {
            get
            {
                _lNameObjectSupplier = ConfigurationManager.AppSettings["objectSupplier"] ;
                return _lNameObjectSupplier;
            }
        }

        public static string LNameObjectCustomer
        {
            get
            {
                _lNameObjectCustomer = ConfigurationManager.AppSettings["objectCustomer"];
                return _lNameObjectCustomer;
            }
        }

        public static string LNameObjectProduct
        {
            get
            {
                _lNameObjectProduct = ConfigurationManager.AppSettings["objectProduct"];
                return _lNameObjectProduct;
            }
        }

        public static string LNameObjectInventory
        {
            get
            {
                _lNameObjectInventory= ConfigurationManager.AppSettings["objectInventory"];
                return _lNameObjectInventory;
            }
        }

        public static string LNameObjectInventoryItem
        {
            get
            {
                _lNameObjectInventoryItem = ConfigurationManager.AppSettings["objectInvenItem"];
                return _lNameObjectInventoryItem;
            }
        }

        public static string LNameObjectOrder
        {
            get
            {
                _lNameObjectOrder = ConfigurationManager.AppSettings["objectOrder"];
                return _lNameObjectOrder;
            }
        }

        public static string LNameObjectOrderItem
        {
            get
            {
                _lNameObjectOrderItem = ConfigurationManager.AppSettings["objectOrderItem"];
                return _lNameObjectOrderItem;
            }
        }

        public static string LNameObjectInvoice
        {
            get
            {
                _lNameObjectInvoice = ConfigurationManager.AppSettings["objectInvoice"];
                return _lNameObjectInvoice;
            }

        }

        public static string LNameObjectInvoiceItem
        {
            get
            {
                _lNameObjectInvoiceItem = ConfigurationManager.AppSettings["objectInvoiceItem"];
                return _lNameObjectInvoiceItem;
            }
        }
    }
}