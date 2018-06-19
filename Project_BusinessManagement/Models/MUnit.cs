using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project_BusinessManagement.Models
{
    public class MUnit
    {
        [RegularExpression("^([1-9]{0,11})$", ErrorMessage = "No es valido la selección")]
        public int LIdUnit { get; set; }

        [DisplayName("Nombre de Unidad")]
        public string LNameUnit { get; set; }

        public string LCdUnit { get; set; }

        public bool LFlActive { get; set; }

        
    }
}