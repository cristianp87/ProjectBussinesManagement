using System;

namespace BO_BusinessManagement
{
    public class Bo_Customer:Bo_Exception
    {
        private int lIdCustomer;
        private string lNameCustomer;
        private string lLastNameCustomer;
        private DateTime lCreationDate;
        private Bo_TypeIdentification lTypeIdentification;
        private string lNoIdentification;
        private Bo_Status lStatus;
        private Bo_Object lObject;
        private DateTime lModificationDate;

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
    }
}
