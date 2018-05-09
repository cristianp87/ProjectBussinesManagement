using System;

namespace BO_BusinessManagement
{
    public class BoPayment : BoException
    {
        public BoObject LObject { get; set; }

        public BoStatus LStatus { get; set; }

        public int LIdPayment { get; set; }

        public decimal LValuePayment { get; set; }

        public DateTime LCreationDate { get; set; }

        public DateTime LModificationDate { get; set; }
        
        public BoOrder LOrder { get; set; }
    }
}
