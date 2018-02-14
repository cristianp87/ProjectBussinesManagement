namespace BO_BusinessManagement
{
    public class Bo_TypeIdentification : Bo_Exception
    {
        private int lIdTypeIdentification;
        private string lTypeIdentification;
        private bool lActive;

        public int LIdTypeIdentification
        {
            get
            {
                return lIdTypeIdentification;
            }

            set
            {
                lIdTypeIdentification = value;
            }
        }

        public string LTypeIdentification
        {
            get
            {
                return lTypeIdentification;
            }

            set
            {
                lTypeIdentification = value;
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
