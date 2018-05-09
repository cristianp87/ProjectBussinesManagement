using Project_BusinessManagement.Models.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project_BusinessManagement.Models
{
    public class MPayment
    {
        public MObject LObject { get; set; }

        public MStatus LStatus { get; set; }

        public int LIdPayment { get; set; }

        [DisplayName("Valor Del Pago")]
        [Required(AllowEmptyStrings = true, ErrorMessage = CodesError.LMsgValidateName)]
        public decimal LValuePayment { get; set; }

        public DateTime LCreationDate { get; set; }

        public DateTime LModificationDate { get; set; }

        public MOrder LOrder { get; set; }

        public string LMessageException { get; set; }
    }
}