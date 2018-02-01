using System;

namespace BO_BusinessManagement
{
    public class Bo_ConfigurationValue:Bo_Exception
    {
        private int lIdParameter = 0;
        private string lValueParameter = null;
        private DateTime lCreationDate = DateTime.Now;

        public int LIdParameter
        {
            get
            {
                return lIdParameter;
            }

            set
            {
                lIdParameter = value;
            }
        }

        public string LValueParameter
        {
            get
            {
                return lValueParameter;
            }

            set
            {
                lValueParameter = value;
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
    }
}
