using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_BusinessManagement
{
    public class Bo_ConfigurationValue:Bo_Exception
    {
        private int lIdParameter;
        private string lValueParameter;
        private DateTime lCreationDate;

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
