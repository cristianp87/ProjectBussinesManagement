using BO_BusinessManagement;
using IBusiness.Common;
using IBusiness.Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Project_BusinessManagement.Models
{
    public class MInventory
    {
        #region Variables and constants
        public static IStatus LiStatus =
        FacadeProvider.Resolver<IStatus>();

        public static IUtilsLib LiUtilsLib =
        FacadeProvider.Resolver<IUtilsLib>();
        #endregion

        [DisplayName("Id Inventario")]
        public int LIdInventory { get; set; }

        [DisplayName("Nombre De Inventario")]
        [Required(ErrorMessage = CodesError.LMsgValidateName)]
        public string LNameInventory { get; set; }

        [DisplayName("Fecha De Creación")]
        public DateTime LCreationDate { get; set; }

        public MStatus LStatus { get; set; }

        public MObject LObject { get; set; }

        public List<MInventoryItem> LListInventoryItem { get; set; } = null;

        public List<SelectListItem> LListStatus { get; set; }

        public string LMessageException { get; set; }

        public static List<MInventory> MListInventory(List<Bo_Inventory> oBListInventory)
        {
            List<MInventory> oMListInventory = new List<MInventory>();
            oBListInventory.ForEach(x => {
                                             var oMInventory = new MInventory
                                             {
                                                 LIdInventory = x.LIdInventory,
                                                 LNameInventory = x.LNameInventory,
                                                 LCreationDate = x.LCreationDate
                                             };
                                             oMListInventory.Add(oMInventory);
            });
            return oMListInventory;
        }

        public static MInventory MInventoryById(Bo_Inventory oBInventory)
        {
            var oMInventory = new MInventory
            {
                LObject = new MObject
                {
                    LIdObject = oBInventory.LObject.LIdObject,
                    LNameObject = oBInventory.LObject.LNameObject
                },
                LStatus = new MStatus
                {
                    LDsEstado = oBInventory.LStatus.LDsEstado,
                    LIdStatus = oBInventory.LStatus.LIdStatus
                },
                LNameInventory = oBInventory.LNameInventory,
                LIdInventory = oBInventory.LIdInventory,
                LCreationDate = oBInventory.LCreationDate,
                LListStatus =
                    MStatus.MListAllStatus(LiStatus.Bll_getListStatusByIdObject(oBInventory.LObject.LIdObject))
            };
            return oMInventory;
        }

        public static MInventory MInventoryEmpty()
        {
            var oObject = LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectInventory);
            var lMInventory = new MInventory
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
                LListStatus = new List<SelectListItem>(),
                LNameInventory = null,
                LCreationDate = new DateTime()
            };
            lMInventory.LListStatus = MStatus.MListStatusWithSelect(LiStatus.Bll_getListStatusByIdObject(lMInventory.LObject.LIdObject));
            return lMInventory;
        }
    }
}