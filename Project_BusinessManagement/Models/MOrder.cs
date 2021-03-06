﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project_BusinessManagement.Models
{
    public class MOrder
    {
        public int LIdOrder { get; set; }

        [DisplayName("Fecha De Creación")]
        public DateTime LCreationDate { get; set; }

        public MStatus LStatus { get; set; }

        public MObject LObject { get; set; }

        public MInventory LInventory { get; set; }

        public MCustomer LCustomer { get; set; }

        public string LMessageException { get; set; }

        public List<MOrderItem> LListOrderItem { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        public decimal LValueOrder { get; set; }

        
    }
}