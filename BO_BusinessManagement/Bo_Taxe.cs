using System;
using System.ComponentModel.DataAnnotations;

namespace BO_BusinessManagement
{
    public class BoTaxe: BoException
    {
        [RegularExpression("^([1-9]{0,11})$", ErrorMessage = "No es valido la selección")]
        public int LIdTaxe { get; set; }

        public string LNameTaxe { get; set; }

        public decimal LValueTaxe { get; set; }

        public bool LIsPercent { get; set; }

        public DateTime LCreationDate { get; set; }

        public BoStatus LStatus { get; set; }

        public BoObject LObject { get; set; }
    }
}
