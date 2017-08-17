using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_BusinessManagement
{
    public class Bo_Product: Bo_Exception
    {
        private int lIdProduct;
        private string lNameProduct;
        private DateTime lCreationDate;
        private Bo_Unit lUnit;
        private decimal lValue;
        private Bo_Supplier lSupplier;
        private decimal lValueSupplier;
        private Bo_Object lObject;
        private Bo_Status lStatus;
        private Bo_Taxe lTaxe;
        private string lCdProduct;

        public int LIdProduct
        {
            get
            {
                return lIdProduct;
            }

            set
            {
                lIdProduct = value;
            }
        }

        public string LNameProduct
        {
            get
            {
                return lNameProduct;
            }

            set
            {
                lNameProduct = value;
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

        public Bo_Unit LUnit
        {
            get
            {
                return lUnit;
            }

            set
            {
                lUnit = value;
            }
        }

        public decimal LValue
        {
            get
            {
                return lValue;
            }

            set
            {
                lValue = value;
            }
        }

        public Bo_Supplier LSupplier
        {
            get
            {
                return lSupplier;
            }

            set
            {
                lSupplier = value;
            }
        }

        public decimal LValueSupplier
        {
            get
            {
                return lValueSupplier;
            }

            set
            {
                lValueSupplier = value;
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

        public string LCdProduct
        {
            get
            {
                return lCdProduct;
            }

            set
            {
                lCdProduct = value;
            }
        }

        public Bo_Taxe LTaxe
        {
            get
            {
                return lTaxe;
            }

            set
            {
                lTaxe = value;
            }
        }
    }
}
