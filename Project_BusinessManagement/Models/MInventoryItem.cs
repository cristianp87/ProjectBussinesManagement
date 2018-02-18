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
        #endregion
        private int lIdInventoryItem;
        private MProduct lProduct = null;
        private DateTime lCreationDate;
        private MStatus lStatus;
        private MObject lObject;
        private decimal lQtySellable;
        private decimal lQtyNonSellable;
        private MInventory lInventory;
        private List<SelectListItem> lListStatus;
        private List<SelectListItem> lListProduct;
        private string lMessageException;

        [DisplayName("Id Item")]
        public int LIdInventoryItem
        {
            get
            {
                return lIdInventoryItem;
            }

            set
            {
                lIdInventoryItem = value;
            }
        }

        public MProduct LProduct
        {
            get
            {
                return lProduct;
            }

            set
            {
                lProduct = value;
            }
        }

        [DisplayName("Fecha De Creación")]
        public DateTime LCreationDate
        {
            get
            {
                return lCreationDate;
            }

            set
            {
                lCreationDate = value;
            }
        }

        public MStatus LStatus
        {
            get
            {
                return lStatus;
            }

            set
            {
                lStatus = value;
            }
        }

        public MObject LObject
        {
            get
            {
                return lObject;
            }

            set
            {
                lObject = value;
            }
        }

        [DisplayName("Cantidad Vendible")]
        public decimal LQtySellable
        {
            get
            {
                return lQtySellable;
            }

            set
            {
                lQtySellable = value;
            }
        }
        [DisplayName("Cantidad No Vendible")]
        public decimal LQtyNonSellable
        {
            get
            {
                return lQtyNonSellable;
            }

            set
            {
                lQtyNonSellable = value;
            }
        }

        public List<SelectListItem> LListStatus
        {
            get
            {
                return lListStatus;
            }

            set
            {
                lListStatus = value;
            }
        }

        public List<SelectListItem> LListProduct
        {
            get
            {
                return lListProduct;
            }

            set
            {
                lListProduct = value;
            }
        }

        public string LMessageException
        {
            get
            {
                return lMessageException;
            }

            set
            {
                lMessageException = value;
            }
        }

        public MInventory LInventory
        {
            get
            {
                return lInventory;
            }

            set
            {
                lInventory = value;
            }
        }

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
                                                     lQtySellable = x.LQtySellable,
                                                     LQtyNonSellable = x.LQtyNonSellable,
                                                     LCreationDate = x.LCreationDate
                                                 };
                                                 oMListInventoryItem.Add(oMInventoryItem);
            });
            return oMListInventoryItem;
        }

        public static MInventoryItem MInventoryItemById(Bo_InventoryItem oBInventoryItem)
        {
            var oMInventoryItem = new MInventoryItem
            {
                LObject = new MObject(),
                LStatus = new MStatus
                {
                    LIdStatus = oBInventoryItem.LStatus.LIdStatus,
                    LDsEstado = oBInventoryItem.LStatus.LDsEstado
                },
                LListStatus = new List<SelectListItem>(),
                LListProduct = new List<SelectListItem>(),
                LProduct = new MProduct
                {
                    LIdProduct = oBInventoryItem.LProduct.LIdProduct,
                    LNameProduct = oBInventoryItem.LProduct.LNameProduct
                },
                LInventory = new MInventory(),
                LIdInventoryItem = oBInventoryItem.LIdInventoryItem,
                lInventory =
                {
                    LIdInventory = oBInventoryItem.LInventory.LIdInventory,
                    LNameInventory = oBInventoryItem.LInventory.LNameInventory
                },
                lQtySellable = oBInventoryItem.LQtySellable,
                LQtyNonSellable = oBInventoryItem.LQtyNonSellable,
                LCreationDate = oBInventoryItem.LCreationDate,
                lObject =
                {
                    LIdObject = oBInventoryItem.LObject.LIdObject,
                    LNameObject = oBInventoryItem.LObject.LNameObject
                }
            };
            oMInventoryItem.LListStatus = MStatus.MListAllStatus(Bll_Business.Bll_Status.Bll_getListStatusByIdObject(oMInventoryItem.LObject.LIdObject));
            oMInventoryItem.LListProduct = MProduct.MListAllProduct(LiProduct.bll_GetAllProduct());
            return oMInventoryItem;
        }

        public static MInventoryItem MInventoryEmpty(int pIdInventory)
        {          
            var obInventory = LInventoryTInventory.bll_GetInventoryById(pIdInventory);
            var oObject = Bll_Business.Bll_UtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectInventoryItem);
            var oMInventoryItem = new MInventoryItem
            {
                LObject = new MObject(),
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
                lQtySellable = 0,
                LQtyNonSellable = 0,
                LCreationDate = new DateTime(),
                lObject =
                {
                    LIdObject = oObject.LIdObject,
                    LNameObject = oObject.LNameObject
                }
            };
            oMInventoryItem.LListStatus = MStatus.MListStatusWithSelect(Bll_Business.Bll_Status.Bll_getListStatusByIdObject(oMInventoryItem.LObject.LIdObject));
            oMInventoryItem.LListProduct = MProduct.MListAllProductwithSelect(LiProduct.bll_GetAllProduct());
            return oMInventoryItem;
        }


    }
}