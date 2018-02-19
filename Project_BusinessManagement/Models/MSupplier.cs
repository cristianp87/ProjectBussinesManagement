using Bll_Business;
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
    public class MSupplier
    {
        #region Variables and constants
        public static IStatus LiStatus =
        FacadeProvider.Resolver<BllStatus>();

        public static ITypeIdentification LiTypeIdentification =
        FacadeProvider.Resolver<BllTypeIdentification>();

        public static IUtilsLib LiUtilsLib =
        FacadeProvider.Resolver<BllUtilsLib>();
        #endregion

        [DisplayName("IDProveedores")]
        [RegularExpression("^([1-9][0-9]{0,11})$", ErrorMessage = CodesError.LMsgValidateDdl)]
        public int LIdSupplier { get; set; }

        [DisplayName("Nombre Proveedor")]
        [Required(AllowEmptyStrings = true, ErrorMessage = CodesError.LMsgValidateName)]
        public string LNameSupplier { get; set; }

        public MTypeIdentification LTypeIdentification { get; set; }

        [DisplayName("Numero Identificacion")]
        [Required(AllowEmptyStrings = true, ErrorMessage = CodesError.LMsgValidateNoIdentification)]
        public string LNoIdentification { get; set; }

        [DisplayName("Fecha De Creacion")]
        [DataType(DataType.DateTime,ErrorMessage = CodesError.LMsgValidateFormatDatetime)]
        public DateTime LCreationDate { get; set; }

        [DisplayName("Estado")]
        public MStatus LStatus { get; set; }

        public MObject LObject { get; set; }

        [DisplayName("Tipo De Identificación")]
        public List<SelectListItem> LListTypeIdentification { get; set; }

        [DisplayName("Estado")]
        public List<SelectListItem> LListStatus { get; set; }

        [DisplayName("Fecha De Modificacion")]
        public DateTime LModificationDate { get; set; }

        public string LMessageException { get; set; }

        public static List<MSupplier> MListSupplier(List<Bo_Supplier> oBListSupplier)
        {
            var oMListSupplier = new List<MSupplier>();        
            oBListSupplier.ForEach(x => {
                                            var oMSupplier = new Models.MSupplier
                                            {
                                                LNameSupplier = x.LNameSupplier,
                                                LNoIdentification = x.LNoIdentification,
                                                LIdSupplier = x.LIdSupplier,
                                                LCreationDate = x.LCreationDate
                                            };
                                            oMListSupplier.Add(oMSupplier);
            });
            return oMListSupplier;
        }

        public static MSupplier MSupplierById(Bo_Supplier pBoSupplier)
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
                MTypeIdentification.MListAllTypeIdentification(LiTypeIdentification.bll_getListTypeIdentification());
            lMSupplier.LListStatus = MStatus.MListAllStatus(LiStatus.Bll_getListStatusByIdObject(pBoSupplier.LObject.LIdObject));

            return lMSupplier;
        }

        public static MSupplier MSupplierEmpty(Bo_Supplier oBSupplier)
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
                MTypeIdentification.MListAllTypeIdentificationWithSelect(
                    LiTypeIdentification.bll_getListTypeIdentification());
            oMSupplier.LListStatus = MStatus.MListStatusWithSelect(LiStatus.Bll_getListStatusByIdObject(oMSupplier.LObject.LIdObject));

            return oMSupplier;
        }

        public static List<SelectListItem> MListAllSupplierWithSelect(List<Bo_Supplier> pBoListSupplier)
        {
            var lMListSupplier = new List<SelectListItem>();
            var lListItemSelect = new SelectListItem
            {
                Text = "Seleccione...",
                Value = "0"
            };
            lMListSupplier.Add(lListItemSelect);
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

        public static List<SelectListItem> MListAllSupplier(List<Bo_Supplier> pBoListSupplier)
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