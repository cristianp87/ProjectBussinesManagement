using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_BusinessManagement
{
    public class BoCashRegister : BoException
    {
        public int LIdCashRegister { get; set; }

        public int LIdCash { get; set; }

        public string LDescription { get; set; }

        public decimal LValue { get; set; }

        public DateTime LCreationDate { get; set; }

        public DateTime LModificationDate { get; set; }

        public bool LIsInput { get; set; }
    }
}
