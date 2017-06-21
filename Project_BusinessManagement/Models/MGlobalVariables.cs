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
                lNameObjectCustomer = ConfigurationManager.AppSettings["objectProduct"].ToString();
                return lNameObjectCustomer;
            }
        }
    }
}