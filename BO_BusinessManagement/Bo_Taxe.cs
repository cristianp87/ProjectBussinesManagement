using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO_BusinessManagement
{
    public class Bo_Taxe: Bo_Exception
    {
        private int lIdTaxe;
        private string lNameTaxe;
        private decimal lValueTaxe;
        private bool lIsPercent;
        private DateTime lCreationDate;
        private Bo_Status lStatus;
        private Bo_Object lObject;

        public int LIdTaxe
        {
            get
            {
                return lIdTaxe;
            }

            set
            {
                lIdTaxe = value;
            }
        }

        public string LNameTaxe
        {
            get
            {
                return lNameTaxe;
            }

            set
            {
                lNameTaxe = value;
            }
        }

        public decimal LValueTaxe
        {
            get
            {
                return lValueTaxe;
            }

            set
            {
                lValueTaxe = value;
            }
        }

        public bool LIsPercent
        {
            get
            {
                return lIsPercent;
            }

            set
            {
                lIsPercent = value;
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
