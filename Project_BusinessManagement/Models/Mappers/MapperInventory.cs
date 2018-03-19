using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BO_BusinessManagement;
using IBusiness.Common;
using IBusiness.Management;

namespace Project_BusinessManagement.Models.Mappers
{
    public static class MapperInventory
    {
        #region Variables and constants
        public static IStatus LiStatus =
        FacadeProvider.Resolv<IStatus>();

        public static IUtilsLib LiUtilsLib =
        FacadeProvider.Resolv<IUtilsLib>();
        #endregion
        public static List<MInventory> MListInventory(this List<BoInventory> oBListInventory)
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

        public static MInventory MInventoryById(this BoInventory oBInventory)
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
                    LiStatus.Bll_getListStatusByIdObject(oBInventory.LObject.LIdObject).MListAllStatus()
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
            lMInventory.LListStatus = LiStatus.Bll_getListStatusByIdObject(lMInventory.LObject.LIdObject).MListStatusWithSelect();
            return lMInventory;
        }
    }
}