using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BO_BusinessManagement;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Project_BusinessManagement.Models
{
    public class MCustomer
    {
        private int lIdCustomer;
        private string lNameCustomer;
        private string lLastNameCustomer;
        private DateTime lCreationDate;
        private Bo_TypeIdentification lTypeIdentification;
        private string lNoIdentification;
        private Bo_Status lStatus;
        private Bo_Object lObject;

        
        public int LIdCustomer
        {
            get
            {
                return lIdCustomer;
            }

            set
            {
                lIdCustomer = value;
            }
        }

        [Display(Name = "Nombre Cliente")]
        [Required(ErrorMessage = "El nombre del cliente es requerido.")]
        public string LNameCustomer
        {
            get
            {
                return lNameCustomer;
            }

            set
            {
                lNameCustomer = value;
            }
        }
        [Display(Name = "Apellidos Cliente")]
        [Required(ErrorMessage = "Los Apellidos del cliente es requerido.")]
        public string LLastNameCustomer
        {
            get
            {
                return lLastNameCustomer;
            }

            set
            {
                lLastNameCustomer = value;
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

        public Bo_TypeIdentification LTypeIdentification
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
        [Display(Name = "Numero de Identificacion")]
        [Required(ErrorMessage = "El numero de identificacion es requerido.")]
        public string LNoIdentification
        {
            get
            {
                return lNoIdentification;
            }

            set
            {
                lNoIdentification = value;
            }
        }

        public Bo_Status LStatus
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

        public Bo_Object LObject
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

        public static List<MCustomer> MListCustomer(List<Bo_Customer> oBListCustomer)
        {
            List<MCustomer> oMListCustomer = new List<MCustomer>();
            oBListCustomer.ForEach(x => {
                MCustomer oMCustomer = new Models.MCustomer();
                oMCustomer.LNameCustomer = x.LNameCustomer;
                oMCustomer.LNoIdentification = x.LNoIdentification;
                oMCustomer.lIdCustomer = x.LIdCustomer;
                oMCustomer.LCreationDate = x.LCreationDate;
                oMCustomer.LLastNameCustomer = x.LLastNameCustomer;
                oMListCustomer.Add(oMCustomer);
            });
            return oMListCustomer;
        }
    }
}