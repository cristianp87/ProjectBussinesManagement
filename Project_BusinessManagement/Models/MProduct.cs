using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BO_BusinessManagement;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_BusinessManagement.Models
{
    public class MProduct
    {
        private int lIdProduct;
        private string lNameProduct;
        private string lCdProduct;
        private DateTime lCreationDate;
        private MUnit lUnit;
        private decimal lValue;
        private MSupplier lSupplier;
        private decimal lValueSupplier;
        private MObject lObject;
        private MStatus lStatus;
        private List<SelectListItem> lListStatus;
        private List<SelectListItem> lListUnit;
        private List<SelectListItem> lListSupplier;
        private string lMessageException;
        private List<SelectListItem> lListSelectTaxe;
        private List<MTaxe> lListTaxe;
        private MTaxe lTaxe;

        [UIHint("LIdSupplier")]
        [DisplayName("IDProducto")]
        public int LIdProduct
        {
            get
            {
                return lIdProduct;
            }

            set
            {
                lIdProduct = value;
            }
        }
        [Required(ErrorMessage = "El nombre de producto es requerido.")]
        [DisplayName("Nombre Producto")]
        public string LNameProduct
        {
            get
            {
                return lNameProduct;
            }

            set
            {
                lNameProduct = value;
            }
        }
        [DataType(DataType.DateTime, ErrorMessage = "No es una fecha")]
        [DisplayName("Fecha De Creacion")]
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

        public MUnit LUnit
        {
            get
            {
                return lUnit;
            }

            set
            {
                lUnit = value;
            }
        }
        [Required(ErrorMessage = "El valor de producto es requerido.")]
        [DisplayName("Valor Producto")]
        public decimal LValue
        {
            get
            {
                return lValue;
            }

            set
            {
                lValue = value;
            }
        }

         
        public MSupplier LSupplier
        {
            get
            {
                return lSupplier;
            }

            set
            {
                lSupplier = value;
            }
        }
        [Required(ErrorMessage = "El valor del proveedor es requerido.")]
        [DisplayName("Valor del Proveedor")]
        public decimal LValueSupplier
        {
            get
            {
                return lValueSupplier;
            }

            set
            {
                lValueSupplier = value;
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

        [DisplayName("Proveedores")]
        public List<SelectListItem> LListUnit
        {
            get
            {
                return lListUnit;
            }

            set
            {
                lListUnit = value;
            }
        }

        [DisplayName("Proveedores")]
        public List<SelectListItem> LListSupplier
        {
            get
            {
                return lListSupplier;
            }

            set
            {
                lListSupplier = value;
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
        [DisplayName("Codigo Producto")]
        [Required(ErrorMessage = "El valor del proveedor es requerido.")]
        public string LCdProduct
        {
            get
            {
                return lCdProduct;
            }

            set
            {
                lCdProduct = value;
            }
        }

        public List<MTaxe> LListTaxe
        {
            get
            {
                return lListTaxe;
            }

            set
            {
                lListTaxe = value;
            }
        }

        public MTaxe LTaxe
        {
            get
            {
                return lTaxe;
            }

            set
            {
                lTaxe = value;
            }
        }

        public List<SelectListItem> LListSelectTaxe
        {
            get
            {
                return lListSelectTaxe;
            }

            set
            {
                lListSelectTaxe = value;
            }
        }

        public static List<MProduct> MListProduct(List<Bo_Product> oBListProduct)
        {
            List<MProduct> oMListProduct = new List<MProduct>();
            oBListProduct.ForEach(x => {
                MProduct oMProduct = new MProduct();
                oMProduct.lIdProduct = x.LIdProduct;
                oMProduct.LNameProduct = x.LNameProduct;
                oMProduct.lCdProduct = x.LCdProduct;
                oMProduct.LValue = x.LValue;
                oMProduct.LValueSupplier = x.LValueSupplier;
                oMProduct.LCreationDate = x.LCreationDate;
                oMListProduct.Add(oMProduct);
            });
            return oMListProduct;
        }

        public static List<SelectListItem> MListAllProduct(List<Bo_Product> oBListProduct)
        {
            List<SelectListItem> oMListProduct = new List<SelectListItem>();
            oBListProduct.ForEach(x => {
                SelectListItem oListItem = new SelectListItem();
                oListItem.Value = x.LIdProduct.ToString();
                oListItem.Text = x.LNameProduct;
                oMListProduct.Add(oListItem);
            });
            return oMListProduct;
        }

        public static List<SelectListItem> MListAllProductwithSelect(List<Bo_Product> oBListProduct)
        {
            List<SelectListItem> oMListProduct = new List<SelectListItem>();
            SelectListItem oListItemSelect = new SelectListItem();
            oListItemSelect.Text = "Seleccione...";
            oListItemSelect.Value = "0";
            oMListProduct.Add(oListItemSelect);
            oBListProduct.ForEach(x => {
                SelectListItem oListItem = new SelectListItem();
                oListItem.Value = x.LIdProduct.ToString();
                oListItem.Text = x.LNameProduct;
                oMListProduct.Add(oListItem);
            });
            return oMListProduct;
        }

        public static MProduct MProductById(Bo_Product oBProduct)
        {
            MProduct oMProduct = new MProduct();
            oMProduct.LObject = new MObject();
            oMProduct.LStatus = new MStatus();
            oMProduct.LUnit = new MUnit();
            oMProduct.LListStatus = new List<SelectListItem>();
            oMProduct.lSupplier = new MSupplier();
            oMProduct.LListSupplier = new List<SelectListItem>();
            oMProduct.LNameProduct = oBProduct.LNameProduct;
            oMProduct.LCdProduct = oBProduct.LCdProduct;
            oMProduct.LUnit.LIdUnit = oBProduct.LUnit.LIdUnit;
            oMProduct.LUnit.LNameUnit = oBProduct.LUnit.LNameUnit;
            oMProduct.LUnit.LCdUnit = oBProduct.LUnit.LCdUnit;
            oMProduct.LUnit.LFlActive = oBProduct.LUnit.LFlActive;
            oMProduct.lIdProduct = oBProduct.LIdProduct;
            oMProduct.LCreationDate = oBProduct.LCreationDate;
            oMProduct.LValue = oBProduct.LValue;
            oMProduct.LValueSupplier = oBProduct.LValueSupplier;
            oMProduct.LSupplier.LIdSupplier = oBProduct.LSupplier.LIdSupplier;
            oMProduct.lSupplier.LNameSupplier = oBProduct.LSupplier.LNameSupplier;
            oMProduct.lObject.LIdObject = oBProduct.LObject.LIdObject;
            oMProduct.LObject.LNameObject = oBProduct.LObject.LNameObject;
            oMProduct.LStatus.LDsEstado = oBProduct.LStatus.LDsEstado;
            oMProduct.LStatus.LIdStatus = oBProduct.LStatus.LIdStatus;
            oMProduct.LListSupplier = MSupplier.MListAllSupplier(Bll_Business.Bll_Supplier.bll_GetAllSupplier());
            oMProduct.LListStatus = MStatus.MListAllStatus(Bll_Business.Bll_Status.Bll_getListStatusByIdObject(oBProduct.LObject.LIdObject));
            oMProduct.LListUnit = MUnit.MListAllUnitWithSelect(Bll_Business.Bll_UtilsLib.bll_GetAllUnit());
            return oMProduct;
        }

        public static MProduct MProductEmpty(Bo_Product oBProduct)
        {
            MProduct oMProduct = new MProduct();
            Bo_Object oObject = new Bo_Object();
            oObject = Bll_Business.Bll_UtilsLib.bll_GetObjectByName(MGlobalVariables.LNameObjectProduct);
            oMProduct.LObject = new MObject();
            oMProduct.LStatus = new MStatus();
            oMProduct.LUnit = new MUnit();
            oMProduct.LListUnit = new List<SelectListItem>();
            oMProduct.LListStatus = new List<SelectListItem>();
            oMProduct.LListSupplier = new List<SelectListItem>();
            oMProduct.lNameProduct = null;
            oMProduct.LCdProduct = null;
            oMProduct.LValue = 0;
            oMProduct.LValueSupplier = 0;
            oMProduct.LCreationDate = new DateTime();
            oMProduct.lObject.LIdObject = oObject.LIdObject;
            oMProduct.lObject.LNameObject = oObject.LNameObject;
            oMProduct.LStatus.LDsEstado = null;
            oMProduct.LStatus.LIdStatus = null;
            oMProduct.LListStatus = MStatus.MListStatusWithSelect(Bll_Business.Bll_Status.Bll_getListStatusByIdObject(oMProduct.LObject.LIdObject));
            oMProduct.LListSupplier = MSupplier.MListAllSupplierWithSelect(Bll_Business.Bll_Supplier.bll_GetAllSupplier());
            oMProduct.LListUnit = MUnit.MListAllUnitWithSelect(Bll_Business.Bll_UtilsLib.bll_GetAllUnit());
            return oMProduct;
        }
    }
}