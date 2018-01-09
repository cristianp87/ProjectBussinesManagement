using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_BusinessManagement
{
    public class Bo_User : Bo_Exception
    {
        private int lIdUser;
        private string lFNameUser;
        private string lSNameUser;
        private string lFLastName;
        private string lSLastName;
        private string lEmail;
        private DateTime lBirthDate;
        private string lUser;
        private string lPassword;
        private Bo_Object lObject;
        private Bo_Status lStatus;

        public int LIdUser
        {
            get
            {
                return lIdUser;
            }

            set
            {
                lIdUser = value;
            }
        }

        public string LFNameUser
        {
            get
            {
                return lFNameUser;
            }

            set
            {
                lFNameUser = value;
            }
        }

        public string LSNameUser
        {
            get
            {
                return lSNameUser;
            }

            set
            {
                lSNameUser = value;
            }
        }

        public string LFLastName
        {
            get
            {
                return lFLastName;
            }

            set
            {
                lFLastName = value;
            }
        }

        public string LSLastName
        {
            get
            {
                return lSLastName;
            }

            set
            {
                lSLastName = value;
            }
        }

        public string LEmail
        {
            get
            {
                return lEmail;
            }

            set
            {
                lEmail = value;
            }
        }

        public DateTime LBirthDate
        {
            get
            {
                return lBirthDate;
            }

            set
            {
                lBirthDate = value;
            }
        }

        public string LUser
        {
            get
            {
                return lUser;
            }

            set
            {
                lUser = value;
            }
        }

        public string LPassword
        {
            get
            {
                return lPassword;
            }

            set
            {
                lPassword = value;
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
    }
}
