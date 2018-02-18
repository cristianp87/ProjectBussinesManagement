using System.ComponentModel;

namespace Project_BusinessManagement.Models
{
    public class MObject
    {
        private int lIdObject;
        private string lNameObject;
        private bool lActive;

        public int LIdObject
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
        [DisplayName("Objeto")]
        public string LNameObject
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

        public bool LActive
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