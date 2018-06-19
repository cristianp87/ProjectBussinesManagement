using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Project_BusinessManagement.Models.Enums;

namespace Project_BusinessManagement.Models
{
    public class MSupplier
    {
        

        [DisplayName("IDProveedores")]
        [RegularExpression("^([1-9][0-9]{0,11})$", ErrorMessage = CodesError.LMsgValidateDdl)]
        public int LIdSupplier { get; set; }

        [DisplayName("Nombre Proveedor")]
        [Required(AllowEmptyStrings = true, ErrorMessage = CodesError.LMsgValidateName)]
        public string LNameSupplier { get; set; }

        public MTypeIdentification LTypeIdentification { get; set; }

        [DisplayName("Numero Identificacion")]
        [Required(AllowEmptyStrings = true, ErrorMessage = CodesError.LMsgValidateNoIdentification)]
        public string LNoIdentification { get; set; }

        [DisplayName("Fecha De Creacion")]
        [DataType(DataType.DateTime,ErrorMessage = CodesError.LMsgValidateFormatDatetime)]
        public DateTime LCreationDate { get; set; }

        [DisplayName("Estado")]
        public MStatus LStatus { get; set; }

        public MObject LObject { get; set; }

        [DisplayName("Tipo De Identificación")]
        public List<SelectListItem> LListTypeIdentification { get; set; }

        [DisplayName("Estado")]
        public List<SelectListItem> LListStatus { get; set; }

        [DisplayName("Fecha De Modificacion")]
        public DateTime LModificationDate { get; set; }

        public string LMessageException { get; set; }
        
    }
}