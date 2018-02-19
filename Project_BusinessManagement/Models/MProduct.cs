using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using IBusiness.Common;
using IBusiness.Management;
using Bll_Business;

namespace Project_BusinessManagement.Models
{
    public class MProduct
    {
        #region Variables and Constants
        public static ISupplier LiSupplier =
        FacadeProvider.Resolver<ISupplier>();

        public static IStatus LiStatus =
        FacadeProvider.Resolver<BllStatus>();

        public static ITaxe LiTaxe =
        FacadeProvider.Resolver<BllTaxe>();

        public static IUtilsLib LiUtilsLib =
        FacadeProvider.Resolver<BllUtilsLib>();
        #endregion

        [UIHint("LIdProduct")]
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
        public decimal LValue { get; set; }


        public MSupplier LSupplier { get; set; }

        [Required(ErrorMessage = "El valor del proveedor es requerido.")]
        [DisplayName("Valor del Proveedor")]
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
        [Required(ErrorMessage = "El valor del proveedor es requerido.")]
        public string LCdProduct { get; set; }

        public List<MTaxe> LListTaxe { get; set; }

        public MTaxe LTaxe { get; set; }

        public List<SelectListItem> LListSelectTaxe { get; set; }

        public string LListIdsTaxe { get; set; }

        public static List<MProduct> MListProduct(List<Bo_Product> oBListProduct)
        {
            List<MProduct> oMListProduct = new List<MProduct>();
            oBListProduct.ForEach(x => {
                                           var oMProduct = new MProduct
                                           {
                                               LIdProduct = x.LIdProduct,
                                               LNameProduct = x.LNameProduct,
                                               LCdProduct = x.LCdProduct,
                                               LValue = x.LValue,
                                               LValueSupplier = x.LValueSupplier,
                                               LCreationDate = x.LCreationDate
                                           };
                                           oMListProduct.Add(oMProduct);
            });
            return oMListProduct;
        }

        public static List<SelectListItem> MListAllProduct(List<Bo_Product> oBListProduct)
        {
            var oMListProduct = new List<SelectListItem>();
            oBListProduct.ForEach(x => {
                                           var oListItem = new SelectListItem
                                           {
                                               Value = x.LIdProduct.ToString(),
                                               Text = x.LNameProduct
                                           };
                                           oMListProduct.Add(oListItem);
            });
            return oMListProduct;
        }

        public static List<SelectListItem> MListAllProductwithSelect(List<Bo_Product> oBListProduct)
        {
            var oMListProduct = new List<SelectListItem>();
            var oListItemSelect = new SelectListItem
            {
                Text = "Seleccione...",
                Value = "0"
            };
            oMListProduct.Add(oListItemSelect);
            oBListProduct.ForEach(x => {
                                           var oListItem = new SelectListItem
                                           {
                                               Value = x.LIdProduct.ToString(),
                                               Text = x.LNameProduct
                                           };
                                           oMListProduct.Add(oListItem);
            });
            return oMListProduct;
        }

        public static MProduct MProductById(Bo_Product oBProduct)
        {
            var oMProduct = new MProduct
            {
                LObject = new MObject
                {
                    LIdObject = oBProduct.LObject.LIdObject,
                    LNameObject = oBProduct.LObject.LNameObject
                },
                LStatus = new MStatus
                {
                    LDsEstado = oBProduct.LStatus.LDsEstado,
                    LIdStatus = oBProduct.LStatus.LIdStatus
                },
                LUnit = new MUnit
                {
                    LIdUnit = oBProduct.LUnit.LIdUnit,
                    LNameUnit = oBProduct.LUnit.LNameUnit,
                    LCdUnit = oBProduct.LUnit.LCdUnit,
                    LFlActive = oBProduct.LUnit.LFlActive
                },
                LListStatus = new List<SelectListItem>(),
                LSupplier = new MSupplier
                {
                    LIdSupplier = oBProduct.LSupplier.LIdSupplier,
                    LNameSupplier = oBProduct.LSupplier.LNameSupplier
                },
                LListSupplier = new List<SelectListItem>(),
                LListTaxe = new List<MTaxe>(),
                LListUnit = new List<SelectListItem>(),
                LNameProduct = oBProduct.LNameProduct,
                LCdProduct = oBProduct.LCdProduct,
                LIdProduct = oBProduct.LIdProduct,
                LCreationDate = oBProduct.LCreationDate,
                LValue = oBProduct.LValue,
                LValueSupplier = oBProduct.LValueSupplier
            };
            oMProduct.LListSupplier = MSupplier.MListAllSupplier(LiSupplier.bll_GetAllSupplier());
            oMProduct.LListStatus = MStatus.MListAllStatus(LiStatus.Bll_getListStatusByIdObject(oBProduct.LObject.LIdObject));
            oMProduct.LListUnit = MUnit.MListAllUnitWithSelect(LiUtilsLib.bll_GetAllUnit());
            oMProduct.LListTaxe = MTaxe.MListAllTaxesXProduct(LiTaxe.bll_GetListallTaxesXProduct(oBProduct.LIdProduct), null);
            return oMProduct;
        }

        public static MProduct MProductEmpty(Bo_Product oBProduct)
        {          
            var oObject = LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectProduct);
            var oMProduct = new MProduct
            {
                LObject = new MObject
                {
                    LIdObject = oObject.LIdObject,
                    LNameObject = oObject.LNameObject
                },
                LStatus = new MStatus
                {
                    LDsEstado = null,
                    LIdStatus = null
                },
                LUnit = new MUnit(),
                LTaxe = new MTaxe(),
                LListUnit = new List<SelectListItem>(),
                LListStatus = new List<SelectListItem>(),
                LListSupplier = new List<SelectListItem>(),
                LListSelectTaxe = new List<SelectListItem>(),
                LListTaxe = new List<MTaxe>(),
                LNameProduct = null,
                LCdProduct = null,
                LValue = 0,
                LListIdsTaxe = null,
                LValueSupplier = 0,
                LCreationDate = new DateTime()
            };

            oMProduct.LListStatus = MStatus.MListStatusWithSelect(LiStatus.Bll_getListStatusByIdObject(oMProduct.LObject.LIdObject));
            oMProduct.LListSupplier = MSupplier.MListAllSupplierWithSelect(LiSupplier.bll_GetAllSupplier());
            oMProduct.LListUnit = MUnit.MListAllUnitWithSelect(LiUtilsLib.bll_GetAllUnit());
            oMProduct.LListSelectTaxe = MTaxe.MListTaxesWithSelect(LiTaxe.bll_GetListTaxes());
            return oMProduct;
        }
    }
}