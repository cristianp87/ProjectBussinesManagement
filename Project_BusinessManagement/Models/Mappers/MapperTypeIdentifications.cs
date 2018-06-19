using System.Collections.Generic;
using System.Web.Mvc;
using BO_BusinessManagement;

namespace Project_BusinessManagement.Models.Mappers
{
    public static class MapperTypeIdentifications
    {
        public static List<SelectListItem> MListAllTypeIdentification(this List<BoTypeIdentification> pBoListTypeIdentification)
        {
            var lMListTypeIdentification = new List<SelectListItem>();
            pBoListTypeIdentification.ForEach(x => {
                var oListItem = new SelectListItem
                {
                    Value = x.LIdTypeIdentification.ToString(),
                    Text = x.LTypeIdentification
                };
                lMListTypeIdentification.Add(oListItem);
            });

            return lMListTypeIdentification;
        }

        public static List<SelectListItem> MListAllTypeIdentificationWithSelect(this List<BoTypeIdentification> pBoListTypeIdentification, bool pWithStatus)
        {
            var lMListTypeIdentification = new List<SelectListItem>();
            var lListItemSelect = new SelectListItem
            {
                Text = "Seleccione...",
                Value = "0"
            };
            lMListTypeIdentification.Add(lListItemSelect);
            if (pWithStatus)
            {
                pBoListTypeIdentification.ForEach(x => {
                    if (x.LActive) {
                        var oListItem = new SelectListItem
                        {
                            Value = x.LIdTypeIdentification.ToString(),
                            Text = x.LTypeIdentification
                        };
                        lMListTypeIdentification.Add(oListItem);
                    }                    
                });
                return lMListTypeIdentification;
            }
            pBoListTypeIdentification.ForEach(x => {
                var oListItem = new SelectListItem
                {
                    Value = x.LIdTypeIdentification.ToString(),
                    Text = x.LTypeIdentification
                };
                lMListTypeIdentification.Add(oListItem);
            });

            return lMListTypeIdentification;
        }
    }
}