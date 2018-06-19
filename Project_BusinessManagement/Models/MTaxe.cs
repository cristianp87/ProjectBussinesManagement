using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project_BusinessManagement.Models
{
    public class MTaxe
    {
        [DisplayName("Id Impuesto")]
        public int LIdTaxe { get; set; }

        [DisplayName("Nombre")]
        public string LNameTaxe { get; set; }

        [DisplayName("Valor")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
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