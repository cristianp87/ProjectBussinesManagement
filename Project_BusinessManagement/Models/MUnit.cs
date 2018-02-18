using BO_BusinessManagement;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Project_BusinessManagement.Models
{
    public class MUnit
    {
        private int lIdUnit;
        private string lNameUnit;
        private string lCdUnit;
        private bool lFlActive;

        [RegularExpression("^([1-9]{0,11})$", ErrorMessage = "No es valido la selección")]
        public int LIdUnit
        {
            get
            {
                return lIdUnit;
            }

            set
            {
                lIdUnit = value;
            }
        }
        [DisplayName("Nombre de Unidad")]
        public string LNameUnit
        {
            get
            {
                return lNameUnit;
            }

            set
            {
                lNameUnit = value;
            }
        }

        public string LCdUnit
        {
            get
            {
                return lCdUnit;
            }

            set
            {
                lCdUnit = value;
            }
        }

        public bool LFlActive
        {
            get
            {
                return lFlActive;
            }

            set
            {
                lFlActive = value;
            }
        }

        public static List<SelectListItem> MListAllUnitWithSelect(List<Bo_Unit> oListUnit)
        {
            List<SelectListItem> oMListUnit = new List<SelectListItem>();
            SelectListItem oListItemSelect = new SelectListItem();
            oListItemSelect.Text = "Seleccione...";
            oListItemSelect.Value = "0";
            oMListUnit.Add(oListItemSelect);
            oListUnit.ForEach(x => {
                SelectListItem oListItem = new SelectListItem();
                oListItem.Value = x.LIdUnit.ToString();
                oListItem.Text = x.LNameUnit;
                oMListUnit.Add(oListItem);
            });
            return oMListUnit;
        }
    }
}