using BO_BusinessManagement;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Project_BusinessManagement.Models
{
    public class MUnit
    {
        [RegularExpression("^([1-9]{0,11})$", ErrorMessage = "No es valido la selección")]
        public int LIdUnit { get; set; }

        [DisplayName("Nombre de Unidad")]
        public string LNameUnit { get; set; }

        public string LCdUnit { get; set; }

        public bool LFlActive { get; set; }

        public static List<SelectListItem> MListAllUnitWithSelect(List<Bo_Unit> pBoListUnit)
        {
            var lMListUnit = new List<SelectListItem>();
            var lListItemSelect = new SelectListItem
            {
                Text = "Seleccione...",
                Value = "0"
            };
            lMListUnit.Add(lListItemSelect);
            pBoListUnit.ForEach(x => {
                                       var oListItem = new SelectListItem
                                       {
                                           Value = x.LIdUnit.ToString(),
                                           Text = x.LNameUnit
                                       };
                                       lMListUnit.Add(oListItem);
            });
            return lMListUnit;
        }
    }
}