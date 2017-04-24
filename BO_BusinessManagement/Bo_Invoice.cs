using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_BusinessManagement
{
    public class Bo_Invoice: Bo_Exception
    {
        private int lIdInvoice;
        private string lCdInvoice;
        private DateTime lCreationDate;
        private Bo_Object lObject;
        private Bo_Status lStatus;
        private Bo_Customer lCustomer;
        private List<Bo_InvoiceItem> lListInvoiceItem;

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

        public Bo_Customer LCustomer
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

       

        public List<Bo_InvoiceItem> LListInvoiceItem
        {
            get
            {
                return lListInvoiceItem;
            }

            set
            {
                lListInvoiceItem = value;
            }
        }
    }
}
