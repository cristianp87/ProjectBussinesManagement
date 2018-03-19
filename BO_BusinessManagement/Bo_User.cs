using System;

namespace BO_BusinessManagement
{
    public class BoUser : BoException
    {
        public int LIdUser { get; set; }

        public string LfNameUser { get; set; }

        public string LsNameUser { get; set; }

        public string LfLastName { get; set; }

        public string LsLastName { get; set; }

        public string LEmail { get; set; }

        public DateTime LBirthDate { get; set; }

        public string LUser { get; set; }

        public string LPassword { get; set; }

        public BoObject LObject { get; set; }

        public BoStatus LStatus { get; set; }

        public string LNoIdentification { get; set; }

        public BoTypeIdentification LTypeIdentification { get; set; }

        public BoRole LRole { get; set; }
    }
}
