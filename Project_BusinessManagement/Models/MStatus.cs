using BO_BusinessManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Project_BusinessManagement.Models
{
    public class MStatus
    {
        [RegularExpression("^([1-9A-Za-z]{1}[0-9A-Za-z]{0,11})$", ErrorMessage = CodesError.LMsgValidateDdl)]
        public string LIdStatus { get; set; }

        [DisplayName("Estado")]
        public string LDsEstado { get; set; }

        public DateTime LCreationDate { get; set; }

        public bool LFlActive { get; set; }


        public static List<SelectListItem> MListAllStatus(List<Bo_Status> pBoListStatus)
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

        public static List<SelectListItem> MListStatusWithSelect(List<Bo_Status> pBoListStatus)
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