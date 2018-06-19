using System.Collections.Generic;
using System.Web.Mvc;
using BO_BusinessManagement;

namespace Project_BusinessManagement.Models.Mappers
{
    public static class MapperUnits
    {
        public static List<SelectListItem> MListAllUnitWithSelect(this List<BoUnit> pBoListUnit)
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