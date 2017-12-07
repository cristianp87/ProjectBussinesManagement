using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Fecha De Creación")]
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
        [DisplayName("Valor de Producto")]
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
        [DisplayName("Valoe de Proveedor")]
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

        [DisplayName("Valor De Impuestos")]
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
        [DisplayName("Valor de Descuento")]
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
        [DisplayName("Valor Total")]
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
        [DisplayName("Cantidad")]
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

        public static List<MOrderItem> MListOrder(List<Bo_OrderItem> pListOrderItem)
        {
            List<MOrderItem> lListOrderItem = new List<MOrderItem>();
            pListOrderItem.ForEach(x => {
                MOrderItem lMOrderItem = new MOrderItem();
                lMOrderItem.LProduct = new MProduct();
                lMOrderItem.lOrder = new MOrder();
                lMOrderItem.LIdOrderItem = x.LIdOrderItem;
                lMOrderItem.LProduct.LNameProduct = x.LProduct.LNameProduct;
                lMOrderItem.LProduct.LIdProduct = x.LProduct.LIdProduct;
                lMOrderItem.LOrder.LIdOrder = x.LOrder.LIdOrder;
                lMOrderItem.LQty = x.LQty;
                lMOrderItem.LValueProduct = x.LValueProduct;
                lMOrderItem.LValueSupplier = x.LValueSupplier;
                lMOrderItem.LValueTaxes = x.LValueTaxes;
                lMOrderItem.LValueDesc = x.LValueDesc;
                lMOrderItem.LCreationDate = x.LCreationDate;
                lMOrderItem.LValueTotal = x.LValueTotal;
                lListOrderItem.Add(lMOrderItem);
            });
            return lListOrderItem;
        }
    }
}