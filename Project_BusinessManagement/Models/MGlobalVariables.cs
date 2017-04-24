using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_BusinessManagement.Models
{
    public static class MGlobalVariables
    {
        private static MObject lObjectSupplier;

        public static MObject LObjectSupplier
        {
            get
            {
                lObjectSupplier.LNameObject = HttpContext.Current.Application["objectSupplier"].ToString();
                return lObjectSupplier;
            }
        }
    }
}