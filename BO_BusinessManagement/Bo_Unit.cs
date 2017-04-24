using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_BusinessManagement
{
    public class Bo_Unit
    {
        private int lIdUnit;
        private string lNameUnit;
        private string lCdUnit;
        private bool lFlActive;

        public int LIdUnit
        {
            get
            {
                return lIdUnit;
            }

            set
            {
                lIdUnit = value;
            }
        }

        public string LNameUnit
        {
            get
            {
                return lNameUnit;
            }

            set
            {
                lNameUnit = value;
            }
        }

        public string LCdUnit
        {
            get
            {
                return lCdUnit;
            }

            set
            {
                lCdUnit = value;
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
