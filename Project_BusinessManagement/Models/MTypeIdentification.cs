using BO_BusinessManagement;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace Project_BusinessManagement.Models
{
    public class MTypeIdentification
    {
        private int lIdTypeIdentification;
        private string lTypeIdentification;
        private bool lActive;

        public int LIdTypeIdentification
        {
            get
            {
                return lIdTypeIdentification;
            }

            set
            {
                lIdTypeIdentification = value;
            }
        }
        [DisplayName("Tipo De Identificación")]
        public string LTypeIdentification
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

        public bool LActive
        {
            get
            {
                return lActive;
            }

            set
            {
                lActive = value;
            }
        }

        public static List<SelectListItem> MListAllTypeIdentification(List<Bo_TypeIdentification> oListTypeIdentification)
        {
            List<SelectListItem> oMListTypeIdentification = new List<SelectListItem>();
            oListTypeIdentification.ForEach(x => {
                SelectListItem oListItem = new SelectListItem();
                oListItem.Value = x.LIdTypeIdentification.ToString();
                oListItem.Text = x.LTypeIdentification;
                oMListTypeIdentification.Add(oListItem);
            });

            return oMListTypeIdentification;
        }

        public static List<SelectListItem> MListAllTypeIdentificationWithSelect(List<Bo_TypeIdentification> oListTypeIdentification)
        {
            List<SelectListItem> oMListTypeIdentification = new List<SelectListItem>();
            SelectListItem oListItemSelect = new SelectListItem();
            oListItemSelect.Text = "Seleccione...";
            oListItemSelect.Value = "0";
            oListTypeIdentification.ForEach(x => {
                SelectListItem oListItem = new SelectListItem();
                oListItem.Value = x.LIdTypeIdentification.ToString();
                oListItem.Text = x.LTypeIdentification;
                oMListTypeIdentification.Add(oListItem);
            });

            return oMListTypeIdentification;
        }

    }
}