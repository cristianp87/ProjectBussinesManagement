using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Project_BusinessManagement.Models
{
    public class MOrderItem
    {
        public int LIdOrderItem { get; set; }

        public MProduct LProduct { get; set; } = null;

        [DisplayName("Fecha De Creación")]
        public DateTime LCreationDate { get; set; }

        public MStatus LStatus { get; set; }

        public MObject LObject { get; set; }

        public MOrder LOrder { get; set; }

        [DisplayName("Valor de Producto")]
        public decimal LValueProduct { get; set; }

        [DisplayName("Valoe de Proveedor")]
        public decimal LValueSupplier { get; set; }

        [DisplayName("Valor De Impuestos")]
        public decimal LValueTaxes { get; set; }

        [DisplayName("Valor de Descuento")]
        public decimal LValueDesc { get; set; }

        [DisplayName("Valor Total")]
        public decimal LValueTotal { get; set; }

        public string LMessageException { get; set; }

        [DisplayName("Cantidad")]
        public decimal LQty { get; set; }

        public static List<MOrderItem> MListOrder(List<Bo_OrderItem> pListOrderItem)
        {
            var lListOrderItem = new List<MOrderItem>();
            pListOrderItem.ForEach(x => {
                                            var lMOrderItem = new MOrderItem
                                            {
                                                LProduct = new MProduct
                                                {
                                                    LNameProduct = x.LProduct.LNameProduct,
                                                    LIdProduct = x.LProduct.LIdProduct
                                                },
                                                LOrder = new MOrder {LIdOrder = x.LOrder.LIdOrder},
                                                LIdOrderItem = x.LIdOrderItem,
                                                LQty = x.LQty,
                                                LValueProduct = x.LValueProduct,
                                                LValueSupplier = x.LValueSupplier,
                                                LValueTaxes = x.LValueTaxes,
                                                LValueDesc = x.LValueDesc,
                                                LCreationDate = x.LCreationDate,
                                                LValueTotal = x.LValueTotal
                                            };
                                            lListOrderItem.Add(lMOrderItem);
            });
            return lListOrderItem;
        }
    }
}