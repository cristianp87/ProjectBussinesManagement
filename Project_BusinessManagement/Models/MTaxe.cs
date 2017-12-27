using System;
using System.Collections.Generic;
using BO_BusinessManagement;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Project_BusinessManagement.Models
{
    public class MTaxe
    {
        private int lIdTaxe;
        private string lNameTaxe;
        private decimal lValueTaxe;
        private bool lIsPercent;
        private DateTime lCreationDate;
        private MStatus lStatus;
        private MObject lObject;
        private int lIdProduct;
        private string lMessageException;

        [UIHint("LIdTaxe")]
        [DisplayName("Id Impuesto")]
        public int LIdTaxe
        {
            get
            {
                return lIdTaxe;
            }

            set
            {
                lIdTaxe = value;
            }
        }

        [DisplayName("Nombre")]
        public string LNameTaxe
        {
            get
            {
                return lNameTaxe;
            }

            set
            {
                lNameTaxe = value;
            }
        }

        [DisplayName("Valor")]
        public decimal LValueTaxe
        {
            get
            {
                return lValueTaxe;
            }

            set
            {
                lValueTaxe = value;
            }
        }

        [DisplayName("Porcentaje")]
        public bool LIsPercent
        {
            get
            {
                return lIsPercent;
            }

            set
            {
                lIsPercent = value;
            }
        }

        [DisplayName("Fecha Creacion")]
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

        public static List<MTaxe> MListAllTaxesXProduct(List<Bo_Taxe> oListTaxe, int? pIdProducto)
        {
            List<MTaxe> oMListTaxe = new List<MTaxe>();
            
            oListTaxe.ForEach(x => {
                MTaxe lTaxe = new MTaxe();
                lTaxe.LStatus = new MStatus();
                lTaxe.lObject = new MObject();
                lTaxe.LIdTaxe = x.LIdTaxe;
                lTaxe.lNameTaxe = x.LNameTaxe;
                lTaxe.LIsPercent = x.LIsPercent;
                lTaxe.LValueTaxe = x.LValueTaxe;
                lTaxe.LStatus.LIdStatus = x.LStatus.LIdStatus;
                lTaxe.lObject.LIdObject = x.LObject.LIdObject;
                lTaxe.lIdProduct = pIdProducto==null? 0: Convert.ToInt32(pIdProducto);
                lTaxe.LMessageException = null;
                oMListTaxe.Add(lTaxe);
            });

            if (!oMListTaxe.Any())
            { 
                MTaxe lTaxe = new MTaxe();
                lTaxe.lIdProduct = pIdProducto == null ? 0 : Convert.ToInt32(pIdProducto);
                lTaxe.LNameTaxe = "N/A";
                lTaxe.LIsPercent = false;
                lTaxe.LValueTaxe = 0;
                lTaxe.LMessageException = "No tiene Impuestos";
                oMListTaxe.Add(lTaxe);
            }
            return oMListTaxe;
        }

        public static List<SelectListItem> MListTaxesWithSelect(List<Bo_Taxe> lListTaxe)
        {
            List<SelectListItem> lListSelectTaxes = new List<SelectListItem>();
            SelectListItem lListItemSelect = new SelectListItem();
            lListItemSelect.Text = "Seleccione...";
            lListItemSelect.Value = "0";
            lListSelectTaxes.Add(lListItemSelect);
            lListTaxe.ForEach(x => {
                SelectListItem lListItem = new SelectListItem();
                lListItem.Value = x.LIdTaxe.ToString();
                lListItem.Text = x.LNameTaxe;
                lListSelectTaxes.Add(lListItem);
            });
            return lListSelectTaxes;
        }

        public static MTaxe GetTaxeXProduct(Bo_Taxe pTaxe, int pIdProduct)
        {
            var lTaxe = new MTaxe();
            lTaxe.LObject = new MObject();
            lTaxe.LStatus = new MStatus();
            lTaxe.LCreationDate = pTaxe.LCreationDate;
            lTaxe.LIdProduct = pIdProduct;
            lTaxe.LIdTaxe = pTaxe.LIdTaxe;
            lTaxe.LIsPercent = pTaxe.LIsPercent;
            lTaxe.LMessageException = pTaxe.LMessageDao;
            lTaxe.LNameTaxe = pTaxe.LNameTaxe;
            lTaxe.LObject.LIdObject = pTaxe.LObject.LIdObject;
            lTaxe.LObject.LNameObject = pTaxe.LObject.LNameObject;
            lTaxe.LStatus.LIdStatus = pTaxe.LStatus.LIdStatus;
            lTaxe.LStatus.LDsEstado = pTaxe.LStatus.LDsEstado;
            lTaxe.LValueTaxe = pTaxe.LValueTaxe;
            return lTaxe;
        }
    }
}