using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO_BusinessManagement;

namespace Project_BusinessManagement.Models
{
    public class MStatus
    {
        private string lIdStatus;
        private string lDsEstado;
        private DateTime lCreationDate;
        private bool lFlActive;
        private List<SelectListItem> lListStatus;

        public string LIdStatus
        {
            get
            {
                return lIdStatus;
            }

            set
            {
                lIdStatus = value;
            }
        }

        [DisplayName("Estado")]
        public string LDsEstado
        {
            get
            {
                return lDsEstado;
            }

            set
            {
                lDsEstado = value;
            }
        }

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
        public static List<SelectListItem> MListAllStatus(List<Bo_Status> oListStatus)
        {
            List<SelectListItem> oMListStatus = new List<SelectListItem>();
            oListStatus.ForEach(x => {
                SelectListItem oListItem = new SelectListItem();
                oListItem.Value = x.LIdStatus.ToString();
                oListItem.Text = x.LDsEstado;
                oMListStatus.Add(oListItem);
            });
            return oMListStatus;
        }
        public static List<SelectListItem> MListAllStatusWithSelect(List<Bo_Status> oListStatus)
        {
            List<SelectListItem> oMListStatus = new List<SelectListItem>();
            SelectListItem oListItemSelect = new SelectListItem();
            oListItemSelect.Text = "Seleccione...";
            oListItemSelect.Value = "0";
            oMListStatus.Add(oListItemSelect);
            oListStatus.ForEach(x => {
                SelectListItem oListItem = new SelectListItem();
                oListItem.Value = x.LIdStatus.ToString();
                oListItem.Text = x.LDsEstado;
                oMListStatus.Add(oListItem);
            });
            return oMListStatus;
        }
    }
}