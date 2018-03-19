using System;
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

       
    }
}