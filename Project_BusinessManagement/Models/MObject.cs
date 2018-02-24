using System.ComponentModel;

namespace Project_BusinessManagement.Models
{
    public class MObject
    {
        public int LIdObject { get; set; }

        [DisplayName("Objeto")]
        public string LNameObject { get; set; }

        public bool LActive { get; set; }
    }
}