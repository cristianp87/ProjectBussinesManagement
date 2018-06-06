using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Project_BusinessManagement.Models
{
    public class MCashRegister
    {
        public int LIdCashRegister { get; set; }

        public int LIdCash { get; set; }

        [DisplayName("Descripcion")]
        public string LDescription { get; set; }

        [DisplayName("Valor")]
        public decimal LValue { get; set; }

        [DisplayName("Fecha De Creacion")]
        public DateTime LCreationDate { get; set; }

        public DateTime LModificationDate { get; set; }

        [DisplayName("Es Entrada")]
        public bool LIsInput { get; set; }

        public string LMessageException { get; set; }

    }
}