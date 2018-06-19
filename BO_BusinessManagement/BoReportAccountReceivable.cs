using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_BusinessManagement
{
    public class BoReportAccountReceivable : BoException
    {
        public int LId{ get; set; }

        public decimal LValueDebt { get; set; }

        public BoProduct LProduct { get; set; }

        public BoCustomer LCustomer { get; set; }
    }
}
