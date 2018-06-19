using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Project_BusinessManagement.Models.Enums;

namespace Project_BusinessManagement.Models
{
    public class MProduct
    {
        

        [DisplayName("IDProducto")]
        public int LIdProduct { get; set; }

        [Required(ErrorMessage = "El nombre de producto es requerido.")]
        [DisplayName("Nombre Producto")]
        public string LNameProduct { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "No es una fecha")]
        [DisplayName("Fecha De Creacion")]
        public DateTime LCreationDate { get; set; }

        public MUnit LUnit { get; set; }

        [Required(ErrorMessage = "El valor de producto es requerido.")]
        [DisplayName("Valor Producto")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        public decimal LValue { get; set; }


        public MSupplier LSupplier { get; set; }

        [Required(ErrorMessage = CodesError.LMsgValidateValueSupplier)]
        [DisplayName("Valor del Proveedor")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        public decimal LValueSupplier { get; set; }


        public MObject LObject { get; set; }

        [DisplayName("Estado")]
        public MStatus LStatus { get; set; }

        public List<SelectListItem> LListStatus { get; set; }

        [DisplayName("Proveedores")]
        public List<SelectListItem> LListUnit { get; set; }

        [DisplayName("Proveedores")]
        public List<SelectListItem> LListSupplier { get; set; }

        public string LMessageException { get; set; }

        [DisplayName("Codigo Producto")]
        [Required(ErrorMessage = CodesError.LMsgValidateCodeProduct)]
        public string LCdProduct { get; set; }

        public List<MTaxe> LListTaxe { get; set; }

        public MTaxe LTaxe { get; set; }

        public List<SelectListItem> LListSelectTaxe { get; set; }

        public string LListIdsTaxe { get; set; }

       
    }
}