using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BO_BusinessManagement;
using IBusiness.Common;
using IBusiness.Management;
using Project_BusinessManagement.Extensibles;

namespace Project_BusinessManagement.Models.Mappers
{
    public static class MapperSupplier
    {
        #region Variables and constants
        public static IStatus LiStatus =
        FacadeProvider.Resolv<IStatus>();

        public static ITypeIdentification LiTypeIdentification =
        FacadeProvider.Resolv<ITypeIdentification>();

        public static IUtilsLib LiUtilsLib =
        FacadeProvider.Resolv<IUtilsLib>();
        #endregion

        public static List<MSupplier> MListSupplier(this List<BoSupplier> pBOListSupplier, bool pWithStatus)
        {
            var lMListSupplier = new List<MSupplier>();
            if (pWithStatus)
            {
                pBOListSupplier.ForEach(x => {
                    if (x.LStatus.LIdStatus.ValidateStatus())
                    {
                        var lMSupplier = new MSupplier
                        {
                            LNameSupplier = x.LNameSupplier,
                            LNoIdentification = x.LNoIdentification,
                            LIdSupplier = x.LIdSupplier,
                            LCreationDate = x.LCreationDate
                        };
                        lMListSupplier.Add(lMSupplier);
                    }                  
                });
            }
            else
            {
                pBOListSupplier.ForEach(x => {
                    var lMSupplier = new MSupplier
                    {
                        LNameSupplier = x.LNameSupplier,
                        LNoIdentification = x.LNoIdentification,
                        LIdSupplier = x.LIdSupplier,
                        LCreationDate = x.LCreationDate
                    };
                    lMListSupplier.Add(lMSupplier);
                });
            }
            
            return lMListSupplier;
        }

        public static MSupplier MSupplierById(this BoSupplier pBoSupplier)
        {
            var lMSupplier = new MSupplier
            {
                LObject = new MObject
                {
                    LIdObject = pBoSupplier.LObject.LIdObject,
                    LNameObject = pBoSupplier.LObject.LNameObject
                },
                LStatus = new MStatus
                {
                    LDsEstado = pBoSupplier.LStatus.LDsEstado,
                    LIdStatus = pBoSupplier.LStatus.LIdStatus
                },
                LTypeIdentification =
                    new MTypeIdentification
                    {
                        LIdTypeIdentification = pBoSupplier.LTypeIdentification.LIdTypeIdentification,
                        LTypeIdentification = pBoSupplier.LTypeIdentification.LTypeIdentification
                    },
                LListTypeIdentification = new List<SelectListItem>(),
                LListStatus = new List<SelectListItem>(),
                LNameSupplier = pBoSupplier.LNameSupplier,
                LNoIdentification = pBoSupplier.LNoIdentification,
                LIdSupplier = pBoSupplier.LIdSupplier,
                LCreationDate = pBoSupplier.LCreationDate,
                LModificationDate = pBoSupplier.LModificationDate
            };
            lMSupplier.LListTypeIdentification =
                LiTypeIdentification.bll_getListTypeIdentification().MListAllTypeIdentification();
            lMSupplier.LListStatus = LiStatus.Bll_getListStatusByIdObject(pBoSupplier.LObject.LIdObject).MListAllStatus();

            return lMSupplier;
        }

        public static MSupplier MSupplierEmpty(this BoSupplier oBSupplier)
        {
            var oObject = LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectSupplier);
            var oMSupplier = new MSupplier
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
                LTypeIdentification = new MTypeIdentification
                {
                    LIdTypeIdentification = 0,
                    LTypeIdentification = null
                },
                LListTypeIdentification = new List<SelectListItem>(),
                LListStatus = new List<SelectListItem>(),
                LNameSupplier = null,
                LNoIdentification = null,
                LIdSupplier = 0,
                LCreationDate = new DateTime(),
                LModificationDate = new DateTime()
            };
            oMSupplier.LListTypeIdentification =               
                    LiTypeIdentification.bll_getListTypeIdentification().MListAllTypeIdentificationWithSelect(true);
            oMSupplier.LListStatus = LiStatus.Bll_getListStatusByIdObject(oMSupplier.LObject.LIdObject).MListStatusWithSelect();
            return oMSupplier;
        }

        public static List<SelectListItem> MListAllSupplierWithSelect(this List<BoSupplier> pBoListSupplier, bool lWithStatus)
        {

            var lMListSupplier = new List<SelectListItem>();
            var lListItemSelect = new SelectListItem
            {
                Text = "Seleccione...",
                Value = "0"
            };
            lMListSupplier.Add(lListItemSelect);
            if (lWithStatus)
            {
                pBoListSupplier.ForEach(x => {
                    if(x.LStatus.LIdStatus.ValidateStatus())
                    {
                        var oListItem = new SelectListItem
                        {
                            Value = x.LIdSupplier.ToString(),
                            Text = x.LNameSupplier
                        };
                        lMListSupplier.Add(oListItem);
                    }                 
                });
            }else
            {
                pBoListSupplier.ForEach(x => {
                        var oListItem = new SelectListItem
                        {
                            Value = x.LIdSupplier.ToString(),
                            Text = x.LNameSupplier
                        };
                        lMListSupplier.Add(oListItem);
                });
            }
            
            return lMListSupplier;
        }

        public static List<SelectListItem> MListAllSupplier(this List<BoSupplier> pBoListSupplier)
        {
            var lMListSupplier = new List<SelectListItem>();
            pBoListSupplier.ForEach(x => {
                var oListItem = new SelectListItem
                {
                    Value = x.LIdSupplier.ToString(),
                    Text = x.LNameSupplier
                };
                lMListSupplier.Add(oListItem);
            });
            return lMListSupplier;
        }
    }
}