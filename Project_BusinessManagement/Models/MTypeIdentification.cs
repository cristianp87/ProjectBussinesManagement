using BO_BusinessManagement;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Project_BusinessManagement.Models
{
    public class MTypeIdentification
    {
        public int LIdTypeIdentification { get; set; }

        [DisplayName("Tipo De Identificación")]
        public string LTypeIdentification { get; set; }

        public bool LActive { get; set; }

        public static List<SelectListItem> MListAllTypeIdentification(List<Bo_TypeIdentification> pBoListTypeIdentification)
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

        public static List<SelectListItem> MListAllTypeIdentificationWithSelect(List<Bo_TypeIdentification> pBoListTypeIdentification)
        {
            var lMListTypeIdentification = new List<SelectListItem>();
            var lListItemSelect = new SelectListItem
            {
                Text = "Seleccione...",
                Value = "0"
            };
            lMListTypeIdentification.Add(lListItemSelect);
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