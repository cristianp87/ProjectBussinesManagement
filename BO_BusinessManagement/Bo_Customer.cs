using System;

namespace BO_BusinessManagement
{
    public class BoCustomer:BoException
    {
        public int LIdCustomer { get; set; }

        public string LNameCustomer { get; set; }

        public DateTime LCreationDate { get; set; }

        public BoTypeIdentification LTypeIdentification { get; set; }

        public string LNoIdentification { get; set; }

        public BoStatus LStatus { get; set; }

        public BoObject LObject { get; set; }

        public string LLastNameCustomer { get; set; }

        public DateTime LModificationDate { get; set; }
    }
}
