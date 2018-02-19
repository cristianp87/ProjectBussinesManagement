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
        FacadeProvider.Resolver<BllSupplier>();

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

        [Required(ErrorMessage = CodesError.LMsgValidateValueSupplier)]
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
        [Required(ErrorMessage = CodesError.LMsgValidateCodeProduct)]
        public string LCdProduct { get; set; }

        public List<MTaxe> LListTaxe { get; set; }

        public MTaxe LTaxe { get; set; }

        public List<SelectListItem> LListSelectTaxe { get; set; }

        public string LListIdsTaxe { get; set; }

        public static List<MProduct> MListProduct(List<Bo_Product> pBoListProduct)
        {
            var lMListProduct = new List<MProduct>();
            pBoListProduct.ForEach(x => {
                                           var oMProduct = new MProduct
                                           {
                                               LIdProduct = x.LIdProduct,
                                               LNameProduct = x.LNameProduct,
                                               LCdProduct = x.LCdProduct,
                                               LValue = x.LValue,
                                               LValueSupplier = x.LValueSupplier,
                                               LCreationDate = x.LCreationDate
                                           };
                                           lMListProduct.Add(oMProduct);
            });
            return lMListProduct;
        }

        public static List<SelectListItem> MListAllProduct(List<Bo_Product> pBoListProduct)
        {
            var lMListProduct = new List<SelectListItem>();
            pBoListProduct.ForEach(x => {
                                           var oListItem = new SelectListItem
                                           {
                                               Value = x.LIdProduct.ToString(),
                                               Text = x.LNameProduct
                                           };
                                           lMListProduct.Add(oListItem);
            });
            return lMListProduct;
        }

        public static List<SelectListItem> MListAllProductwithSelect(List<Bo_Product> pBoListProduct)
        {
            var lMListProduct = new List<SelectListItem>();
            var lListItemSelect = new SelectListItem
            {
                Text = "Seleccione...",
                Value = "0"
            };
            lMListProduct.Add(lListItemSelect);
            pBoListProduct.ForEach(x => {
                                           var oListItem = new SelectListItem
                                           {
                                               Value = x.LIdProduct.ToString(),
                                               Text = x.LNameProduct
                                           };
                                           lMListProduct.Add(oListItem);
            });
            return lMListProduct;
        }

        public static MProduct MProductById(Bo_Product pBoProduct)
        {
            var lMProduct = new MProduct
            {
                LObject = new MObject
                {
                    LIdObject = pBoProduct.LObject.LIdObject,
                    LNameObject = pBoProduct.LObject.LNameObject
                },
                LStatus = new MStatus
                {
                    LDsEstado = pBoProduct.LStatus.LDsEstado,
                    LIdStatus = pBoProduct.LStatus.LIdStatus
                },
                LUnit = new MUnit
                {
                    LIdUnit = pBoProduct.LUnit.LIdUnit,
                    LNameUnit = pBoProduct.LUnit.LNameUnit,
                    LCdUnit = pBoProduct.LUnit.LCdUnit,
                    LFlActive = pBoProduct.LUnit.LFlActive
                },
                LListStatus = new List<SelectListItem>(),
                LSupplier = new MSupplier
                {
                    LIdSupplier = pBoProduct.LSupplier.LIdSupplier,
                    LNameSupplier = pBoProduct.LSupplier.LNameSupplier
                },
                LListSupplier = new List<SelectListItem>(),
                LListTaxe = new List<MTaxe>(),
                LListUnit = new List<SelectListItem>(),
                LNameProduct = pBoProduct.LNameProduct,
                LCdProduct = pBoProduct.LCdProduct,
                LIdProduct = pBoProduct.LIdProduct,
                LCreationDate = pBoProduct.LCreationDate,
                LValue = pBoProduct.LValue,
                LValueSupplier = pBoProduct.LValueSupplier
            };
            lMProduct.LListSupplier = MSupplier.MListAllSupplier(LiSupplier.bll_GetAllSupplier());
            lMProduct.LListStatus = MStatus.MListAllStatus(LiStatus.Bll_getListStatusByIdObject(pBoProduct.LObject.LIdObject));
            lMProduct.LListUnit = MUnit.MListAllUnitWithSelect(LiUtilsLib.bll_GetAllUnit());
            lMProduct.LListTaxe = MTaxe.MListAllTaxesXProduct(LiTaxe.bll_GetListallTaxesXProduct(pBoProduct.LIdProduct), null);
            return lMProduct;
        }

        public static MProduct MProductEmpty(Bo_Product pBoProduct)
        {          
            var lObject = LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectProduct);
            var lMProduct = new MProduct
            {
                LObject = new MObject
                {
                    LIdObject = lObject.LIdObject,
                    LNameObject = lObject.LNameObject
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
            lMProduct.LListStatus = MStatus.MListStatusWithSelect(LiStatus.Bll_getListStatusByIdObject(lMProduct.LObject.LIdObject));
            lMProduct.LListSupplier = MSupplier.MListAllSupplierWithSelect(LiSupplier.bll_GetAllSupplier());
            lMProduct.LListUnit = MUnit.MListAllUnitWithSelect(LiUtilsLib.bll_GetAllUnit());
            lMProduct.LListSelectTaxe = MTaxe.MListTaxesWithSelect(LiTaxe.bll_GetListTaxes());
            return lMProduct;
        }
    }
}