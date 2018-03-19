using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BO_BusinessManagement;
using IBusiness.Common;
using IBusiness.Management;

namespace Project_BusinessManagement.Models.Mappers
{
    public static class MapperCustomer
    {
        #region Variables and constants
        public static IStatus LiStatus =
        FacadeProvider.Resolv<IStatus>();

        public static ITypeIdentification LiTypeIdentification =
        FacadeProvider.Resolv<ITypeIdentification>();

        public static IUtilsLib LiUtilsLib =
        FacadeProvider.Resolv<IUtilsLib>();
        #endregion
        public static List<MCustomer> MListCustomer(this List<BoCustomer> oBListCustomer)
        {
            var oMListCustomer = new List<MCustomer>();
            oBListCustomer.ForEach(x => {
                var oMCustomer = new MCustomer
                {
                    LNameCustomer = x.LNameCustomer,
                    LNoIdentification = x.LNoIdentification,
                    LIdCustomer = x.LIdCustomer,
                    LCreationDate = x.LCreationDate,
                    LLastNameCustomer = x.LLastNameCustomer
                };
                oMListCustomer.Add(oMCustomer);
            });
            return oMListCustomer;
        }

        public static MCustomer MCustomerById(this BoCustomer oBCustomer)
        {
            var oMCustomer = new MCustomer
            {
                LObject = new MObject
                {
                    LIdObject = oBCustomer.LObject.LIdObject,
                    LNameObject = oBCustomer.LObject.LNameObject
                },
                LStatus = new MStatus
                {
                    LDsEstado = oBCustomer.LStatus.LDsEstado,
                    LIdStatus = oBCustomer.LStatus.LIdStatus
                },
                LTypeIdentification =
                    new MTypeIdentification
                    {
                        LIdTypeIdentification = oBCustomer.LTypeIdentification.LIdTypeIdentification,
                        LTypeIdentification = oBCustomer.LTypeIdentification.LTypeIdentification
                    },
                LListTypeIdentification = new List<SelectListItem>(),
                LListStatus = new List<SelectListItem>(),
                LNameCustomer = oBCustomer.LNameCustomer,
                LLastNameCustomer = oBCustomer.LLastNameCustomer,
                LNoIdentification = oBCustomer.LNoIdentification,
                LIdCustomer = oBCustomer.LIdCustomer,
                LCreationDate = oBCustomer.LCreationDate,
                LModificationDate = oBCustomer.LModificationDate
            };
            oMCustomer.LListTypeIdentification =
                LiTypeIdentification.bll_getListTypeIdentification().MListAllTypeIdentification();
            oMCustomer.LListStatus = LiStatus.Bll_getListStatusByIdObject(oBCustomer.LObject.LIdObject).MListAllStatus();
            return oMCustomer;
        }

        public static MCustomer MCustomerEmpty(this BoCustomer oBCustomer)
        {
            var lObject = LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectCustomer);
            var lMCustomer = new MCustomer
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
                LTypeIdentification = new MTypeIdentification
                {
                    LIdTypeIdentification = 0,
                    LTypeIdentification = null
                },
                LListTypeIdentification = new List<SelectListItem>(),
                LListStatus = new List<SelectListItem>(),
                LNameCustomer = null,
                LLastNameCustomer = null,
                LNoIdentification = null,
                LIdCustomer = 0,
                LCreationDate = new DateTime(),
                LModificationDate = new DateTime()
            };
            lMCustomer.LListTypeIdentification =               
                    LiTypeIdentification.bll_getListTypeIdentification().MListAllTypeIdentificationWithSelect(true);
            lMCustomer.LListStatus = LiStatus.Bll_getListStatusByIdObject(lMCustomer.LObject.LIdObject).MListStatusWithSelect();
            return lMCustomer;
        }
    }
}