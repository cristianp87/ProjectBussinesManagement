using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Project_BusinessManagement.Models.Enums;

namespace Project_BusinessManagement.Models
{
    public class MInventory
    {
        
        [DisplayName("Id Inventario")]
        public int LIdInventory { get; set; }

        [DisplayName("Nombre De Inventario")]
        [Required(ErrorMessage = CodesError.LMsgValidateName)]
        public string LNameInventory { get; set; }

        [DisplayName("Fecha De Creación")]
        public DateTime LCreationDate { get; set; }

        public MStatus LStatus { get; set; }

        public MObject LObject { get; set; }

        public List<MInventoryItem> LListInventoryItem { get; set; } = null;

        public List<SelectListItem> LListStatus { get; set; }

        public string LMessageException { get; set; }  
    }
}