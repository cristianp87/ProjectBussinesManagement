using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BO_BusinessManagement;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Project_BusinessManagement.Models
{
    public class MCustomer
    {
        private int lIdCustomer;
        private string lNameCustomer;
        private string lLastNameCustomer;
        private DateTime lCreationDate;
        private MTypeIdentification lTypeIdentification;
        private string lNoIdentification;
        private MStatus lStatus;
        private MObject lObject;
        private List<SelectListItem> lListTypeIdentification;
        private List<SelectListItem> lListStatus;
        private string lMessageException;
        private DateTime lModificationDate;

        [UIHint("LIdCustomer")]
        [DisplayName("Id CLiente")]
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
        [DisplayName("Apellidos Cliente")]
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

        [DisplayName("Fecha De Creacion")]
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
        [DisplayName("Tipo De Identificacion")]
        public MTypeIdentification LTypeIdentification
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
        [DisplayName("Estado")]
        public MStatus LStatus
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

        public MObject LObject
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
        [DisplayName("Tipo De Identificacion")]
        public List<SelectListItem> LListTypeIdentification
        {
            get
            {
                return lListTypeIdentification;
            }

            set
            {
                lListTypeIdentification = value;
            }
        }
        [DisplayName("Estado")]
        public List<SelectListItem> LListStatus
        {
            get
            {
                return lListStatus;
            }

            set
            {
                lListStatus = value;
            }
        }

        public string LMessageException
        {
            get
            {
                return lMessageException;
            }

            set
            {
                lMessageException = value;
            }
        }

        [DisplayName("Fecha De Modificacion")]
        public DateTime LModificationDate
        {
            get
            {
                return lModificationDate;
            }

            set
            {
                lModificationDate = value;
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

        public static MCustomer MCustomerById(Bo_Customer oBCustomer)
        {
            MCustomer oMCustomer = new MCustomer();
            oMCustomer.LObject = new MObject();
            oMCustomer.LStatus = new MStatus();
            oMCustomer.LTypeIdentification = new MTypeIdentification();
            oMCustomer.LListTypeIdentification = new List<SelectListItem>();
            oMCustomer.LListStatus = new List<SelectListItem>();
            oMCustomer.LListTypeIdentification = MTypeIdentification.MListAllTypeIdentification(Bll_Business.Bll_TypeIdentification.bll_getListTypeIdentification());
            oMCustomer.lNameCustomer = oBCustomer.LNameCustomer;
            oMCustomer.LLastNameCustomer = oBCustomer.LLastNameCustomer;
            oMCustomer.LNoIdentification = oBCustomer.LNoIdentification;
            oMCustomer.lIdCustomer = oBCustomer.LIdCustomer;
            oMCustomer.LCreationDate = oBCustomer.LCreationDate;
            oMCustomer.LTypeIdentification.LIdTypeIdentification = oBCustomer.LTypeIdentification.LIdTypeIdentification;
            oMCustomer.lTypeIdentification.LTypeIdentification = oBCustomer.LTypeIdentification.LTypeIdentification;
            oMCustomer.lObject.LIdObject = oBCustomer.LObject.LIdObject;
            oMCustomer.LObject.LNameObject = oBCustomer.LObject.LNameObject;
            oMCustomer.LStatus.LDsEstado = oBCustomer.LStatus.LDsEstado;
            oMCustomer.LStatus.LIdStatus = oBCustomer.LStatus.LIdStatus;
            oMCustomer.LModificationDate = oBCustomer.LModificationDate;
            oMCustomer.LListStatus = MStatus.MListAllStatus(Bll_Business.Bll_Status.Bll_getListStatusByIdObject(oBCustomer.LObject.LIdObject));

            return oMCustomer;
        }
    }
}