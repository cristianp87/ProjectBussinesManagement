﻿using Bll_Business;
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

        private int lIdSupplier;
        private string lNameSupplier;
        private MTypeIdentification lTypeIdentification;
        private List<SelectListItem> lListTypeIdentification;
        private string lNoIdentification;
        private DateTime lCreationDate;
        private MStatus lStatus;
        private List<SelectListItem> lListStatus;
        private MObject lObject;
        private DateTime lModificationDate;
        private string lMessageException;

        [UIHint("LIdSupplier")]
        [DisplayName("IDProveedores")]
        [RegularExpression("^([1-9][0-9]{0,11})$", ErrorMessage = "No es valido la selección")]
        public int LIdSupplier
        {
            get
            {
                return lIdSupplier;
            }

            set
            {
                lIdSupplier = value;
            }
        }
        [DisplayName("Nombre Proveedor")]
        [Required(AllowEmptyStrings = true, ErrorMessage = "El nombre proveedor es requerido")]
        public string LNameSupplier
        {
            get
            {
                return lNameSupplier;
            }

            set
            {
                lNameSupplier = value;
            }
        }

        public MTypeIdentification LTypeIdentification
        {
            get
            {
                return lTypeIdentification;
            }

            set
            {
                lTypeIdentification = value;
            }
        }

        [DisplayName("Numero Identificacion")]
        [Required(AllowEmptyStrings = true, ErrorMessage = "El Numero de Identificación es requerido")]
        public string LNoIdentification
        {
            get
            {
                return lNoIdentification;
            }

            set
            {
                lNoIdentification = value;
            }
        }

        [DisplayName("Fecha De Creacion")]
        [DataType(DataType.DateTime,ErrorMessage = "Formato de fecha invalido")]
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

        [DisplayName("Estado")]
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

        [DisplayName("Tipo De Identificación")]
        public List<SelectListItem> LListTypeIdentification
        {
            get
            {
                return lListTypeIdentification;
            }

            set
            {
                lListTypeIdentification = value;
            }
        }
        [DisplayName("Estado")]
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
        [DisplayName("Fecha De Modificacion")]
        public DateTime LModificationDate
        {
            get
            {
                return lModificationDate;
            }

            set
            {
                lModificationDate = value;
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

        public static List<MSupplier> MListSupplier(List<Bo_Supplier> oBListSupplier)
        {
            List<MSupplier> oMListSupplier = new List<MSupplier>();        
            oBListSupplier.ForEach(x => {
                MSupplier oMSupplier = new Models.MSupplier();
                oMSupplier.LNameSupplier = x.LNameSupplier;
                oMSupplier.LNoIdentification = x.LNoIdentification;
                oMSupplier.LIdSupplier = x.LIdSupplier;
                oMSupplier.LCreationDate = x.LCreationDate;
                oMListSupplier.Add(oMSupplier);
            });
            return oMListSupplier;
        }

        public static MSupplier MSupplierById(Bo_Supplier oBSupplier)
        {
            MSupplier oMSupplier = new MSupplier();
            oMSupplier.LObject = new MObject();
            oMSupplier.LStatus = new MStatus();
            oMSupplier.LTypeIdentification = new MTypeIdentification();
            oMSupplier.LListTypeIdentification = new List<SelectListItem>();
            oMSupplier.LListStatus = new List<SelectListItem>();
            oMSupplier.LListTypeIdentification = MTypeIdentification.MListAllTypeIdentification(LiTypeIdentification.bll_getListTypeIdentification());
            oMSupplier.LNameSupplier = oBSupplier.LNameSupplier;
            oMSupplier.LNoIdentification = oBSupplier.LNoIdentification;
            oMSupplier.LIdSupplier = oBSupplier.LIdSupplier;
            oMSupplier.LCreationDate = oBSupplier.LCreationDate;
            oMSupplier.LTypeIdentification.LIdTypeIdentification = oBSupplier.LTypeIdentification.LIdTypeIdentification;
            oMSupplier.lTypeIdentification.LTypeIdentification = oBSupplier.LTypeIdentification.LTypeIdentification;
            oMSupplier.lObject.LIdObject = oBSupplier.LObject.LIdObject;
            oMSupplier.LObject.LNameObject = oBSupplier.LObject.LNameObject;
            oMSupplier.LStatus.LDsEstado = oBSupplier.LStatus.LDsEstado;
            oMSupplier.LStatus.LIdStatus = oBSupplier.LStatus.LIdStatus;
            oMSupplier.lModificationDate = oBSupplier.LModificationDate;
            oMSupplier.LListStatus = MStatus.MListAllStatus(LiStatus.Bll_getListStatusByIdObject(oBSupplier.LObject.LIdObject));

            return oMSupplier;
        }

        public static MSupplier MSupplierEmpty(Bo_Supplier oBSupplier)
        {
            MSupplier oMSupplier = new MSupplier();
            Bo_Object oObject = new Bo_Object();
            oObject = LiUtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectSupplier);
            oMSupplier.LObject = new MObject();
            oMSupplier.LStatus = new MStatus();
            oMSupplier.LTypeIdentification = new MTypeIdentification();
            oMSupplier.LListTypeIdentification = new List<SelectListItem>();
            oMSupplier.LListStatus = new List<SelectListItem>();
            oMSupplier.LListTypeIdentification = MTypeIdentification.MListAllTypeIdentificationWithSelect(LiTypeIdentification.bll_getListTypeIdentification());
            oMSupplier.LNameSupplier = null;
            oMSupplier.LNoIdentification = null;
            oMSupplier.LIdSupplier = 0;
            oMSupplier.LCreationDate = new DateTime();
            oMSupplier.LTypeIdentification.LIdTypeIdentification = 0;
            oMSupplier.lTypeIdentification.LTypeIdentification = null;
            oMSupplier.lObject.LIdObject = oObject.LIdObject;
            oMSupplier.lObject.LNameObject = oObject.LNameObject;
            oMSupplier.LStatus.LDsEstado = null;
            oMSupplier.LStatus.LIdStatus = null;
            oMSupplier.lModificationDate = new DateTime();
            oMSupplier.LListStatus = MStatus.MListStatusWithSelect(LiStatus.Bll_getListStatusByIdObject(oMSupplier.LObject.LIdObject));

            return oMSupplier;
        }

        public static List<SelectListItem> MListAllSupplierWithSelect(List<Bo_Supplier> oListSupplier)
        {
            List<SelectListItem> oMListSupplier = new List<SelectListItem>();
            SelectListItem oListItemSelect = new SelectListItem();
            oListItemSelect.Text = "Seleccione...";
            oListItemSelect.Value = "0";
            oMListSupplier.Add(oListItemSelect);
            oListSupplier.ForEach(x => {
                SelectListItem oListItem = new SelectListItem();
                oListItem.Value = x.LIdSupplier.ToString();
                oListItem.Text = x.LNameSupplier;
                oMListSupplier.Add(oListItem);
            });
            return oMListSupplier;
        }

        public static List<SelectListItem> MListAllSupplier(List<Bo_Supplier> oListSupplier)
        {
            List<SelectListItem> oMListSupplier = new List<SelectListItem>();
            oListSupplier.ForEach(x => {
                SelectListItem oListItem = new SelectListItem();
                oListItem.Value = x.LIdSupplier.ToString();
                oListItem.Text = x.LNameSupplier;
                oMListSupplier.Add(oListItem);
            });
            return oMListSupplier;
        }
    }
}