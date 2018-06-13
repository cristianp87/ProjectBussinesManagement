using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_BusinessManagement.Models
{
    public class MCashRegister
    {
        [DisplayName("Id Caja")]
        public int LIdCashRegister { get; set; }

        [DisplayName("Id Entrada")]
        public int LIdCash { get; set; }

        [DisplayName("Descripcion")]
        public string LDescription { get; set; }

        [DisplayName("Valor")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        public decimal LValue { get; set; }

        [DisplayName("Fecha De Creacion")]
        public DateTime LCreationDate { get; set; }

        public DateTime LModificationDate { get; set; }

        [DisplayName("Es Entrada")]
        public bool LIsInput { get; set; }

        public string LMessageException { get; set; }

    }
}