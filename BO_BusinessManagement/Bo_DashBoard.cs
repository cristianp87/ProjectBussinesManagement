using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_BusinessManagement
{
    public class Bo_DashBoard:Bo_Exception
    {
        private int xint;
        private int yint;
        private string xstring;
        private string ystring;

        public int Xint
        {
            get
            {
                return xint;
            }

            set
            {
                xint = value;
            }
        }

        public int Yint
        {
            get
            {
                return yint;
            }

            set
            {
                yint = value;
            }
        }

        public string Xstring
        {
            get
            {
                return xstring;
            }

            set
            {
                xstring = value;
            }
        }

        public string Ystring
        {
            get
            {
                return ystring;
            }

            set
            {
                ystring = value;
            }
        }
    }
}
