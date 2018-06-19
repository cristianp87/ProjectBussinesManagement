using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Project_BusinessManagement.Models
{
    public class MInventoryItem
    {
       
        [DisplayName("Id Item")]
        public int LIdInventoryItem { get; set; }

        public MProduct LProduct { get; set; }

        [DisplayName("Fecha De Creación")]
        public DateTime LCreationDate { get; set; }

        public MStatus LStatus { get; set; }

        public MObject LObject { get; set; }

        [DisplayName("Cantidad Vendible")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        public decimal LQtySellable { get; set; }

        [DisplayName("Cantidad No Vendible")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        public decimal LQtyNonSellable { get; set; }

        public List<SelectListItem> LListStatus { get; set; }

        public List<SelectListItem> LListProduct { get; set; }

        public string LMessageException { get; set; }

        public MInventory LInventory { get; set; }

        


    }
}