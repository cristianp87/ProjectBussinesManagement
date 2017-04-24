using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_BusinessManagement
{
    public class Bo_Supplier: Bo_Exception
    {
        private int lIdSupplier;
        private string lNameSupplier;
        private Bo_TypeIdentification lTypeIdentification;
        private string lNoIdentification;
        private DateTime lCreationDate;
        private Bo_Status lStatus;
        private Bo_Object lObject;

        public int LIdSupplier
        {
            get
            {
                return lIdSupplier;
            }

            set
            {
                lIdSupplier = value;
            }
        }

        public string LNameSupplier
        {
            get
            {
                return lNameSupplier;
            }

            set
            {
                lNameSupplier = value;
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
    }
}
