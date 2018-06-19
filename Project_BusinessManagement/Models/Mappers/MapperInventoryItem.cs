using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BO_BusinessManagement;
using IBusiness.Common;
using IBusiness.Management;

namespace Project_BusinessManagement.Models.Mappers
{
    public static class MapperInventoryItem
    {
        #region Variables and Constants
        public static IInventory LInventoryTInventory =
        FacadeProvider.Resolv<IInventory>();

        public static IProduct LiProduct =
        FacadeProvider.Resolv<IProduct>();

        public static IStatus LiStatus =
        FacadeProvider.Resolv<IStatus>();

        public static IUtilsLib LiUtilsLib =
        FacadeProvider.Resolv<IUtilsLib>();
        #endregion
        public static List<MInventoryItem> MListInventoryItem(this List<BoInventoryItem> oBListInventoryItem)
        {
            var oMListInventoryItem = new List<MInventoryItem>();
            oBListInventoryItem.ForEach(x => {
                var oMInventoryItem = new MInventoryItem
                {
                    LProduct = new MProduct
                    {
                        LNameProduct = x.LProduct.LNameProduct,
                        LIdProduct = x.LProduct.LIdProduct,
                        LCdProduct = x.LProduct.LCdProduct
                    },
                    LInventory = new MInventory
                    {
                        LIdInventory = x.LInventory.LIdInventory,
                        LNameInventory = x.LInventory.LNameInventory
                    },
                    LIdInventoryItem = x.LIdInventoryItem,
                    LQtySellable = x.LQtySellable,
                    LQtyNonSellable = x.LQtyNonSellable,
                    LCreationDate = x.LCreationDate
                };
                oMListInventoryItem.Add(oMInventoryItem);
            });
            return oMListInventoryItem;
        }

        public static MInventoryItem MInventoryItemById(this BoInventoryItem pInventoryItem)
        {
            var oMInventoryItem = new MInventoryItem
            {
                LStatus = new MStatus
                {
                    LIdStatus = pInventoryItem.LStatus.LIdStatus,
                    LDsEstado = pInventoryItem.LStatus.LDsEstado
                },
                LListStatus = new List<SelectListItem>(),
                LListProduct = new List<SelectListItem>(),
                LProduct = new MProduct
                {
                    LIdProduct = pInventoryItem.LProduct.LIdProduct,
                    LNameProduct = pInventoryItem.LProduct.LNameProduct
                },
                LIdInventoryItem = pInventoryItem.LIdInventoryItem,
                LInventory = new MInventory
                {
                    LIdInventory = pInventoryItem.LInventory.LIdInventory,
                    LNameInventory = pInventoryItem.LInventory.LNameInventory
                },
                LQtySellable = pInventoryItem.LQtySellable,
                LQtyNonSellable = pInventoryItem.LQtyNonSellable,
                LCreationDate = pInventoryItem.LCreationDate,
                LObject = new MObject
                {
                    LIdObject = pInventoryItem.LObject.LIdObject,
                    LNameObject = pInventoryItem.LObject.LNameObject
                }
            };
            oMInventoryItem.LListStatus = LiStatus.Bll_getListStatusByIdObject(oMInventoryItem.LObject.LIdObject).MListAllStatus();
            oMInventoryItem.LListProduct = LiProduct.bll_GetAllProduct().MListAllProduct(true);
            return oMInventoryItem;
        }

        public static MInventoryItem MInventoryEmpty(this int pIdInventory)
        {
            var obInventory = LInventoryTInventory.bll_GetInventoryById(pIdInventory);
            var oObject = LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectInventoryItem);
            var oMInventoryItem = new MInventoryItem
            {
                LStatus = new MStatus
                {
                    LDsEstado = null,
                    LIdStatus = null
                },
                LListStatus = new List<SelectListItem>(),
                LProduct = new MProduct(),
                LListProduct = new List<SelectListItem>(),
                LInventory = new MInventory
                {
                    LIdInventory = obInventory.LIdInventory,
                    LNameInventory = obInventory.LNameInventory
                },
                LQtySellable = 0,
                LQtyNonSellable = 0,
                LCreationDate = new DateTime(),
                LObject = new MObject
                {
                    LIdObject = oObject.LIdObject,
                    LNameObject = oObject.LNameObject
                }
            };
            oMInventoryItem.LListStatus = LiStatus.Bll_getListStatusByIdObject(oMInventoryItem.LObject.LIdObject).MListStatusWithSelect();
            oMInventoryItem.LListProduct = LiProduct.bll_GetAllProduct().MListAllProductwithSelect();
            return oMInventoryItem;
        }
    }
}