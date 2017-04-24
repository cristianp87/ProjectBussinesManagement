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

        public static string LNameObjectSupplier
        {
            get
            {
                lNameObjectSupplier = ConfigurationManager.AppSettings["objectSupplier"].ToString() ;
                return lNameObjectSupplier;
            }
        }
    }
}