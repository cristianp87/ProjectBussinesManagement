using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using BO_BusinessManagement;

namespace Project_BusinessManagement.Models
{
    public class MInvoice
    {
        private int lIdInvoice;
        private string lCdInvoice;
        private DateTime lCreationDate;
        private MObject lObject;
        private MStatus lStatus;
        private MCustomer lCustomer;

        [DisplayName("Id Factura")]
        public int LIdInvoice
        {
            get
            {
                return lIdInvoice;
            }

            set
            {
                lIdInvoice = value;
            }
        }
        [DisplayName("Codigo De Factura")]
        public string LCdInvoice
        {
            get
            {
                return lCdInvoice;
            }

            set
            {
                lCdInvoice = value;
            }
        }
        [DisplayName("Fecha De Creación")]
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

        public MCustomer LCustomer
        {
            get
            {
                return lCustomer;
            }

            set
            {
                lCustomer = value;
            }
        }

        public static List<MInvoice> MListInvoice(List<Bo_Invoice> oBListInvoice)
        {
            List<MInvoice> oMListInvoice = new List<MInvoice>();
            oBListInvoice.ForEach(x => {
                MInvoice oMInvoice = new MInvoice();
                oMInvoice.LIdInvoice = x.LIdInvoice;
                oMInvoice.LCdInvoice = x.LCdInvoice;
                oMInvoice.LCreationDate = x.LCreationDate;
                oMListInvoice.Add(oMInvoice);
            });
            return oMListInvoice;
        }
    }
}