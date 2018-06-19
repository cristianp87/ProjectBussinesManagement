using System.ComponentModel;

namespace Project_BusinessManagement.Models
{
    public class MTypeIdentification
    {
        public int LIdTypeIdentification { get; set; }

        [DisplayName("Tipo De Identificación")]
        public string LTypeIdentification { get; set; }

        public bool LActive { get; set; }
    }
}