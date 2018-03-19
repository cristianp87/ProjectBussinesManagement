using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BO_BusinessManagement;
using IBusiness.Common;
using IBusiness.Management;
using Project_BusinessManagement.Extensibles;

namespace Project_BusinessManagement.Models.Mappers
{  
    public static class MapperProduct
    {
        #region Variables and Constants
        public static ISupplier LiSupplier =
        FacadeProvider.Resolv<ISupplier>();

        public static IStatus LiStatus =
        FacadeProvider.Resolv<IStatus>();

        public static ITaxe LiTaxe =
        FacadeProvider.Resolv<ITaxe>();

        public static IUtilsLib LiUtilsLib =
        FacadeProvider.Resolv<IUtilsLib>();
        #endregion
        public static List<MProduct> MListProduct(this List<BoProduct> pBoListProduct)
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

        public static List<SelectListItem> MListAllProduct(this List<BoProduct> pBoListProduct, bool pWithStatus)
        {
            var lMListProduct = new List<SelectListItem>();
            if (pWithStatus)
            {
                pBoListProduct.ForEach(x => {
                    if (x.LStatus.LIdStatus.ValidateStatus())
                    {
                        var lListItem = new SelectListItem
                        {
                            Value = x.LIdProduct.ToString(),
                            Text = x.LNameProduct
                        };
                        lMListProduct.Add(lListItem);
                    }
                    
                });
                return lMListProduct;
            }
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

        public static List<SelectListItem> MListAllProductwithSelect(this List<BoProduct> pBoListProduct)
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

        public static MProduct MProductById(this BoProduct pBoProduct)
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
            lMProduct.LListSupplier = LiSupplier.bll_GetAllSupplier().MListAllSupplier();
            lMProduct.LListStatus = LiStatus.Bll_getListStatusByIdObject(pBoProduct.LObject.LIdObject).MListAllStatus();
            lMProduct.LListUnit = LiUtilsLib.bll_GetAllUnit().MListAllUnitWithSelect();
            lMProduct.LListTaxe = LiTaxe.bll_GetListallTaxesXProduct(pBoProduct.LIdProduct).MListAllTaxesXProduct(null);
            return lMProduct;
        }

        public static MProduct MProductEmpty(this BoProduct pBoProduct)
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
            lMProduct.LListStatus = LiStatus.Bll_getListStatusByIdObject(lMProduct.LObject.LIdObject).MListStatusWithSelect();
            lMProduct.LListSupplier = LiSupplier.bll_GetAllSupplier().MListAllSupplierWithSelect(true);
            lMProduct.LListUnit = LiUtilsLib.bll_GetAllUnit().MListAllUnitWithSelect();
            lMProduct.LListSelectTaxe = LiTaxe.bll_GetListTaxes().MListTaxesWithSelect(true);
            return lMProduct;
        }
    }
}