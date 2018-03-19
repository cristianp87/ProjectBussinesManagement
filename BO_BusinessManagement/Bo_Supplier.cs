using System;

namespace BO_BusinessManagement
{
    public class BoSupplier: BoException
    {
        public int LIdSupplier { get; set; }

        public string LNameSupplier { get; set; }

        public BoTypeIdentification LTypeIdentification { get; set; }

        public string LNoIdentification { get; set; }

        public DateTime LCreationDate { get; set; }


        public BoStatus LStatus { get; set; }

        public BoObject LObject { get; set; }

        public DateTime LModificationDate { get; set; }
    }
}
