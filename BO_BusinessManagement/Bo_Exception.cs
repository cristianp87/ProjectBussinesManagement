using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_BusinessManagement
{
    public class Bo_Exception
    {
        private string lException;
        private string lMessageDao;
        private string lInnerException = null;

        public string LException
        {
            get
            {
                return lException;
            }

            set
            {
                lException = value;
            }
        }

        public string LMessageDao
        {
            get
            {
                return lMessageDao;
            }

            set
            {
                lMessageDao = value;
            }
        }

        public string LInnerException
        {
            get
            {
                return lInnerException;
            }

            set
            {
                lInnerException = value;
            }
        }
    }
}
