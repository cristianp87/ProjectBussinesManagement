using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Project_BusinessManagement.Models.Enums;

namespace Project_BusinessManagement.Models
{
    public class MCustomer
    {
        

        [DisplayName("Id CLiente")]
        public int LIdCustomer { get; set; }

        [Display(Name = "Nombre Cliente")]
        [Required(ErrorMessage = CodesError.LMsgValidateName)]
        public string LNameCustomer { get; set; }

        [DisplayName("Apellidos Cliente")]
        [Required(ErrorMessage = CodesError.LMsgValidateLastName)]
        public string LLastNameCustomer { get; set; }

        [DisplayName("Fecha De Creacion")]
        public DateTime LCreationDate { get; set; }

        [DisplayName("Tipo De Identificacion")]
        public MTypeIdentification LTypeIdentification { get; set; }

        [Display(Name = "Numero de Identificacion")]
        [Required(ErrorMessage = CodesError.LMsgValidateNoIdentification)]
        public string LNoIdentification { get; set; }

        [DisplayName("Estado")]
        public MStatus LStatus { get; set; }

        public MObject LObject { get; set; }

        [DisplayName("Tipo De Identificacion")]
        public List<SelectListItem> LListTypeIdentification { get; set; }

        [DisplayName("Estado")]
        public List<SelectListItem> LListStatus { get; set; }

        public string LMessageException { get; set; }

        [DisplayName("Fecha De Modificacion")]
        public DateTime LModificationDate { get; set; }

        
    }
}