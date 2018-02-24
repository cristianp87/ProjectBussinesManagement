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
    public class MCustomer
    {
        #region Variables and constants
        public static IStatus LiStatus =
        FacadeProvider.Resolver<IStatus>();

        public static ITypeIdentification LiTypeIdentification =
        FacadeProvider.Resolver<ITypeIdentification>();

        public static IUtilsLib LiUtilsLib =
        FacadeProvider.Resolver<IUtilsLib>();
        #endregion

        [DisplayName("Id CLiente")]
        public int LIdCustomer { get; set; }

        [Display(Name = "Nombre Cliente")]
        [Required(ErrorMessage = CodesError.LMsgValidateName)]
        public string LNameCustomer { get; set; }

        [DisplayName("Apellidos Cliente")]
        [Required(ErrorMessage = CodesError.LMsgValidateLastName)]
        public string LLastNameCustomer { get; set; }

        [DisplayName("Fecha De Creacion")]
        public DateTime LCreationDate { get; set; }

        [DisplayName("Tipo De Identificacion")]
        public MTypeIdentification LTypeIdentification { get; set; }

        [Display(Name = "Numero de Identificacion")]
        [Required(ErrorMessage = CodesError.LMsgValidateNoIdentification)]
        public string LNoIdentification { get; set; }

        [DisplayName("Estado")]
        public MStatus LStatus { get; set; }

        public MObject LObject { get; set; }

        [DisplayName("Tipo De Identificacion")]
        public List<SelectListItem> LListTypeIdentification { get; set; }

        [DisplayName("Estado")]
        public List<SelectListItem> LListStatus { get; set; }

        public string LMessageException { get; set; }

        [DisplayName("Fecha De Modificacion")]
        public DateTime LModificationDate { get; set; }

        public static List<MCustomer> MListCustomer(List<Bo_Customer> oBListCustomer)
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

        public static MCustomer MCustomerById(Bo_Customer oBCustomer)
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
                MTypeIdentification.MListAllTypeIdentification(LiTypeIdentification.bll_getListTypeIdentification());
            oMCustomer.LListStatus = MStatus.MListAllStatus(LiStatus.Bll_getListStatusByIdObject(oBCustomer.LObject.LIdObject));
            return oMCustomer;
        }

        public static MCustomer MCustomerEmpty(Bo_Customer oBCustomer)
        {
            var oObject = LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectCustomer);
            var oMCustomer = new MCustomer
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
                LNameCustomer = null,
                LLastNameCustomer = null,
                LNoIdentification = null,
                LIdCustomer = 0,
                LCreationDate = new DateTime(),
                LModificationDate = new DateTime()
            };
            oMCustomer.LListTypeIdentification =
                MTypeIdentification.MListAllTypeIdentificationWithSelect(
                    LiTypeIdentification.bll_getListTypeIdentification());
            oMCustomer.LListStatus = MStatus.MListStatusWithSelect(LiStatus.Bll_getListStatusByIdObject(oMCustomer.LObject.LIdObject));

            return oMCustomer;
        }
    }
}