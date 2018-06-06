using System;
using System.ComponentModel;

namespace Project_BusinessManagement.Models.Reports
{
    public class MReportSales
    {
        [DisplayName("Id")]
        public int LId { get; set; }

        [DisplayName("Codigo Venta")]
        public string LCode { get; set; }

        public MProduct LProduct { get; set; }

        [DisplayName("Fecha De Creación")]
        public DateTime LCreationDate { get; set; }

        [DisplayName("Valor Total")]
        public decimal LValuetotal { get; set; }

        public string LMessage { get; set; }
    }
}