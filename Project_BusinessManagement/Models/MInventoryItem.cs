using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Project_BusinessManagement.Models
{
    public class MInventoryItem
    {
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
            List<MInventoryItem> oMListInventoryItem = new List<MInventoryItem>();
            oBListInventoryItem.ForEach(x => {
                MInventoryItem oMInventoryItem = new MInventoryItem();
                oMInventoryItem.LProduct = new MProduct();
                oMInventoryItem.LInventory = new MInventory();
                oMInventoryItem.LInventory.LIdInventory = x.LInventory.LIdInventory;
                oMInventoryItem.LInventory.LNameInventory = x.LInventory.LNameInventory;
                oMInventoryItem.LIdInventoryItem = x.LIdInventoryItem;
                oMInventoryItem.LProduct.LIdProduct = x.LProduct.LIdProduct;
                oMInventoryItem.LProduct.LNameProduct = x.LProduct.LNameProduct;
                oMInventoryItem.lQtySellable = x.LQtySellable;
                oMInventoryItem.LQtyNonSellable = x.LQtyNonSellable;
                oMInventoryItem.LCreationDate = x.LCreationDate;
                oMListInventoryItem.Add(oMInventoryItem);
            });
            return oMListInventoryItem;
        }

        public static MInventoryItem MInventoryItemById(Bo_InventoryItem oBInventoryItem)
        {
            MInventoryItem oMInventoryItem = new MInventoryItem();
            oMInventoryItem.LObject = new MObject();
            oMInventoryItem.LStatus = new MStatus();
            oMInventoryItem.LListStatus = new List<SelectListItem>();
            oMInventoryItem.LListProduct = new List<SelectListItem>();
            oMInventoryItem.LProduct = new MProduct();
            oMInventoryItem.LInventory = new MInventory();
            oMInventoryItem.LIdInventoryItem = oBInventoryItem.LIdInventoryItem;
            oMInventoryItem.lInventory.LIdInventory = oBInventoryItem.LInventory.LIdInventory;
            oMInventoryItem.lInventory.LNameInventory = oBInventoryItem.LInventory.LNameInventory;
            oMInventoryItem.lQtySellable = oBInventoryItem.LQtySellable;
            oMInventoryItem.LQtyNonSellable = oBInventoryItem.LQtyNonSellable;
            oMInventoryItem.LCreationDate = oBInventoryItem.LCreationDate;
            oMInventoryItem.lObject.LIdObject = oBInventoryItem.LObject.LIdObject;
            oMInventoryItem.lObject.LNameObject = oBInventoryItem.LObject.LNameObject;
            oMInventoryItem.LStatus.LDsEstado = oBInventoryItem.LStatus.LDsEstado;
            oMInventoryItem.LStatus.LIdStatus = oBInventoryItem.LStatus.LIdStatus;
            oMInventoryItem.LProduct.LIdProduct = oBInventoryItem.LProduct.LIdProduct;
            oMInventoryItem.LProduct.LNameProduct = oBInventoryItem.LProduct.LNameProduct;
            oMInventoryItem.LListStatus = MStatus.MListAllStatus(Bll_Business.Bll_Status.Bll_getListStatusByIdObject(oMInventoryItem.LObject.LIdObject));
            oMInventoryItem.LListProduct = MProduct.MListAllProduct(Bll_Business.Bll_Product.bll_GetAllProduct());
            return oMInventoryItem;
        }

        public static MInventoryItem MInventoryEmpty(int pIdInventory)
        {
            MInventoryItem oMInventoryItem = new MInventoryItem();
            Bo_Object oObject = new Bo_Object();
            Bo_Inventory obInventory = Bll_Business.Bll_Inventory.bll_GetInventoryById(pIdInventory);
            oObject = Bll_Business.Bll_UtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectInventoryItem);
            oMInventoryItem.LObject = new MObject();
            oMInventoryItem.LStatus = new MStatus();
            oMInventoryItem.LListStatus = new List<SelectListItem>();
            oMInventoryItem.LProduct = new MProduct();
            oMInventoryItem.LListProduct = new List<SelectListItem>();
            oMInventoryItem.LInventory = new MInventory();
            oMInventoryItem.LInventory.LIdInventory = obInventory.LIdInventory;
            oMInventoryItem.LInventory.LNameInventory = obInventory.LNameInventory;
            oMInventoryItem.lQtySellable = 0;
            oMInventoryItem.LQtyNonSellable = 0;
            oMInventoryItem.LCreationDate = new DateTime();
            oMInventoryItem.lObject.LIdObject = oObject.LIdObject;
            oMInventoryItem.lObject.LNameObject = oObject.LNameObject;
            oMInventoryItem.LStatus.LDsEstado = null;
            oMInventoryItem.LStatus.LIdStatus = null;
            oMInventoryItem.LListStatus = MStatus.MListStatusWithSelect(Bll_Business.Bll_Status.Bll_getListStatusByIdObject(oMInventoryItem.LObject.LIdObject));
            oMInventoryItem.LListProduct = MProduct.MListAllProductwithSelect(Bll_Business.Bll_Product.bll_GetAllProduct());
            return oMInventoryItem;
        }


    }
}