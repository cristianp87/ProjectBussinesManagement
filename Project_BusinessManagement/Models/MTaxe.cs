using System;
using System.ComponentModel;

namespace Project_BusinessManagement.Models
{
    public class MTaxe
    {
        [DisplayName("Id Impuesto")]
        public int LIdTaxe { get; set; }

        [DisplayName("Nombre")]
        public string LNameTaxe { get; set; }

        [DisplayName("Valor")]
        public decimal LValueTaxe { get; set; }

        [DisplayName("Porcentaje")]
        public bool LIsPercent { get; set; }

        [DisplayName("Fecha Creacion")]
        public DateTime LCreationDate { get; set; }

        public MStatus LStatus { get; set; }

        public MObject LObject { get; set; }

        public int LIdProduct { get; set; }

        public string LMessageException { get; set; }
       
    }
}