using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Project_BusinessManagement.Models.Enums;

namespace Project_BusinessManagement.Models
{
    public class MStatus
    {
        [RegularExpression("^([1-9A-Za-z]{1}[0-9A-Za-z]{0,11})$", ErrorMessage = CodesError.LMsgValidateDdl)]
        public string LIdStatus { get; set; }

        [DisplayName("Estado")]
        public string LDsEstado { get; set; }

        public DateTime LCreationDate { get; set; }

        public bool LFlActive { get; set; }
        
    }
}