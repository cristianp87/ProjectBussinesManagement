using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Project_BusinessManagement.Models
{
    public class MInventory
    {
        private int lIdInventory;
        private string lNameInventory;
        private DateTime lCreationDate;
        private MStatus lStatus;
        private MObject lObject;
        private List<MInventoryItem> lListInventoryItem = null;
        private List<SelectListItem> lListStatus;
        private string lMessageException;

        [DisplayName("Id Inventario")]
        public int LIdInventory
        {
            get
            {
                return lIdInventory;
            }

            set
            {
                lIdInventory = value;
            }
        }

        [DisplayName("Nombre De Inventario")]
        [Required(ErrorMessage = "El nombre de inventario es requerido.")]
        public string LNameInventory
        {
            get
            {
                return lNameInventory;
            }

            set
            {
                lNameInventory = value;
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

        public List<MInventoryItem> LListInventoryItem
        {
            get
            {
                return lListInventoryItem;
            }

            set
            {
                lListInventoryItem = value;
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

        public static List<MInventory> MListInventory(List<Bo_Inventory> oBListInventory)
        {
            List<MInventory> oMListInventory = new List<MInventory>();
            oBListInventory.ForEach(x => {
                MInventory oMInventory = new MInventory();
                oMInventory.LIdInventory = x.LIdInventory;
                oMInventory.LNameInventory = x.LNameInventory;
                oMInventory.LCreationDate = x.LCreationDate;
                oMListInventory.Add(oMInventory);
            });
            return oMListInventory;
        }

        public static MInventory MInventoryById(Bo_Inventory oBInventory)
        {
            MInventory oMInventory = new MInventory();
            oMInventory.LObject = new MObject();
            oMInventory.LStatus = new MStatus();
            oMInventory.LNameInventory = oBInventory.LNameInventory;
            oMInventory.LIdInventory = oBInventory.LIdInventory;
            oMInventory.LCreationDate = oBInventory.LCreationDate;
            oMInventory.lObject.LIdObject = oBInventory.LObject.LIdObject;
            oMInventory.LObject.LNameObject = oBInventory.LObject.LNameObject;
            oMInventory.LStatus.LDsEstado = oBInventory.LStatus.LDsEstado;
            oMInventory.LStatus.LIdStatus = oBInventory.LStatus.LIdStatus;
            oMInventory.LListStatus = MStatus.MListAllStatus(Bll_Business.Bll_Status.Bll_getListStatusByIdObject(oBInventory.LObject.LIdObject));
            return oMInventory;
        }

        public static MInventory MInventoryEmpty()
        {
            MInventory oMInventory = new MInventory();
            Bo_Object oObject = new Bo_Object();
            oObject = Bll_Business.Bll_UtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectInventory);
            oMInventory.LObject = new MObject();
            oMInventory.LStatus = new MStatus();
            oMInventory.LListStatus = new List<SelectListItem>();
            oMInventory.LNameInventory = null;
            oMInventory.LCreationDate = new DateTime();
            oMInventory.lObject.LIdObject = oObject.LIdObject;
            oMInventory.lObject.LNameObject = oObject.LNameObject;
            oMInventory.LStatus.LDsEstado = null;
            oMInventory.LStatus.LIdStatus = null;
            oMInventory.LListStatus = MStatus.MListStatusWithSelect(Bll_Business.Bll_Status.Bll_getListStatusByIdObject(oMInventory.LObject.LIdObject));
            return oMInventory;
        }
    }
}