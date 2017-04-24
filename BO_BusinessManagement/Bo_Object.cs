using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_BusinessManagement
{
    public class Bo_Object : Bo_Exception
    {
        private  int lIdObject;
        private  string lNameObject;
        private  bool lActive;

        public  int LIdObject
        {
            get
            {
                return lIdObject;
            }

            set
            {
                lIdObject = value;
            }
        }

        public  string LNameObject
        {
            get
            {
                return lNameObject;
            }

            set
            {
                lNameObject = value;
            }
        }

        public  bool LActive
        {
            get
            {
                return lActive;
            }

            set
            {
                lActive = value;
            }
        }
    }
}
