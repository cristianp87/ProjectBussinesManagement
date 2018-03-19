using System;

namespace BO_BusinessManagement
{
    public class BoProduct: BoException
    {
        public int LIdProduct { get; set; }

        public string LNameProduct { get; set; }

        public DateTime LCreationDate { get; set; }

        public BoUnit LUnit { get; set; }

        public decimal LValue { get; set; }

        public BoSupplier LSupplier { get; set; }

        public decimal LValueSupplier { get; set; }

        public BoObject LObject { get; set; }

        public BoStatus LStatus { get; set; }

        public string LCdProduct { get; set; }

        public BoTaxe LTaxe { get; set; }
    }
}
