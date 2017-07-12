using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_BusinessManagement
{
    public class Bo_OrderItem : Bo_Exception
    {
        private int lIdOrderItem;
        private Bo_Product lProduct = null;
        private DateTime lCreationDate;
        private Bo_Status lStatus;
        private Bo_Object lObject;
        private Bo_Order lOrder;
        private decimal lValueProduct;
        private decimal lValueSupplier;
        private decimal lValueTaxes;
        private decimal lValueDesc;
        private decimal lValueTotal;

        public int LIdOrderItem
        {
            get
            {
                return lIdOrderItem;
            }

            set
            {
                lIdOrderItem = value;
            }
        }

        public Bo_Product LProduct
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

        public Bo_Order LOrder
        {
            get
            {
                return lOrder;
            }

            set
            {
                lOrder = value;
            }
        }

        public decimal LValueProduct
        {
            get
            {
                return lValueProduct;
            }

            set
            {
                lValueProduct = value;
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

        public decimal LValueTaxes
        {
            get
            {
                return lValueTaxes;
            }

            set
            {
                lValueTaxes = value;
            }
        }

        public decimal LValueDesc
        {
            get
            {
                return lValueDesc;
            }

            set
            {
                lValueDesc = value;
            }
        }

        public decimal LValueTotal
        {
            get { return ((LValueProduct - LValueDesc) + LValueTaxes); }
        }
    }
}
