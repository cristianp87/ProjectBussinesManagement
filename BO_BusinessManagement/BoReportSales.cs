using System;

namespace BO_BusinessManagement
{
    public class BoReportSales : BoException
    {
        public int LId { get; set; }

        public string LCode { get; set; }

        public BoProduct LProduct { get; set; }

        public DateTime LCreationDate { get; set; }

        public decimal LQty { get; set; } 

        public decimal LValuetotal { get; set; }
    }
}
