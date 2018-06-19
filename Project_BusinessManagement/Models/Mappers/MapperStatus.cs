using System.Collections.Generic;
using System.Web.Mvc;
using BO_BusinessManagement;

namespace Project_BusinessManagement.Models.Mappers
{
    public static class MapperStatus
    {
        public static List<SelectListItem> MListAllStatus(this List<BoStatus> pBoListStatus)
        {
            var lMListStatus = new List<SelectListItem>();
            pBoListStatus.ForEach(x => {
                var oListItem = new SelectListItem
                {
                    Value = x.LIdStatus.ToString(),
                    Text = x.LDsEstado
                };
                lMListStatus.Add(oListItem);
            });
            return lMListStatus;
        }

        public static List<SelectListItem> MListStatusWithSelect(this List<BoStatus> pBoListStatus)
        {
            var lMListStatus = new List<SelectListItem>();
            var lListItemSelect = new SelectListItem
            {
                Text = "Seleccione...",
                Value = "0"
            };
            lMListStatus.Add(lListItemSelect);
            pBoListStatus.ForEach(x => {
                var oListItem = new SelectListItem
                {
                    Value = x.LIdStatus.ToString(),
                    Text = x.LDsEstado
                };
                lMListStatus.Add(oListItem);
            });
            return lMListStatus;
        }
    }
}