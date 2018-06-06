using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Project_BusinessManagement.Models.Reports
{
    public class MReportAccountReceivable
    {
        [DisplayName("Id")]
        public int LId { get; set; }

        [DisplayName("Deuda")]
        public decimal LValueDebt { get; set; }

        public MProduct LProduct { get; set; }

        public MCustomer LCustomer { get; set; }


    }
}