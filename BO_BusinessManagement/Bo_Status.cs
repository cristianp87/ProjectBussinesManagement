using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_BusinessManagement
{
    public class Bo_Status: Bo_Exception
    {
        private  string lIdStatus;
        private  string lDsEstado;
        private  DateTime lCreationDate;
        private  bool lFlActive;

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
    }
}
