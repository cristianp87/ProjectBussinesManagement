using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using IBusiness.Common;
using IBusiness.Management;

namespace Project_BusinessManagement.Models
{
    public class MInventoryItem
    {
        #region Variables and Constants
        public static IInventory LInventoryTInventory =
        FacadeProvider.Resolver<IInventory>();

        public static IProduct LiProduct =
        FacadeProvider.Resolver<IProduct>();

        public static IStatus LiStatus =
        FacadeProvider.Resolver<IStatus>();

        public static IUtilsLib LiUtilsLib =
        FacadeProvider.Resolver<IUtilsLib>();
        #endregion

        [DisplayName("Id Item")]
        public int LIdInventoryItem { get; set; }

        public MProduct LProduct { get; set; } = null;

        [DisplayName("Fecha De Creación")]
        public DateTime LCreationDate { get; set; }

        public MStatus LStatus { get; set; }

        public MObject LObject { get; set; }

        [DisplayName("Cantidad Vendible")]
        public decimal LQtySellable { get; set; }

        [DisplayName("Cantidad No Vendible")]
        public decimal LQtyNonSellable { get; set; }

        public List<SelectListItem> LListStatus { get; set; }

        public List<SelectListItem> LListProduct { get; set; }

        public string LMessageException { get; set; }

        public MInventory LInventory { get; set; }

        public static List<MInventoryItem> MListInventoryItem(List<Bo_InventoryItem> oBListInventoryItem)
        {
            var oMListInventoryItem = new List<MInventoryItem>();
            oBListInventoryItem.ForEach(x => {
                                                 var oMInventoryItem = new MInventoryItem
                                                 {
                                                     LProduct = new MProduct
                                                     {
                                                         LNameProduct = x.LProduct.LNameProduct,
                                                         LIdProduct = x.LProduct.LIdProduct
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

        public static MInventoryItem MInventoryItemById(Bo_InventoryItem pInventoryItem)
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
            oMInventoryItem.LListStatus = MStatus.MListAllStatus(LiStatus.Bll_getListStatusByIdObject(oMInventoryItem.LObject.LIdObject));
            oMInventoryItem.LListProduct = MProduct.MListAllProduct(LiProduct.bll_GetAllProduct());
            return oMInventoryItem;
        }

        public static MInventoryItem MInventoryEmpty(int pIdInventory)
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
            oMInventoryItem.LListStatus = MStatus.MListStatusWithSelect(LiStatus.Bll_getListStatusByIdObject(oMInventoryItem.LObject.LIdObject));
            oMInventoryItem.LListProduct = MProduct.MListAllProductwithSelect(LiProduct.bll_GetAllProduct());
            return oMInventoryItem;
        }


    }
}