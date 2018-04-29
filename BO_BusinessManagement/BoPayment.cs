namespace BO_BusinessManagement
{
    public class BoPayment
    {
        public BoObject LObject { get; set; }

        public BoStatus LStatus { get; set; }

        public int LIdPayment { get; set; }

        public decimal LValuePayment { get; set; }

        public decimal LCreationDate{ get; set; }

        public decimal LModificationDate { get; set; }
        
        public BoOrder LOrder { get; set; }
    }
}
