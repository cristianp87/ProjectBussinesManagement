using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_BusinessManagement.Models
{
    public class MOrderItem
    {
        private int lIdOrderItem;
        private MProduct lProduct = null;
        private DateTime lCreationDate;
        private MStatus lStatus;
        private MObject lObject;
        private MOrder lOrder;
        private decimal lQty;
        private decimal lValueProduct;
        private decimal lValueSupplier;
        private decimal lValueTaxes;
        private decimal lValueDesc;
        private decimal lValueTotal;
        private string lMessageException;

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

        public MOrder LOrder
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
            get
            {
                return lValueTotal;
            }

            set
            {
                lValueTotal = value;
            }
        }

        public string LMessageException
        {
            get
            {
                return lMessageException;
            }

            set
            {
                lMessageException = value;
            }
        }

        public decimal LQty
        {
            get
            {
                return lQty;
            }

            set
            {
                lQty = value;
            }
        }
    }
}